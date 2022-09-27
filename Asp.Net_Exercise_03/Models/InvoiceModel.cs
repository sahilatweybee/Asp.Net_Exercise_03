using Asp.Net_Exercise_03.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Models
{
    public class InvoiceModel
    {
        [Key]
        public int Invoice_id { get; set; }

        [Required(ErrorMessage = "* Name of the Party is Required")]
        [ListCustomValidator("0")]
        public int Party_id { get; set; }

        [Required(ErrorMessage = "* Name of the Product is Required")]
        [ListCustomValidator("0")]
        public int Product_id { get; set; }

        [Required(ErrorMessage = "* Product Rate is Required")]
        public int Product_rate { get; set; }

        [Required(ErrorMessage = "* Quantity must atleast be 1 unit")]
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
