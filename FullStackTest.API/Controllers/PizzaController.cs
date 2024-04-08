using FullStackTest.API.Db;
using FullStackTest.API.Db.Models;
using FullStackTest.API.Services;
using Microsoft.AspNetCore.Mvc;

/*
 * https://learn.microsoft.com/en-gb/aspnet/core/mobile/native-mobile-backend?view=aspnetcore-8.0
 * https://learn.microsoft.com/en-us/xamarin/cross-platform/deploy-test/connect-to-local-web-services
 * https://learn.microsoft.com/en-us/training/modules/build-web-api-minimal-database/3-exercise-add-entity-framework-core
 * https://learn.microsoft.com/en-us/dotnet/machine-learning/how-to-guides/serve-model-web-api-ml-net
 */

namespace FullStackTest.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        protected readonly PizzaService _pizzaService;
        public PizzaController(PizzaService service)
        { 
            _pizzaService = service;    
        }

        // get all pizzas
        [HttpGet]
        public async Task<IEnumerable<Pizza>> GetAll()
        {
            return await _pizzaService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = _pizzaService.Get(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pizza pizza)
        {
            await _pizzaService.Add(pizza);

            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,  Pizza pizza)
        {
            if (id != pizza.Id)
            {
                return BadRequest();
            }

            var existingPizza = await _pizzaService.Get(id);
            if (existingPizza is null) 
            {
                return NotFound();
            }

            await _pizzaService.Update(pizza);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pizza = await _pizzaService.Get(id);

            if (pizza is null)
            {
                return NotFound();
            }

            await _pizzaService.Delete(id);

            return NoContent();
        }
    }
}
