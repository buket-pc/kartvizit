using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kartvizit.Models
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
        [StringLength(20)]
        [DisplayName("Telefon")]
        public string phone { get; set; }
        [StringLength(150)]
        [DisplayName("Adres")]
        public string address { get; set; }

    }
}
