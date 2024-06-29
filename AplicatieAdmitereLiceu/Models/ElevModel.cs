using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Models
{
    internal class ElevModel
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public double Medie {  get; set; }
        public EmailAddressAttribute EmailAddress { get; set; }
    }
}
