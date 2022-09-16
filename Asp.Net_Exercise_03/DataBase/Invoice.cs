using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.DataBase
{
    public class Invoice
    {
        [Key]
        public int Invoice_id { get; set; }
        public int Party_id { get; set; }
        public int Product_id { get; set; }
        public int Product_rate { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
