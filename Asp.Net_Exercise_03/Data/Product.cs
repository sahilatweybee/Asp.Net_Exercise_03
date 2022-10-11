using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Exercise_03.Data
{
    public class Product
    {
        [Key]
        public int Product_id { get; set; }
        public string Product_name { get; set; }
    }
}
