using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAutoApp.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public double Cnp { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double PhoneNumber { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }

        public UserModel User { get; set; }

        public ICollection<CarModel> Cars { get; set; }
        public ICollection<VisitModel> Visits { get; set; }
    }
}
