using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Exercise_03.Models
{
    public class ProductModel
    {
        public int Product_id { get; set; }
        [Required(ErrorMessage = "* Name of the Product is Required")]
        public string Product_name { get; set; }
    }
}
