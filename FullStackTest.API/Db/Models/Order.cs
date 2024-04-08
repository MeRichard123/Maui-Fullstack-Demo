using System.ComponentModel.DataAnnotations;

namespace FullStackTest.API.Db.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime order_time { get; set; }

        public ICollection<Pizza> Order_Details { get; set; } = new List<Pizza>();
    }
}
