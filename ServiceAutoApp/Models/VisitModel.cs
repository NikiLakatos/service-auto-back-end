using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAutoApp.Models
{
    public class VisitModel
    {
        public int Id { get; set; }

        public Decimal Cost { get; set; }

        public DateTime DateOfVisit { get; set; }
        public string Issues { get; set; }

        public int CarId { get; set; }

        public CarModel Car { get; set; }

        public int ClientId { get; set; }
        public ClientModel Client { get; set; }
    }
}
