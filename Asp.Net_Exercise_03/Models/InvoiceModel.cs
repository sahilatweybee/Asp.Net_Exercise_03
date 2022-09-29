using System;
using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Exercise_03.Models
{
    public class InvoiceModel
    {
        public int Invoice_id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "* Name of the Party is Required")]
        public int Party_id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "* Name of the Product is Required")]
        public int Product_id { get; set; }

        [Required(ErrorMessage = "* Product Rate is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "* Product Rate must atleast be 1")]
        public int Product_rate { get; set; }

        [Required(ErrorMessage = "* Quantity is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "* Quantity must atleast be 1 unit")]
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
