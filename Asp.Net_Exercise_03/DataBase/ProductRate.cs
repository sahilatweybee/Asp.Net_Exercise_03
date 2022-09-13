using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.DataBase
{
    public class ProductRate
    {
        [Key]
        public int rate_id { get; set; }
        public Product product { get; set; }
        public DateTime date_of_rate { get; set; }
        public int rate { get; set; }

    }
}
