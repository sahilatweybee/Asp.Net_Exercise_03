using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.DataBase
{
    public class AssignParty
    {
        [Key]
        public int assign_id { get; set; }
        public Party party { get; set; }
        public Product product { get; set; }
    }
}
