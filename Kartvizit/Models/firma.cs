using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kartvizit.Models
{
    public class firma
    {
        public int firmaId { get; set; }
        [StringLength(100)]
        [DisplayName("Firma Adı")]
        public string name { get; set; }
        [StringLength(200)]
        [DisplayName("Kısa Açıklama")]
        public string shortDesc { get; set; }
        [StringLength(400)]
        [DisplayName("Uzun Açıklama")]
        public string longDesc { get; set; }
        [StringLength(20)]
        [DisplayName("Telefon (Örn: 53212345678)")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Geçerli bir telefon numarası değil.")]
        public string phone { get; set; }
        [StringLength(150)]
        [DisplayName("Adres")]
        public string address { get; set; }
        public int firmaBolumId { get; set; }
        public string imageLink { get; set; }
        [NotMapped]
        [DisplayName("Fotoğraf Yükle")]
        public IFormFile ImageFile { get; set; }
        public DateTime createDate { get; set; }

    }
}
