using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pizza_mama.Data;
using pizza_mama.Models;

namespace pizza_mama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // public class ApiController : ControllerBase (apiController herite de Cotnrollerbase) cette base et comme controller tout cour sauf qu'elle n'inclut pas de json 
    public class ApiController : Controller
    { 
        [HttpGet]
        //la ce que je vais faire je vais changer la route de mon Get celui ci 
        [Route("GetPizzas")]
        //  IEnumerable<string> : Je retourne juste la liste des objets declarés  
        //  IActionResult : une réponse HTTP complète (exemple :  retourne 200(200 il s'agit d'un objet) OK avec la liste des pizzas) ou quand l'objet n'existe pas retourne 404 NotFound
        public IActionResult GetPizzas()
        {
            var pizza = new Pizza(){nom="pizza test", prix = 8, vegetarienne = false, ingredients ="tomate, oignons, oeuf"};
           // quand c'est IEnumerable:  return new string[]{"Pizza", "value2"};
           return Json(pizza);
        }

        /* ça c'est juste pour l'exemple 
        
        private readonly DataContext _context;
          // GET: api/<ApiController>, je peux changer la route si je veux exemple [Route("GetP")] mais a ne pas oublier de la mettre la meme chose dans public IEnumerable<string> GetP()
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[]{"value1", "value2"};
        }

        public ApiController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Api
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
        {
            return await _context.Pizzas.ToListAsync();
        }

        // GET: api/Api/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return pizza;
        }

        // PUT: api/Api/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizza(int id, Pizza pizza)
        {
            if (id != pizza.PizzaID)
            {
                return BadRequest();
            }

            _context.Entry(pizza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Api
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pizza>> PostPizza(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPizza", new { id = pizza.PizzaID }, pizza);
        }

        // DELETE: api/Api/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizza(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }

            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaExists(int id)
        {
            return _context.Pizzas.Any(e => e.PizzaID == id);
        }*/
    }
}
