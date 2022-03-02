global using Serilog;
using ProjDL;
using ProjBL;


var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt")
    .CreateLogger();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository>(repo => new SQLRepository(builder.Configuration.GetConnectionString("KeyValue1")));
builder.Services.AddScoped<ICustomerBL, CustomerBL>();
builder.Services.AddScoped<IStoreBL, StoreBL>();


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
