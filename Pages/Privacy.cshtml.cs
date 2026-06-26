using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pizza_mama.Data;
using pizza_mama.Models;

namespace pizza_mama.Pages
{
    // ma class 
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly DataContext dataContext;


    //le constructeur de cette class ; j'ai rajouté un logger dedans pour le debug, maintenant je rajoute aussi le modele de la base de données 
    //donc >logger, datacontext 
        public PrivacyModel(ILogger<PrivacyModel> logger, DataContext dataContext)
        {
            _logger = logger;
            this.dataContext = dataContext;
        }

        public void OnGet()
        {
            /*_logger.LogInformation("Page Privacy chargée");
            var pizza = new Pizza() { nom = "mici", prix = 5 };
            dataContext.Pizzas.Add(pizza);
            dataContext.SaveChanges(); */
        }
    }
}