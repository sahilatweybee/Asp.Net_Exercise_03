using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Exercise_03.Models
{
    public class PartyModel
    {
        public int Party_id { get; set; }

        [Required(ErrorMessage = "* Party Name is Required")]
        public string Party_name { get; set; }
    }
}
