using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.DataBase
{
    public class Party
    {
        [Key]
        public int Party_id { get; set; }
        public string Party_name { get; set; }
    }
}
