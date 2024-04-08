using System.ComponentModel.DataAnnotations;

namespace FullStackTest.API.Db.Models
{
    public class Pizza
    {
        [Required]
        [Key]   
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Name { get; set; }

        [Required]
        public bool IsGlutenFree { get; set; }
    }
}
