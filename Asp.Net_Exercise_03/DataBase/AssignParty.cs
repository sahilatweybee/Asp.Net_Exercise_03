using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Net_Exercise_03.DataBase
{
    public class AssignParty
    {
        [Key]
        public int Assign_id { get; set; }
        [ForeignKey("Party_tbl")]
        public int Party_id { get; set; }
        [ForeignKey("Product_tbl")]
        public int Product_id { get; set; }
        public Party Party_tbl { get; set; }
        public Product Product_tbl { get; set; }
    }
}
