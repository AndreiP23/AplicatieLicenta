using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Models
{
    public class PbLiceuModel
    {
        public class Item
        {
            public string Adresa { get; set; }
            public string Email { get; set; }
            public double Medie_Max { get; set; }
            public double Medie_Min { get; set; }
            public string Nume { get; set; }
            public string Sector { get; set; }
            public string collectionId { get; set; }
            public string collectionName { get; set; }
            public string created { get; set; }
            public string id { get; set; }
            public string updated { get; set; }
        }

        public class Root
        {
            public int page { get; set; }
            public int perPage { get; set; }
            public int totalItems { get; set; }
            public int totalPages { get; set; }
            public List<Item> items { get; set; }
        }
    }
}
