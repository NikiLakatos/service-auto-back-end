using ServiceAutoApp.Models;
using ServiceAutoApp.ViewModels;
using System;
using System.Collections.Generic;


namespace ServiceAutoApp.DataRepo.Interface
{
    public interface IClientRepo
    {
        IEnumerable<ClientViewModel> GetClients();
        IEnumerable<ClientWithAllDetailsCarAndVisit> GetVisitAndCarForClient(int id);
        public void AddClient(ClientModel newClient);
        void RemovedClient(int id);
        void EditClient(ClientViewModel client, int id);
    }
}
