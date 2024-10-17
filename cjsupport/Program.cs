using Microsoft.EntityFrameworkCore;
using cjsupport.Data;
using cjsupport.Domain.Services.Interfaces;
using cjsupport.Domain.Services;
using cjsupport.Data.Repositories.Interfaces;
using cjsupport.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
var congfiguration = builder.Configuration;

//add dbcontext
builder.Services.AddDbContext<CjsupportDbContext>
    (options => options.UseNpgsql(congfiguration.GetConnectionString("DefaultConnection")));

//add repos and services
builder.Services.AddScoped<ISupportTicketRepository, SupportTicketRepository>();
builder.Services.AddScoped<ISupportTicketService, SupportTicketService>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
