using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Configuration;
using System.Security.Claims;

namespace pizza_mama.Pages.Admin
{
    public class IndexModel : PageModel
    {
        //pour afficher le msg d'erreur si l'admin n'existe pas et le mdp est faut 
        public bool DisplayInvalidAccountMessage = false ; 
        IConfiguration configuration; 
        public IndexModel (IConfiguration configuration)
        {
            this.configuration = configuration;           
        }

        // Cette méthode s'exécute quand on ouvre la page /Admin
        public IActionResult OnGet()
        {
            // On vérifie si l'utilisateur est déjà connecté
            if (HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                // S'il est déjà connecté, on l'envoie directement vers la page admin des pizzas
                return Redirect("/Admin/Pizzas");
            }

            // S'il n'est pas connecté, on affiche la page actuelle, donc la page de connexion
            return Page();
        }

        // Cette méthode s'exécute quand on valide le formulaire de connexion
        public async Task<IActionResult> OnPostAsync(string username, string password, string? ReturnUrl)
        {
            //je lui dis je recupere Auth dans appsettings.json
            var authSection = configuration.GetSection("Auth");         
            string adminLogin = authSection["AdminLogin"];
            string adminPassword = authSection["AdminPassword"];
            // Si le nom d'utilisateur est "admin", alors on connecte l'utilisateur
            if ((username == adminLogin) && (password == adminPassword ))
            {
                DisplayInvalidAccountMessage = false ; 
                // On crée une liste d'informations sur l'utilisateur connecté
                var claims = new List<Claim>
                {
                    // On stocke le nom de l'utilisateur dans le cookie
                    new Claim(ClaimTypes.Name, username)
                };

                // On crée l'identité de l'utilisateur avec ses informations
                var claimsIdentity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme
                );

                // On connecte l'utilisateur en créant un cookie d'authentification
                //Attends que cette opération asynchrone soit terminée avant d’exécuter la ligne suivante.
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity)
                );

                // Après connexion, on redirige vers la page Admin/Pizzas
                // Si ReturnUrl existe, on redirige vers ReturnUrl
                return Redirect(ReturnUrl == null ? "/Admin/Pizzas" : ReturnUrl);
                
            }
            //message d'erreur si le compte n'est pas admnin
            DisplayInvalidAccountMessage = true ; 
            // Si le username n'est pas "admin", on reste sur la même page
            return Page();
        }
        //Il peut continuer à gérer d’autres demandes au lieu de rester figé. C’est le principe de async/await
        public async Task<IActionResult> OnGetLogout()
        {
            //fonction asyn toujous je met await, Attends que la connexion soit bien faite avant de passer à la ligne suivante.(await) 
            //async et await toujours ensemble 
            await HttpContext.SignOutAsync();
            //toujours qaund je fais un redirect(vers une telle page) je rajoute dans Task <IActionResult>
            return Redirect("/Admin"); 
        }

    }
}