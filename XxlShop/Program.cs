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

//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

Configure(app);

//app.UseAuthentication();   // добавление middleware аутентификации 

//app.UseStaticFiles();

//app.UseRouting();

//app.UseMiddleware<XxlStore.Middleware.AuthCorrectionMiddleware>();

//app.UseAuthorization();   // добавление middleware авторизации 

static void Configure(IApplicationBuilder app)
{
    app.UseStaticFiles();
    //app.UseSession();


    app.MapWhen(
        context => Settings.AdminHostNameConstraint.Match(context),
        branch =>
        {
            branch.UseRouting();

            branch.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "Update/{action}/{id?}",
                    defaults: new { controller = nameof(UpdateController)[..^10], action = "Index" }
                ).WithDisplayName("Update");

                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "",
                    defaults: new {controller = nameof(AdminController)[..^10], action = "Index" }
                ).WithDisplayName("AdminDefault");

            });
        }
    );

    app.MapWhen(
        context => Settings.SiteHostNameConstraint.Match(context),
        branch =>
        {

            branch.UseRouting();

            branch.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Product",
                    pattern: "Product/{id?}",
                    defaults: new { controller = nameof(ProductController)[..^10], action = "Index" }
                ).WithDisplayName("SiteProduct");

                endpoints.MapControllerRoute(
                    name: "Catalog",
                    pattern: "Catalog/{id?}",
                    defaults: new { controller = nameof(CatalogController)[..^10], action = "Index" }
                ).WithDisplayName("SiteCatalog");

                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "",
                    defaults: new { controller = nameof(HomeController)[..^10], action = "Index" }
                ).WithDisplayName("SiteDefault");

                

            });
        }
    );


}

//app.UseEndpoints(endpoints =>
//{

//    endpoints.MapControllerRoute("product",
//       "Product/{id?}",
//       new { controller = "Product", action = "Index" });

//    endpoints.MapControllerRoute("catalog",
//       "Catalog/{id?}",
//       new { controller = "Catalog", action = "Index" });

//    //endpoints.MapControllerRoute("Admin",
//    //       "Admin/{action}/{id?}",
//    //       new { controller = "Admin", action = "Index" });

//    endpoints.MapControllerRoute("Update",
//            "Update/{action}/{id?}",
//            new { controller = "Update", action = "Index" });

//    endpoints.MapControllerRoute("route2",
//       "{controller}/{action}/{id?}",
//       new { controller = "Home", action = "Index" });

//    endpoints.MapDefaultControllerRoute();
//});

app.Run();
