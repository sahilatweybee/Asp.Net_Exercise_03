using Asp.Net_Exercise_03.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Exercise_03.Models
{
    public class AssignPartyModel
    {

        public int Assign_id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "* Name of the Party is Required")]
        public int Party_id { get; set; }

        [Required(ErrorMessage = "* Name of the Product is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "* Name of the Product is Required")]
        public int Product_id { get; set; }

        public Party Party_tbl { get; set; }
        public Product Product_tbl { get; set; }
    }
}
