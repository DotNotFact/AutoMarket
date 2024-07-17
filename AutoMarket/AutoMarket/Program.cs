using AutoMarket.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddPersistence();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo API v1");
        // c.SupportedSubmitMethods();
    });

    // app.ApplyMigrate();
}

app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();