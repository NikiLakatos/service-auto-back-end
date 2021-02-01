using Microsoft.AspNetCore.Mvc;
using ServiceAutoApp.DataRepo.Interface;
using ServiceAutoApp.HelpUs;
using ServiceAutoApp.Models;
using ServiceAutoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ServiceAutoApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VisitsController : ControllerBase
    {
        private readonly IVisitRepo _visitRepo;

        public VisitsController(IVisitRepo visitRepo)
        {
            _visitRepo = visitRepo;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<IEnumerable<VisitViewModel>> GetAllVisits()
        {
            return  _visitRepo.GetAllVisits().ToList();
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<VisitModel> AddNewVisit(VisitModel addVisit)
        {
            return _visitRepo.AddVisit(addVisit);
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public ActionResult<VisitViewModel> EditVisit(VisitViewModel visit, int id)
        {
            var response = "{ \"reponse\": \"success\"}";
            _visitRepo.EditVisit(visit, id);
            return Ok(response);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public ActionResult<VisitViewModel> DeleteVisit(int id)
        {
            var response = "{ \"reponse\": \"success\"}";
            _visitRepo.RemovedVisit(id);

            return Ok(response);
        }
    }
}
