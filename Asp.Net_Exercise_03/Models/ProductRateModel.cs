using Asp.Net_Exercise_03.DataBase;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Models
{
    public class ProductRateModel
    {
        [Key]
        public int Rate_id { get; set; }

        [ForeignKey("Product_tbl")]
        [Required(ErrorMessage = "* Name of the Product is Required")]
        public int Product_id { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        [Required(ErrorMessage = "* Date of Updated rate is Required")]
        public DateTime Date_of_Rate { get; set; }
        [Required(ErrorMessage = "* Rate of the product can not be null")]
        public int Product_rate { get; set; }
        public Product Product_tbl { get; set; }

    }
}
