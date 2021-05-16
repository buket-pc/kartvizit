using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kartvizit.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string AdSoyad { get; set; }
        public string Kurum { get; set; }
        public string Bolum { get; set; }
        public string Unvan { get; set; }
        public string Telefon { get; set; }

        
    }
}
