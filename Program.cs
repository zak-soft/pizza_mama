using Microsoft.EntityFrameworkCore;
using pizza_mama.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
//la config pour . ou , niveau prix
var cultureInfo = new CultureInfo("fr-FR"); 
cultureInfo.NumberFormat.NumberDecimalSeparator = "."; 
CultureInfo.DefaultThreadCurrentCulture = cultureInfo; 
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Add services to the container.
builder.Services.AddRazorPages();
// IOC -> Inversion Of Control -> créer des instances ou conserver des instances uniques (singleton)
//DataContextInstance
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cette ligne ajoute un filtre d’erreurs spécial pour Entity Framework Core.
// Si tu as un problème avec la base de données : migration manquante,
// base SQLite pas encore créée, erreur de connexion, table inexistante, etc.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Active l'authentification par cookie.
// Si un utilisateur n'est pas connecté et essaie d'accéder à une page protégée,
// il sera redirigé vers la page /Admin pour se connecter.
//alors ça c'est juste la configuaration, pour qu'il lise si l'utilisateur est connecté ou pas Mon site est prêt à utiliser des cookies d’authentification.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Admin";
    });
builder.Services.AddAuthorization();
//je dois rajouter le controller (c'est a dire le srvice dans la fonction globale qui est program.cs)
builder.Services.AddControllers(); 
var app = builder.Build();

// Test pour créer la base SQLite si elle n'existe pas
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    context.Database.EnsureCreated();
}
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
// Configure the HTTP request pipeline.
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
//j'active le systeme controller
app.MapControllers();

app.UseAuthentication(); 
// Active le système d'autorisation.
// Cela permet de protéger certaines pages avec [Authorize].
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();