using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ContosoPizza.obj.Models;
using ContosoPizza.obj.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;






namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {
        }

        [HttpGet("ObterPizzas")]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();



        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return pizza;
        }


        [HttpPost("AdicionarPizza")]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }


        [HttpPut("AtualizarPizza/{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();
            
            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();

            PizzaService.Update(pizza);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);
            
            if (pizza is null)
                return NotFound();

            PizzaService.Delete(id);
            return NoContent();
        }
        
    }

}
