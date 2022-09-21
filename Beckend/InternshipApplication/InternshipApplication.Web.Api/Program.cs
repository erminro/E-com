using InternshipApplication.Web.Core.Dto.Profiles;
using InternshipApplication.Web.Core.Interfaces;
using InternshipApplication.Web.Core.Queries.Users;
using InternshipApplication.Web.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(typeof(GetUserQuery).Assembly);
builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);
builder.Services.AddDbContext<DataContext>((options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
