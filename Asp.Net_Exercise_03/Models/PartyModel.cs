using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Models
{
    public class PartyModel
    {
        public int Party_id { get; set; }

        [Required(ErrorMessage ="* Party Name is Required")]
        public string Party_name { get; set; }
    }
}
