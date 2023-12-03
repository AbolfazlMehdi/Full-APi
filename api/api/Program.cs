using api.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); 


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>((x, u) =>
{
    var connectionString = x
        .GetRequiredService<IConfiguration>()
        .GetConnectionString("dbContext");

    u.UseSqlServer(connectionString);
});


var app = builder.Build();
app.UseAPiCors(app.Configuration);


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
