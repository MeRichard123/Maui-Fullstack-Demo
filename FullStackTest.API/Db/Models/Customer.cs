using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackTest.API.Db.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }


        [ForeignKey(nameof(Order))]
        public int order_number { get; set; } // foreign key

        public Order? order { get; set; } = null; // reference 
    }
}
