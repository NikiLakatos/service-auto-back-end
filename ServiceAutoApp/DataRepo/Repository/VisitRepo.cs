using Microsoft.EntityFrameworkCore;
using ServiceAutoApp.DataRepo.Interface;
using ServiceAutoApp.Models;
using ServiceAutoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceAutoApp.DataRepo.Repository
{
    public class VisitRepo : IVisitRepo
    {
        private readonly ServiceAutoContext _context;
        public VisitRepo(ServiceAutoContext context)
        {
            _context = context;
        }

        public VisitModel AddVisit(VisitModel visit)
        {
            if (visit == null)
            {
                throw new ArgumentNullException(nameof(visit));
            }
            _context.Add(visit);
            _context.SaveChanges();
            return visit;
        }

        public void EditVisit(VisitViewModel visit, int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var editVisit = _context.Visits.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (editVisit == null)
            {
                throw new ArgumentNullException(nameof(editVisit));
            }
            editVisit.Cost = visit.Cost;
            editVisit.DateOfVisit = visit.DateOfVisit;
            editVisit.Issues = visit.Issues;


            _context.Visits.Update(editVisit);
            _context.SaveChanges();
        }

        public IEnumerable<VisitViewModel> GetAllVisits()
        {
            return _context.Visits.AsNoTracking()
                                    .Select(visit => new VisitViewModel()
                                    {
                                          Id = visit.Id,
                                          Cost = visit.Cost,
                                          DateOfVisit = visit.DateOfVisit,
                                          Issues = visit.Issues,
                                          CarId = visit.CarId
                                         
                                     });
        }

        public VisitModel GetVisitById(int visit)
        {

            return _context.Visits.AsNoTracking().FirstOrDefault(x => x.Id == visit);
        }

        public void RemovedVisit(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var deleteVisit = _context.Visits.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (deleteVisit == null)
            {
                throw new ArgumentNullException(nameof(deleteVisit));
            }
            _context.Visits.Remove(deleteVisit);
            _context.SaveChanges();
        }
    }
}
