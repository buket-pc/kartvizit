using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kartvizit.Models
{
    public class bolum //POCO class
    {//code first yaklaşımı ile tablomuzu oluşturduk. PMC --> add-migration sadf sonra update-database
        public int bolumId { get; set; }
        [StringLength(100)]
        [DisplayName("Kategori Adı")]
        public string name { get; set; }
        [StringLength(200)]
        [DisplayName("Kısa Açıklama")]
        public string shortDesc { get; set; }
        [StringLength(400)]
        [DisplayName("Uzun Açıklama")]
        public string longDesc { get; set; }
        [DisplayName("Sıra Numarası")]
        public int orderId { get; set; }

    }
}
