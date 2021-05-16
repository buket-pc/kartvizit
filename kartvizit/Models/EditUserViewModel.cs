using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kartvizit.Models
{
    public class EditUserViewModel
    {
        //public EditUserViewModel()
        //{
        //    Roles = new List<string>();
        //}
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-Posta (Kullanıcı Adı)")]
        public string Email { get; set; }


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
        //[NotMapped]
        //public IList<string> Roles { get; set; }

    }
}
