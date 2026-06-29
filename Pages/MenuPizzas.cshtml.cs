using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pizza_mama.Models;
using Microsoft.EntityFrameworkCore;
namespace pizza_mama.Pages
{
    public class MenuPizzasModel : PageModel
    {
        private readonly pizza_mama.Data.DataContext _context;

        public MenuPizzasModel(pizza_mama.Data.DataContext context)
        {
            _context = context;
        }
        //Ilist = une interface 
        //liste c'est une implementation 
        public IList<Pizza> Pizza { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Pizza = await _context.Pizzas.ToListAsync();
        }
    }
}
