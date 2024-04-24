using System.Text;
using XxlShop.Domain;

var Prov = CodePagesEncodingProvider.Instance;
Encoding.RegisterProvider(Prov);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

Data.InitData(builder.Configuration);
Data.ImportCSV("tovar!.csv");
Data.LoadObjects();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
