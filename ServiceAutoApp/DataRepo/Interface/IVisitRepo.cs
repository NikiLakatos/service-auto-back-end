using ServiceAutoApp.Models;
using ServiceAutoApp.ViewModels;
using System;
using System.Collections.Generic;


namespace ServiceAutoApp.DataRepo.Interface
{
    public interface IVisitRepo
    {
        IEnumerable<VisitViewModel> GetAllVisits();
        VisitModel GetVisitById(int visit);
        VisitModel AddVisit(VisitModel visit);
        void RemovedVisit(int id);
        void EditVisit(VisitViewModel visit, int id);
    }
}
