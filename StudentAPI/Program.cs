using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using StudentAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudentDBContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IStudentService,StudentService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
DBInitializer.Initializer(app.Services.CreateScope().ServiceProvider.GetRequiredService<StudentDBContext>());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
