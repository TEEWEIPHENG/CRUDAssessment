using CRUDAssessment.Helper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DBAccess>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CRUDAssessmentCS"))
);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//allow localhost client request
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
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

app.UseAuthorization();

app.MapControllers();

//allow localhost  client request
app.UseCors();

app.Run();
