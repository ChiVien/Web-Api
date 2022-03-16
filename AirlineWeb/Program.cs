using AirlineWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AirlineWeb.MessageBus;

var builder = WebApplication.CreateBuilder(args);
// string connString = builder.Configuration.GetConnectionString("AirlineConnection");
builder.Services.AddDbContext<AirlineDbContext>(opt =>
    { 
        opt.UseSqlServer(builder.Configuration.GetConnectionString("AirlineConnection"));
    });


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AirlineWeb", Version = "v1" });
            });
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AirlineWeb v1"));
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
