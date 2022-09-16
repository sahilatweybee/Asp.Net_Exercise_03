using Asp.Net_Exercise_03.DataBase;
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
        [Key]
        public int Assign_id { get; set; }
        [ForeignKey("Party_tbl")]
        [Required(ErrorMessage ="* Name of the Party is Required")]
        public int Party_id { get; set; }
        [ForeignKey("Product_tbl")]
        [Required(ErrorMessage = "* Name of the Product is Required")]
        public int Product_id { get; set; }
        public Party Party_tbl { get; set; }
        public Product Product_tbl { get; set; }
    }
}
