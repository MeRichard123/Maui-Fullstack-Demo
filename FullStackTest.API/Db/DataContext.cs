using Microsoft.EntityFrameworkCore;
using FullStackTest.API.Db.Models;

namespace FullStackTest.API.Db
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }    

        public DbSet<Pizza> Pizzas {  get; set; }

    }
}
