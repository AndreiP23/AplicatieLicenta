using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Models
{
    public class LiceuViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }
        public string Nume { get; set; }
        public decimal Media { get; set; }
        public string Specializare { get; set; }
        public decimal NumarLocuri {  get; set; }
    }
}
