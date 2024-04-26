using System.Text;
using XxlShop;
using XxlShop.Controllers;

var Prov = CodePagesEncodingProvider.Instance;
Encoding.RegisterProvider(Prov);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

Data.InitData(builder.Configuration);
//Data.ImportCSV("tovar!.csv");
//Data.LoadObjects();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute("product",
       "Product/{id?}",
       new { controller = "Product", action = "Index" });

    endpoints.MapControllerRoute("catalog",
       "Catalog/{id?}",
       new { controller = "Catalog", action = "Index" });

    //endpoints.MapControllerRoute("Admin",
    //       "Admin/{action}/{id?}",
    //       new { controller = "Admin", action = "Index" });

    endpoints.MapControllerRoute("Update",
            "Update/{action}/{id?}",
            new { controller = "Update", action = "Index" });

    endpoints.MapControllerRoute("route2",
       "{controller}/{action}/{id?}",
       new { controller = "Home", action = "Index" });

    endpoints.MapDefaultControllerRoute();
});

app.Run();
