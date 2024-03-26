using SheepManager.WebAPI.StartupExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHsts();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.UseRouting();
app.MapControllers();

app.Run();

public partial class Program { }
