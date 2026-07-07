using ATI.ProjectPrueba.Backend.Data;
using ATI.ProjectPrueba.Backend.Repositories.Implementation;
using ATI.ProjectPrueba.Backend.Repositories.Interfaces;
using ATI.ProjectPrueba.Backend.UnitsOfWork.Implementation;
using ATI.ProjectPrueba.Backend.UnitsOfWork.Interfaces;
using ATI.ProjectPrueba.Classlibrary.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=LocalConnection"));
builder.Services.AddTransient<SeedDb>();

builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();



builder.Services.AddScoped<IUsersUnitOfWork, UsersUnitOfWork>();
builder.Services.AddScoped<ICountriesUnitOfWork, CountriesUnitOfWork>();


builder.Services.AddIdentity<User, IdentityRole>( x =>
{
    x.User.RequireUniqueEmail = true;
    x.Password.RequireDigit = false;
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireLowercase = false;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;
    x.Password.RequiredLength = 6;
} )

    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();    



var app = builder.Build();
SeedData(app);

void SeedData(WebApplication app)
{
    var scopedFactory  = app.Services.GetService<IServiceScopeFactory>();

    using(var scope = scopedFactory!.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedDb>();
        service!.SeedAsync().Wait();
    }
}

app.UseCors(x => x
 .AllowAnyMethod()
 .AllowAnyHeader()
 .SetIsOriginAllowed(origin => true)
 .AllowCredentials());



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtKey"]!)),
        ClockSkew = TimeSpan.Zero

    });


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();        // ← agregar
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
