using Asp.Net_Exercise_03.DataBase;
using System;
using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Exercise_03.Models
{
    public class ProductRateModel
    {

        public int Rate_id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "* Name of the Product is Required")]
        public int Product_id { get; set; }

        [Required(ErrorMessage = "* Product Rate must atleast be 1")]
        [Range(1, int.MaxValue, ErrorMessage = "* Product Rate must atleast be 1")]
        public int Product_rate { get; set; }

        [DisplayFormat(DataFormatString = "{dd MMM yyyy}")]
        [Required(ErrorMessage = "* Date of Updated rate is Required")]
        public DateTime Date_of_Rate { get; set; }

        public Product Product_tbl { get; set; }

    }
}
