

using ServiceAutoApp.ViewModels;


namespace ServiceAutoApp.HelpUs.ModelsForAuth
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(UserViewModel user, string token)
        {
            Id = user.Id;
            UserName = user.UserName;
            UserRole = user.UserRole;
            Token = token;
        }
    }
}
