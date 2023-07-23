using LMS_App.LMSDBContext;
using LMS_App.LoanInterface;
using LMS_App.LoanService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog;
using ServiceStack;

var builder = WebApplication.CreateBuilder(args);

//Logger 
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.
builder.Services.AddDbContext<LMSContext>(options => {
    var conn = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(conn);
});

//builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddTransient<ILoanService, LoanService>();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//logger


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

//logger


