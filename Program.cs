using Microsoft.EntityFrameworkCore;
using seance2.Models;

namespace seance2
{
    public class Program
    {
        public static void Main(string[] args)
        
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //pour connection a la base de donnee
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

			//ken jatte mel loulle raw eli ba3dha maye5dmouch
			//app.UseWelcomePage("/"); 


			//ken famech path tjiblek hello ahmed 
			//app.MapGet("/", () =>"hello ahmed" );

            //return sur page ficher json qui  appartien id,name de movie 
			//app.MapGet("Movietest", () => new Movie() { name="Movie1"});


            //app.MapGet("Product/test1", () => "test1");


			//product?name=ahmed return ahmed
			//app.MapGet("product", (string name) => name);


            //app.MapGet("/test",()=>"hello world").WithName("Hello");

            //redirect vers le app de name hello
            //app.MapGet("/redirect-me", () => Results.RedirectToRoute("hello"));
        

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}