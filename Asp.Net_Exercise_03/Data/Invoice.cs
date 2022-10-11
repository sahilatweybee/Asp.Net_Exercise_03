using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Exercise_03.Data
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
