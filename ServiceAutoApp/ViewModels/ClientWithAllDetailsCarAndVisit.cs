using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAutoApp.ViewModels
{
    public class ClientWithAllDetailsCarAndVisit
    {

        public int Id { get; set; }
        public string ClientName { get; set; }

        public ICollection<CarViewModel> Cars { get; set; }

        public ICollection<VisitViewModel> Visits { get; set; }

    }
}
