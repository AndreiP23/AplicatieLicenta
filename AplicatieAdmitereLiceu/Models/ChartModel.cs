using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Models
{
    public class ChartModel
    {
        [DisplayName("Categoria A")]
        public double CategoriaA {  get; set; }

        [DisplayName("Categoria B")]
        public double CategoriaB {  get; set; }

        [DisplayName("Categoria C")]
        public double CategoriaC {  get; set; }

        [DisplayName("Categoria D")]
        public double CategoriaD {  get; set; }

        [DisplayName("Categoria F")]
        public double CategoriaF {  get; set; }
    }
}
