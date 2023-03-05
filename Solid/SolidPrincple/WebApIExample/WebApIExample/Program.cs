
using Microsoft.AspNetCore.Builder;
using System.Security.Claims;
using System.Xml.Linq;
using WebApIExample.CustotomAPI;

namespace WebApIExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<PeopleService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapMethods("/hello-patch", new[] { HttpMethods.Patch },() => "[PATCH] Hello World!");
            app.MapMethods("/hello-head", new[] { HttpMethods.Head },  () => "[HEAD] Hello World!");
            app.MapMethods("/hello-options", new[] {HttpMethods.Options }, () => "[OPTIONS] Hello World!");
            app.MapGet("/hello", HelloHandler.Hello);
            app.MapGet("/user/{userNamae}/products/{id}", (string userName, int id) => $@"This User name {userName} and User Id {id}" );
            app.MapGet("/search", (string q) => { });
            app.MapGet("/people", (int pageIndex, int itemsPerPage) => {
                return $@"Page Index : {pageIndex} and Page Number = {itemsPerPage}";
            });
            app.MapGet("/people2", SearchMethod);

            app.MapGet("/products", (HttpContext context, HttpRequest req, HttpResponse res, ClaimsPrincipal user) => { });

            app.Run();
        }


       static string SearchMethod(int pageIndex = 0,
            int itemsPerPage = 50) => $"Sample result for page {pageIndex } getting{itemsPerPage}elements"; }
}