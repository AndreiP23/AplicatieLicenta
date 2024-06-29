using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Models
{
    internal class LiceuModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double AddmisionMean { get; set; }
        public double AddmisionVariance { get; set; }
        public double AddmisionMeanVariance { get; private set; }
        public double AddmisionVarianceVariance { get;}
    }
}
