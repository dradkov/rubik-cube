using RubikCubeApi.Services;
using RubikCubeApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // ✅ Required for controllers
builder.Services.AddEndpointsApiExplorer(); // ✅ Required for Swagger
builder.Services.AddSwaggerGen(); // ✅ Ensure Swagger is added

// Register services
builder.Services.AddScoped<IRubikCubeService, RubikCubeService>();
builder.Services.AddScoped<IPrintService, PrintService>();
builder.Services.AddScoped<ICubeService, CubeService>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) // Enable Swagger only in Development
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers(); // ✅ Make sure this is present

app.Run();