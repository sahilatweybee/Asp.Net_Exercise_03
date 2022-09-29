using Asp.Net_Exercise_03.DataBase;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net_Exercise_03.Helpers;

namespace Asp.Net_Exercise_03.Models
{
    public class ProductRateModel
    {

        public int Rate_id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "* Name of the Product is Required")]
        public int Product_id { get; set; }


        [Required(ErrorMessage = "* Date of Updated rate is Required")]
        public DateTime Date_of_Rate { get; set; }

        [Required(ErrorMessage = "* Product Rate is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "* Product Rate must atleast be 1")]
        public int Product_rate { get; set; }
        public Product Product_tbl { get; set; }

    }
}
