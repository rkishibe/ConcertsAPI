using ConcertsAPI.Controllers.Data;
using ConcertsAPI.Data;
using ConcertsAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddJWTTokenServices(builder.Configuration);

builder.Services.AddDbContext<ConcertContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<ConcertDTO, Concert>().ReverseMap();
    cfg.CreateMap<ArtistDTO, Artist>().ReverseMap();

}
) ;

builder.Services.AddSingleton<AutoMapper.IMapper>(s => config.CreateMapper());

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


app.UseAuthorization();

app.MapControllers();

app.Run();
