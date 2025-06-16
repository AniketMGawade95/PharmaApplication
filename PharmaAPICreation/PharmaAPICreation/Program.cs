using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PharmaAPICreation.Data;
using PharmaAPICreation.Mapper;
using PharmaAPICreation.Repo;
using PharmaAPICreation.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(MappingData));

builder.Services.AddDbContext<ApplicationDbContext>
    (
        options => options.UseSqlServer
        (
            builder.Configuration.GetConnectionString("con")
        )
    );


builder.Services.AddScoped<IAuthorization, AuthorizationService>();
builder.Services.AddScoped<IAdmin, AdminServices>();
builder.Services.AddScoped<ICashier, CashierServices>();
builder.Services.AddScoped<IPharmacist, PharmacistService>();
builder.Services.AddScoped<IUser, UserServices>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
