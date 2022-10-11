using System.ComponentModel.DataAnnotations;

namespace Asp.Net_Exercise_03.Data
{
    public class Party
    {
        [Key]
        public int Party_id { get; set; }
        public string Party_name { get; set; }
    }
}
