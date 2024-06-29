using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Models
{
    public class MLAdmissionModel
    {
        public float MedieAdmitere { get; set; }
        public float Locuri { get; set; }
        public float UltimaMedie { get; set; }
        public float MedieAnPrecedent { get; set; }
        public float Medie2021 { get; set; }
        public string Judet { get; set; }
        public string Liceu { get; set; }
        public string Profil { get; set; }
        public string ClasaProfil { get; set; }
        public bool IsAdmitted { get; set; }
    }
}
