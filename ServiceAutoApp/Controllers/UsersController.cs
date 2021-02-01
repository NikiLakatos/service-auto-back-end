
using Microsoft.AspNetCore.Mvc;
using ServiceAutoApp.DataRepo.Interface;
using ServiceAutoApp.HelpUs;
using ServiceAutoApp.HelpUs.ModelsForAuth;
using ServiceAutoApp.Models;
using ServiceAutoApp.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ServiceAutoApp.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IUserService _userService;

        public UsersController(IUserRepo userRepo, IUserService userService)
        {
            _userRepo = userRepo;
            _userService = userService;
        }

        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public ActionResult<IEnumerable<UserViewModel>> GetAllUsers()
        {

            return Ok(_userRepo.GetUsers().ToList());
        }

        [Authorize]
        [HttpGet]
        [Route("UserDetails/{id}")]
        public ActionResult<IEnumerable<UserWithClientViewModel>> GetUser(int id)
        {

            var user = _userRepo.FindClientByUser(id);

            return Ok(user);
        }
        //[Authorize]
        [HttpPost]
        [Route("register")]
        public ActionResult<UserModel> AddNewUser(UserViewModel user)
        {
            var addUser = new UserModel()
            {
                UserName = user.UserName,
                Password = user.Password,
                UserRole = user.UserRole
            };

            _userRepo.AddUser(addUser);
            return addUser;

        }
        [Authorize]
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public ActionResult<UserViewModel> DeleteUser(int id)
        {
            var response = "{ \"reponse\": \"success\"}";
            _userRepo.RemovedUser(id);

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

    }
}
