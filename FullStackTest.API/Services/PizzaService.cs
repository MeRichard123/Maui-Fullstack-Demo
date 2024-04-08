using FullStackTest.API.Db;
using FullStackTest.API.Db.Models;
using FullStackTest.API.Db.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FullStackTest.API.Services
{
    public class PizzaService : BaseRepository
    {
        static int nextId = 3;

        public PizzaService(DataContext ctx) : base(ctx)
        {
            
        }

        public async Task<IEnumerable<Pizza>> GetAll()
        {
            return await _context.Pizzas.ToListAsync();
        }

        public async Task<Pizza> Get(int id)
        {
            return await _context.Pizzas.Where(pizza => pizza.Id == id).FirstAsync();
        }

        public async Task Add(Pizza pizza)
        {
            pizza.Id = nextId++;
            await _context.Pizzas.AddAsync(pizza);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Pizza? pizza = await Get(id);
            if (pizza is null) return;

            _context.Pizzas.Remove(pizza); 
            await _context.SaveChangesAsync();
        }

        public async Task Update(Pizza pizza)
        {
            Pizza? oldPizza = _context.Find<Pizza>(pizza.Id);
            oldPizza = oldPizza ?? pizza;
            await _context.SaveChangesAsync();
        }
    }
}
