using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAutoApp.ViewModels
{
    public class UserWithClientViewModel
    {
        public int Id { get; set; }
        public ICollection<ClientViewModel> Clients { get; set; }
    }
}
