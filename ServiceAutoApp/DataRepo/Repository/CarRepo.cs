using Microsoft.EntityFrameworkCore;
using ServiceAutoApp.DataRepo;
using ServiceAutoApp.DataRepo.Interface;
using ServiceAutoApp.Models;
using ServiceAutoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceAuto.DataRepo.Repository
{
    public class CarRepo : ICarRepo
    {
        private readonly ServiceAutoContext _context;
        public CarRepo(ServiceAutoContext context)
        {

            _context = context;
        }


        public IEnumerable<CarViewModel> GetCars()
        {
            var cars = _context.Cars.AsNoTracking()
                                .Select(car => new CarViewModel()
                                {
                                    Id = car.Id,
                                    Brand = car.Brand,
                                    Model = car.Model,
                                    DateOfBirthCar = car.DateOfBirthCar,
                                    FuelType = car.FuelType,
                                    HorsesPower = car.HorsesPower,
                                    ClientId = car.ClientId
                                }).ToList();
            return cars;
        }

        public CarModel AddCar(CarModel newCar)
        {
            if (newCar == null)
            {
                throw new ArgumentNullException(nameof(newCar));
            }
            _context.Add(newCar);
            _context.SaveChanges();
            return newCar;
        }

        public void EditCar(CarViewModel car, int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var editCar = _context.Cars.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (editCar == null)
            {
                throw new ArgumentNullException(nameof(editCar));
            }
            editCar.Brand = car.Brand;
            editCar.Model = car.Model;
            editCar.DateOfBirthCar = car.DateOfBirthCar;
            editCar.FuelType = car.FuelType;
            editCar.HorsesPower = car.HorsesPower;

            _context.Cars.Update(editCar);
            _context.SaveChanges();
        }

        public IEnumerable<CarWithAllDetailsForVisit> GetCarForAllVisits(int carid)
        {
            var car = _context.Cars.Where(x => x.Id == carid)
                        .Select(x => new CarWithAllDetailsForVisit()
                        {
                            Id = x.Id,
                            Visits = x.Visits
                            .Select(visit => new VisitViewModel()
                            {
                                Id = visit.Id,
                                Cost = visit.Cost,
                                DateOfVisit = visit.DateOfVisit,
                                Issues = visit.Issues,
                                CarId = visit.CarId,
                                ClientId = visit.ClientId
                            }).ToList()

                        }).ToList();

            return car;
        }

        public void RemovedCar(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var deleteCar = _context.Cars.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (deleteCar == null)
            {
                throw new ArgumentNullException(nameof(deleteCar));
            }
            _context.Cars.Remove(deleteCar);
            _context.SaveChanges();
        }
    }
}
