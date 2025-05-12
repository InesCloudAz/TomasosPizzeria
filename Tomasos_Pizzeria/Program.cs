using Microsoft.EntityFrameworkCore;
using Tomasos_Pizzeria.Data;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers();

builder.Services.AddDbContext<TomasosPizzeriaContext>(
   options => options.UseSqlServer(@"Data Source=tcp:pizzeria.database.windows.net;Initial Catalog=MyDB;Integrated Security=SSPI;TrustServerCertificate=True;")
);

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});





app.Run();
