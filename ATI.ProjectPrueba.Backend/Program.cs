using ATI.ProjectPrueba.Backend.Data;
using ATI.ProjectPrueba.Backend.Repositories.Implementation;
using ATI.ProjectPrueba.Backend.Repositories.Interfaces;
using ATI.ProjectPrueba.Backend.UnitsOfWork.Implementation;
using ATI.ProjectPrueba.Backend.UnitsOfWork.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=LocalConnection"));
builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters
//    {
//       ValidateIssuer = false,
//       ValidateAudience = false,
//       ValidateLifetime = true,
//       ValidateIssuerSigningKey = true,
//       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwtKey"]!)),
//       ClockSkew = TimeSpan.Zero

//    });




var app = builder.Build();

app.UseCors(x => x
 .AllowAnyMethod()
 .AllowAnyHeader()
 .SetIsOriginAllowed(origin => true)
 .AllowCredentials());

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
