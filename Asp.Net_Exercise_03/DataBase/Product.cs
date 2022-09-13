using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.DataBase
{
    public class Product
    {
        [Key]
        public int product_id { get; set; }
        public string product_name { get; set; }
    }
}
