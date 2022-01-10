using FullStackAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var myCors= "myCrossOrigin";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<APIDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIConnection"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myCors,
        builder =>{
            builder.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader();
});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(myCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
