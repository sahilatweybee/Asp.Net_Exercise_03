using Asp.Net_Exercise_03.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Models
{
    public class AssignPartyModel
    {
        public int assign_id { get; set; }
        public Party party { get; set; }
        public Product product { get; set; }
    }
}
