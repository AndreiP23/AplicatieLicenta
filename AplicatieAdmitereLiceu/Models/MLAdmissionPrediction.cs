using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Models
{
    public class MLAdmissionPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool IsAdmitted { get; set; }

        [ColumnName("Probability")]
        public float Probability { get; set; }
    }
}
