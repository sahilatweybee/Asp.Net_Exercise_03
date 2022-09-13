using Asp.Net_Exercise_03.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Models
{
    public class ProductRateModel
    {
        public int rate_id { get; set; }
        public Product product { get; set; }
        public DateTime date_of_rate { get; set; }
        public int rate { get; set; }

    }
}
