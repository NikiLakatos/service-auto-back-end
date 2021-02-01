using Microsoft.EntityFrameworkCore;
using ServiceAutoApp.DataRepo.Interface;
using ServiceAutoApp.Models;
using ServiceAutoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAutoApp.DataRepo.Repository
{
    public class ClientRepo : IClientRepo
    {
        private readonly ServiceAutoContext _context;

        public ClientRepo(ServiceAutoContext context)
        {
            _context = context;
        }

        public IEnumerable<ClientViewModel> GetClients()
        {
            return _context.Clients.AsNoTracking().Select(client => new ClientViewModel()
            {
                Id = client.Id,
                ClientName = client.ClientName,
                Cnp = client.Cnp,
                DateOfBirth = client.DateOfBirth,
                PhoneNumber = client.PhoneNumber,
                Address = client.Address,
                UserId = client.UserId,

            }).ToList();
        }

        public IEnumerable<ClientWithAllDetailsCarAndVisit> GetVisitAndCarForClient(int id)
        {
            var client = _context.Clients.AsNoTracking().Where(x => x.Id == id)
                                        .Select(x => new ClientWithAllDetailsCarAndVisit() 
                                        { 
                                            Id = x.Id,
                                            ClientName = x.ClientName,
                                            Cars = x.Cars
                                            .Select(car => new CarViewModel()
                                            {
                                                Id = car.Id,
                                                Brand = car.Brand,
                                                Model = car.Model,
                                                DateOfBirthCar = car.DateOfBirthCar,
                                                FuelType = car.FuelType,
                                                HorsesPower = car.HorsesPower,
                                                ClientId = car.ClientId
                                            }).ToList(),
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

                                        } ).ToList();
                                        
            return client;
        }

        public void AddClient(ClientModel newClient)
        {
                _context.Add(newClient);
                 _context.SaveChanges();
        }

        public void RemovedClient(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var deleteClient = _context.Clients.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (deleteClient == null)
            {
                throw new ArgumentNullException(nameof(deleteClient));
            }
            _context.Clients.Remove(deleteClient);
            _context.SaveChanges();

        }

        public void EditClient(ClientViewModel client, int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var editClient = _context.Clients.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (editClient == null)
            {
                throw new ArgumentNullException(nameof(editClient));
            }
            editClient.ClientName = client.ClientName;
            editClient.Cnp = client.Cnp;
            editClient.DateOfBirth = client.DateOfBirth;
            editClient.PhoneNumber = client.PhoneNumber;
            editClient.Address = client.Address;

            _context.Clients.Update(editClient);
            _context.SaveChanges();

        }
    }
}
