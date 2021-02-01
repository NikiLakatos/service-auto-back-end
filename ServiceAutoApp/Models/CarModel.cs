using System;
using System.Collections.Generic;
namespace ServiceAutoApp.Models
{
    public class CarModel
    {
        public int Id { get; set; } //can be GuId

        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime DateOfBirthCar { get; set; }
        public string FuelType { get; set; }
        public int HorsesPower { get; set; }

        public int ClientId { get; set; }

        public ClientModel Client { get; set; }

        public ICollection<VisitModel> Visits { get; set; }
    }
}
