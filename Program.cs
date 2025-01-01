using CommentApi.Models;
using CommentApi.Services;

var builder = WebApplication.CreateBuilder(args);

var mongoConnectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");
var mongoDatabaseName = Environment.GetEnvironmentVariable("MONGODB_DATABASE_NAME");

if (string.IsNullOrEmpty(mongoConnectionString) || string.IsNullOrEmpty(mongoDatabaseName))
{
    throw new InvalidOperationException("MongoDB connection string or database name is missing.");
}

// Add services to the container.
builder.Services.Configure<CommentDatabaseSettings>(options =>
{
    options.ConnectionString = mongoConnectionString;
    options.DatabaseName = mongoDatabaseName;
});

builder.Services.AddSingleton<CommentsService>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
