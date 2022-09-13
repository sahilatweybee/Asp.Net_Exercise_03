using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Models
{
    public class PartyModel
    {
        public int party_id { get; set; }
        [Required(ErrorMessage ="* Party Name is Required")]
        public string party_name { get; set; }
    }
}
