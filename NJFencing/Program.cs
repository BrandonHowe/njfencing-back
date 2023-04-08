using System.Text.Json.Serialization;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NJFencing.Database;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost:3000");
        });
});

// Add services to the container.

builder.Services.AddFastEndpoints();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDoc();
builder.Services.AddDbContext<DatabaseContext>(b =>
{
    b.UseNpgsql(builder.Configuration["DatabaseSettings:ConnectionString"]);
});
builder.Services.AddScoped<DatabaseSeed>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseHsts();

app.UseFastEndpoints(c =>
{
    c.Serializer.Options.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();

    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using var scope = scopedFactory!.CreateScope();
    var service = scope.ServiceProvider.GetService<DatabaseSeed>();
    service!.Seed();
}

app.Run();