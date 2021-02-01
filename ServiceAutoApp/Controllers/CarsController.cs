
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
    public class CarsController : ControllerBase
    {
        private readonly ICarRepo _carRepo;
        public CarsController(ICarRepo carRepo)
        {
            _carRepo = carRepo;
        }
       
        [HttpGet]
        [Route("[action]")]
        public ActionResult<IEnumerable<CarViewModel>> GetAllCars()
        {
            return _carRepo.GetCars().ToList();
        }
       
        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<IEnumerable<CarWithAllDetailsForVisit>> GetDetailsForCar(int id)
        {
            var car = _carRepo.GetCarForAllVisits(id);
            return Ok(car);
        }
       
        [HttpPost]
        [Route("[action]")]
        public ActionResult<CarModel> AddNewCar(CarModel car)
        {
            return Ok(_carRepo.AddCar(car));
        }
        
        [HttpDelete]
        [Route("[action]/{id}")]
        public ActionResult<CarViewModel> DeleteCar(int id)
        {
            var response = "{ \"reponse\": \"success\"}";
            _carRepo.RemovedCar(id);

            return Ok(response);
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public ActionResult<CarViewModel> EditCar(CarViewModel car, int id)
        {
            var response = "{ \"reponse\": \"success\"}";
            _carRepo.EditCar(car, id);
            return Ok(response);
        }
    }
}
