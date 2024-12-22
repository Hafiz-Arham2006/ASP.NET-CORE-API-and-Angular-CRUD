using crud_api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiCrudContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
builder.Services.AddMvc();
builder.Services.AddCors(cor => cor.AddPolicy("api",x=>x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("api");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
