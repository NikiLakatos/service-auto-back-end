
using Microsoft.AspNetCore.Mvc;
using ServiceAutoApp.DataRepo.Interface;
using ServiceAutoApp.HelpUs;
using ServiceAutoApp.Models;
using ServiceAutoApp.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ServiceAutoApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepo _clientRepo;
        public ClientsController(IClientRepo clientRepo)
        {
            _clientRepo = clientRepo;
        }
       
        [HttpGet]
        [Route("[action]")]
        public ActionResult<IEnumerable<ClientViewModel>> GetAllClients()
        {
            return _clientRepo.GetClients().ToList();
        }
 
        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<IEnumerable<ClientWithAllDetailsCarAndVisit>> GetClientById(int id)
        {
            var client = _clientRepo.GetVisitAndCarForClient(id);
            return Ok (client);
        }
       
        [HttpPost]
        [Route("[action]")]
        public ActionResult<ClientModel> AddNewClient(ClientViewModel client)
        {
            var clientAdd = new ClientModel()
            {
                Id = client.Id,
                ClientName = client.ClientName,
                Cnp = client.Cnp,
                DateOfBirth = client.DateOfBirth,
                PhoneNumber = client.PhoneNumber,
                Address = client.Address,
                UserId = client.UserId,
            };

            _clientRepo.AddClient(clientAdd);
            return clientAdd;
        }

        [HttpDelete]
        [Route("[action]/{id}")]

        public ActionResult<ClientViewModel> DeleteClient(int id)
        {
            var response = "{ \"reponse\": \"success\"}";
            _clientRepo.RemovedClient(id);

            return Ok(response);
        }
       
        [HttpPut]
        [Route("[action]/{id}")]
        public ActionResult<ClientViewModel> EditClient(ClientViewModel client,  int id)
        {
            var response = "{ \"reponse\": \"success\"}";
            _clientRepo.EditClient(client, id);

            return Ok(response);
        }
    }
}
