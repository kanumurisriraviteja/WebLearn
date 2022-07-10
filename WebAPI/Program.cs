var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
        builder =>
        {
            // builder.WithOrigins("http://localhost:4200", "http://192.168.29.159", "http://192.168.29.159:8080/",
            //                     "http://127.0.0.1:8080","http://172.30.16.1:8080","http://172.29.160.1:8080")
            //                     .AllowAnyHeader()
            //                     .AllowAnyMethod();
             builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
var app = builder.Build();

app.UseCors("MyAllowedOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
