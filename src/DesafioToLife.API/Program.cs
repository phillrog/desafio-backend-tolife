using DesafioToLife.API.Configuration;
using DesafioToLife.Infrastructure.Context;
using DesafioToLife.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDependencyInjection(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAngular", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAngular");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfig();
}

app.UseHttpsRedirection();
app.MapControllers();

// Seed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    await DBDesafioToLifeInitializer.SeedAsync(context);
}
app.Run();

