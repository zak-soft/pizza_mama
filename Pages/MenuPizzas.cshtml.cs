// Permet d'utiliser les fonctionnalités MVC comme IActionResult, Controller, etc.
using Microsoft.AspNetCore.Mvc;

// Permet d'utiliser les Razor Pages et la classe PageModel
using Microsoft.AspNetCore.Mvc.RazorPages;

// Permet d'utiliser le modèle Pizza
using pizza_mama.Models;

// Permet d'utiliser Entity Framework Core, notamment ToListAsync()
using Microsoft.EntityFrameworkCore;

// Namespace de la page MenuPizzas
namespace pizza_mama.Pages
{
    // Classe liée à la page MenuPizzas.cshtml
    // Elle contient la logique C# de la page
    public class MenuPizzasModel : PageModel
    {
        // Variable privée qui permet d'accéder à la base de données
        private readonly pizza_mama.Data.DataContext _context;

        // Constructeur de la classe
        // ASP.NET injecte automatiquement le DataContext ici
        public MenuPizzasModel(pizza_mama.Data.DataContext context)
        {
            // On garde le DataContext dans la variable _context
            // pour pouvoir l'utiliser dans toute la classe
            _context = context;
        }

        // Liste des pizzas qui sera envoyée à la page .cshtml
        // IList est une interface, List est une implémentation concrète
        public IList<Pizza> Pizza { get; set; } = default!;

        // Cette méthode est appelée automatiquement quand on ouvre la page en GET
        public async Task OnGetAsync()
        {
            // On récupère toutes les pizzas depuis la base de données
            // ToListAsync() exécute la requête de manière asynchrone
            Pizza = await _context.Pizzas.ToListAsync();
        }
    }
}