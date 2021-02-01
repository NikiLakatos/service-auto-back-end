using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceAutoApp.DataRepo.Interface;
using ServiceAutoApp.HelpUs.ModelsForAuth;
using ServiceAutoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAutoApp.HelpUs
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<UserViewModel> GetAll();
        UserViewModel GetById(int id);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, IUserRepo userRepo)
        {
            _appSettings = appSettings.Value;
            _userRepo = userRepo;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userRepo.GetUsers().SingleOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return _userRepo.GetUsers();
        }

        public UserViewModel GetById(int id)
        {
            return _userRepo.GetUsers().FirstOrDefault(x => x.Id == id);
        }

        // helper methods

        private string GenerateJwtToken(UserViewModel user)
        {
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
