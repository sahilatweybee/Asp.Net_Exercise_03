using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Net_Exercise_03.DataBase
{
    public class ProductRate
    {
        [Key]
        public int Rate_id { get; set; }

        [ForeignKey("Product_tbl")]
        public int Product_id { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date_of_Rate { get; set; }
        public int Product_rate { get; set; }
        public Product Product_tbl { get; set; }

    }
}
