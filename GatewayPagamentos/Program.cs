using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy
                .SetIsOriginAllowed(origin =>
                {
                    if (string.IsNullOrEmpty(origin))
                        return false;
                    
                    var regex = new Regex(@"^https?:\/\/([a-zA-Z0-9-]+\.)*slamfundao\.com\.br$", RegexOptions.IgnoreCase);

                    if (origin.Contains("slam-fundao.vercel.app", StringComparison.OrdinalIgnoreCase))
                        return true;

                    if (origin.StartsWith("http://localhost", StringComparison.OrdinalIgnoreCase))
                        return true;
                    
                    return regex.IsMatch(origin);
                })
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
