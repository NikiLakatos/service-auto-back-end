using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAutoApp.ViewModels
{
    public class CarWithAllDetailsForVisit
    {
        public int Id { get; set; }
        public ICollection<VisitViewModel> Visits { get; set; }
    }
}
