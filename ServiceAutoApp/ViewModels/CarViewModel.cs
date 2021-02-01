using System;

namespace ServiceAutoApp.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime DateOfBirthCar { get; set; }
        public string FuelType { get; set; }
        public int HorsesPower { get; set; }
        public int ClientId { get; set; }
    }
}
