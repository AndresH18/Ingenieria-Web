using Pokemon.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(); // this enables the services required by razor pages
builder.Services.AddControllersWithViews();

builder.Services.AddPokemonServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages(); // this enable razor pages to be accessed by the routing middleware

/* Map routes templates manually.
 Any route that has controller/action is valid. Since we are setting default values ("=home", "=index")
 routes without action will received by "home/index" in "home", routes with neither controller and route will be received by "home/index".
    /
    /home
    /home/index
 */
// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=home}/{action=index}"); // aplica para toda ruta que sea un controlador seguido de una accion.
//

// use attribute route mapping 
// app.MapControllers();

// use default route mapping "{controller=home}/{action=index}/{id?}
app.MapDefaultControllerRoute();

app.Run();