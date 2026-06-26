using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pizza_mama.Data;
using pizza_mama.Models;

namespace pizza_mama.Pages.Admin.Pizzas
{
    //[Authorize] = bloque la page si l'utilisateur n'est pas connecté (configuration cookies qu'on rajouté dans prog)
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly pizza_mama.Data.DataContext _context;

        public IndexModel(pizza_mama.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Pizza> Pizza { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Pizza = await _context.Pizzas.ToListAsync();
        }
    }
}
