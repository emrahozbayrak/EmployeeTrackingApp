using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Entities
{
    public class EmployeeHistory
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public short StatusTypeId { get; set; }
        public DateTime LocationTime { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual StatusType StatusType { get; set; }
    }
}
