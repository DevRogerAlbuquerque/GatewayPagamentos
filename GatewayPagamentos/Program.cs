var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") 
                .WithOrigins("http://slam-fundao.vercel.app")
                .WithOrigins("https://slamfundao.com.br")
                .WithOrigins("https://www.slamfundao.com.br")
                .WithOrigins("http://www.api.slamfundao.com.br")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

builder.Services.AddControllers();
var app = builder.Build();
app.Urls.Add($"http://*:{port}");

app.UseCors("AllowReactApp");

app.UseAuthorization();
app.MapControllers();
app.Run();
