var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") 
                .WithOrigins("http://slam-fundao.vercel.app")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
var app = builder.Build();

app.UseCors("AllowReactApp");

app.UseAuthorization();
app.MapControllers();
app.Run();
