using ServiceAutoApp.Models;
using ServiceAutoApp.ViewModels;
using System;
using System.Collections.Generic;


namespace ServiceAutoApp.DataRepo.Interface
{
    public interface ICarRepo
    {
        IEnumerable<CarViewModel> GetCars();
        IEnumerable<CarWithAllDetailsForVisit> GetCarForAllVisits(int id);
        CarModel AddCar(CarModel newClient);
        void RemovedCar(int id);
        void EditCar(CarViewModel client, int id);
    }
}
