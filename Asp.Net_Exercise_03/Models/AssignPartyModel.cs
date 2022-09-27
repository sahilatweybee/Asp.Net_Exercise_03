using Asp.Net_Exercise_03.DataBase;
using Asp.Net_Exercise_03.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Models
{
    public class AssignPartyModel
    {
        
        public int Assign_id { get; set; }
        [Required(ErrorMessage ="* Party is Required")]
        [ListCustomValidator("0")]
        public int Party_id { get; set; }

        [Required(ErrorMessage = "* Product is Required")]
        [ListCustomValidator("0")]
        public int Product_id { get; set; }

        public Party Party_tbl { get; set; }
        public Product Product_tbl { get; set; }
    }
}
