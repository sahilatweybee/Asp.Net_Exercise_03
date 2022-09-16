using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Models
{
    public class ProductModel
    {
        public int Product_id { get; set; }
        [Required(ErrorMessage = "* Name of the Product is Required")]
        public string Product_name { get; set; }
    }
}
