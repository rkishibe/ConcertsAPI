using ConcertsAPI.Controllers.Data;
using Microsoft.EntityFrameworkCore;
using ConcertsAPI.Data;
using ConcertsAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ConcertsAPI.Helpers;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ConcertContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// add authentication configuration
builder.Services.AddJWTTokenServices(builder.Configuration);

#region automapping configuration
var config = new AutoMapper.MapperConfiguration(cfg => {
    cfg.CreateMap<ConcertDTO, Concert>()
            
        ;
    cfg.CreateMap<ArtistDTO, ConcertsAPI.Models.Artist>()
        .ReverseMap()
        ;
});
builder.Services.AddSingleton<AutoMapper.IMapper>(s => config.CreateMapper());
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(options => {
//    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
//    {
//        Name = "Authorization",
//        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
//        Description = "JWT Authorization header using the Bearer scheme."
//    });
//    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
//        {
//            new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
//                    Reference = new Microsoft.OpenApi.Models.OpenApiReference {
//                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
//                            Id = "Bearer"
//                    }
//                },
//                new string[] {}
//        }
//    });
//});
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
// {
//     opt.Audience = builder.Configuration["AAD:ResourceId"];
//     opt.Authority = $"{builder.Configuration["AAD:Instance"]}{builder.Configuration["AAD:TenantId"]}";
// });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();