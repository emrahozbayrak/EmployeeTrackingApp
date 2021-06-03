using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Mobile.Models
{
    public class UserLocation
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public short StatusTypeId { get; set; }
        public DateTime LocationTime { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
