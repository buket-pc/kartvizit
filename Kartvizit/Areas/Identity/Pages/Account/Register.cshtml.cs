using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using kartvizit.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace kartvizit.Areas.Identity.Pages.Account
{
    [AllowAnonymous]

    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "E-Posta (Kullanıcı Adı)")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "{0} en az {2} en fazla {1} karakter uzunluğunda olmalıdır. En az 1 büyük 1 küçük harf, bir de noktalama işareti içermelidir.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Parola")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Parola Tekrar")]
            [Compare("Password", ErrorMessage = "Parola Eşleşmiyor.")]
            public string ConfirmPassword { get; set; }
            [Display(Name = "Ad Soyad")]
            public string AdSoyad { get; set; }
            [Display(Name = "Kurum")]
            [StringLength(50, ErrorMessage = "En az {2} en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 4)]
            public string Kurum { get; set; }
            [Display(Name = "Bölüm")]
            [StringLength(20, ErrorMessage = "En az {2} en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 4)]
            public string Bolum { get; set; }
            [Display(Name = "Ünvan")]
            [StringLength(20, ErrorMessage = "En az {2} en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 2)]
            public string Unvan { get; set; }
            [Display(Name = "Telefon (Örn: 5321234567)")]
            [DataType(DataType.PhoneNumber)]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Geçerli bir telefon numarası değil.")]
            public string Telefon { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, AdSoyad = Input.AdSoyad, Kurum = Input.Kurum, Bolum = Input.Bolum, Unvan = Input.Unvan, Telefon = Input.Telefon };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                    //string to = "kartvizitsistemi@gmail.com";
                    //string subject = "Üyelik Onayı: " + Input.Email;
                    //string body = $"Aşağıda detayları bulunan başvuru sahibinin üyeliğini aktifleştirmek için <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>tıklayınız.</a>."
                    //    + "<br />" + Input.AdSoyad
                    //    + "<br />" + Input.Kurum
                    //    + "<br />" + Input.Bolum
                    //    + "<br />" + Input.Unvan
                    //    + "<br />" + Input.Telefon
                    //    ;

                    string toUser = Input.Email;
                    string subjectUser = "Kartvizit Sistemi Kayıt Başvurusu: " + Input.AdSoyad;
                    string bodyUser = $"Merhaba üyeliğinizi aktifleştirmek için <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>tıklayınız.</a>."
                        + "<br/>"
                        + "Tüm sorularınız için bizimle irtibata geçebilirsiniz. (0534) 019 75 26 / buketay@gmail.com";

                    //MailMessage mm = new MailMessage();
                    //mm.To.Add(to);
                    //mm.Subject = subject;
                    //mm.Body = body;
                    //mm.From = new MailAddress("fortunaeventstest@gmail.com");
                    //mm.IsBodyHtml = true;
                    //SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    //smtp.Port = 587;
                    //smtp.UseDefaultCredentials = true;
                    //smtp.EnableSsl = true;
                    //smtp.Credentials = new System.Net.NetworkCredential("fortunaeventstest@gmail.com", "fortuna123!");
                    //smtp.Send(mm);

                    //MailToSomeOne(to, subject, body);
                    MailToSomeOne(toUser, subjectUser, bodyUser);


                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        public void MailToSomeOne(string MailTo, string MailSubject, string MailBody)
        {
            string to = MailTo;
            string subject = MailSubject;
            string body = MailBody;

            MailMessage mm = new MailMessage();
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.From = new MailAddress("kartvizitsistemi@gmail.com");
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true; //smtp.gmail.com da bunu true yapıyoruz, ayrıca gmailde ayarını da yapmak lazım.
            smtp.Credentials = new System.Net.NetworkCredential("kartvizitsistemi@gmail.com", "Buket%123!");
            smtp.Send(mm);
        }
    }
}
