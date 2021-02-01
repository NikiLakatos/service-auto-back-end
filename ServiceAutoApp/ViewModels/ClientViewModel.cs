using System;

namespace ServiceAutoApp.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; } //can be GuId
        public string ClientName { get; set; }
        public double Cnp { get; set; } //can be be strting
        public DateTime DateOfBirth { get; set; }
        public double PhoneNumber { get; set; } //can be strting
        public string Address { get; set; }
        public int UserId { get; set; }
    }
}
