using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace pizza_mama.Pages.Admin
{
    public class IndexModel : PageModel
    {
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
            // Si le nom d'utilisateur est "admin", alors on connecte l'utilisateur
            if (username == "admin")
            {
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
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity)
                );

                // Après connexion, on redirige vers la page Admin/Pizzas
                // Si ReturnUrl existe, on redirige vers ReturnUrl
                return Redirect(ReturnUrl == null ? "/Admin/Pizzas" : ReturnUrl);
            }

            // Si le username n'est pas "admin", on reste sur la même page
            return Page();
        }
    }
}