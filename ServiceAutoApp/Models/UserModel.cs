using System.Collections.Generic;

namespace ServiceAutoApp.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string UserRole { get; set; }

        public ICollection<ClientModel> Clients { get; set; }
    }
}
