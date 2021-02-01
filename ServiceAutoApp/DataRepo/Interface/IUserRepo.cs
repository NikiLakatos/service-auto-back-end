using ServiceAutoApp.Models;
using ServiceAutoApp.ViewModels;
using System;
using System.Collections.Generic;


namespace ServiceAutoApp.DataRepo.Interface
{
    public interface IUserRepo
    {
        IEnumerable<UserViewModel> GetUsers();
        IEnumerable<UserWithClientViewModel> FindClientByUser(int userId);
        void AddUser(UserModel newUser);
        void RemovedUser(int id);
       
    }
}
