
using Microsoft.EntityFrameworkCore;
using ServiceAutoApp.DataRepo.Interface;
using ServiceAutoApp.Models;
using ServiceAutoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ServiceAutoApp.DataRepo.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly ServiceAutoContext _context;
        public UserRepo(ServiceAutoContext context)
        {
            _context = context;
        }

        public IEnumerable<UserViewModel> GetUsers()
        {

            var users = _context.Users.AsNoTracking().Select(user => new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                UserRole = user.UserRole
            }).ToList();
            return users;
        }

        public IEnumerable<UserWithClientViewModel> FindClientByUser(int id)
        {
            var user = _context.Users
                      .Where(x => x.Id == id)
                      .Select(x => new UserWithClientViewModel()
                      {
                          Id = x.Id,
                          Clients = x.Clients
                              .Select(y => new ClientViewModel()
                              {
                                  Id = y.Id,
                                  ClientName = y.ClientName,
                                  Cnp = y.Cnp,
                                  DateOfBirth = y.DateOfBirth,
                                  PhoneNumber = y.PhoneNumber,
                                  Address = y.Address,
                                  UserId = y.UserId

                              })
                              .ToList()
                      })
                      .ToList();
            return user;

        }

        public void AddUser(UserModel newUser)
        {

            _context.Add(newUser);
            _context.SaveChanges();
            
        }  

        public void RemovedUser(int id)
        {
            if(id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var deleteUser =  _context.Users.FirstOrDefault(x => x.Id == id);
            if(deleteUser == null)
            {
                throw new ArgumentNullException(nameof(deleteUser));
            }
            _context.Users.Remove(deleteUser);
            _context.SaveChanges();

        }

        
    }
}
