using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore; // Ensure this namespace is includedusing PharmaAPICreation.Data;
using Microsoft.IdentityModel.Tokens;
using PharmaAPICreation.Data;
using PharmaAPICreation.Mapper;
using PharmaAPICreation.Repo;
using PharmaAPICreation.Services;
using System.Text;

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

//builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddScoped<IAuthorization, AuthorizationService>();
builder.Services.AddScoped<IAdmin, AdminServices>();
builder.Services.AddScoped<ICashier, CashierServices>();
builder.Services.AddScoped<IPharmacist, PharmacistService>();
//builder.Services.AddScoped<IUser, UserServices>();
builder.Services.AddScoped<IPurchaseRepo, PurchaseServices>();
builder.Services.AddScoped<IPurchaseItemRepo, PurchaseItemService>();
//----------------------------By Raju------------------------------->
builder.Services.AddScoped<IMedicineRepository, MedicineService>();
//------------------------------------------------------------------x



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<CustomerRepo, CustomerServices>();

//Add JWT Authentication Configuration
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();
//======================================


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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
