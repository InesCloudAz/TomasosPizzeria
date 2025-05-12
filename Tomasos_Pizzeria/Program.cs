using Microsoft.EntityFrameworkCore;
using Tomasos_Pizzeria.Data;
using Tomasos_Pizzeria.Data.Interfaces;
using Tomasos_Pizzeria.Data.Repos;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers();


builder.Services.AddDbContext<TomasosPizzeriaContext>(
   options => options.UseSqlServer(
       "Server=tcp:pizzeria.database.windows.net,1433;Initial Catalog=TomasosPizzeria;Persist Security Info=False;User ID=tomasospizzeria;Password=pizzeria123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
       sqlServerOptions => sqlServerOptions.EnableRetryOnFailure())
);




builder.Services.AddScoped<IAdminRepo, AdminRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();

var app = builder.Build();



app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});





app.Run();
