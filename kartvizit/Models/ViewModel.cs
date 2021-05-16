using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kartvizit.Models
{
    public class ViewModel
    {
        public IEnumerable<firma> firmas { get; set; }
        public IEnumerable<bolum> bolums { get; set; }
    }
}
