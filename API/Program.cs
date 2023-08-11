using API.Data;
using API.Entities;
using API.Middleware;
using API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(options =>
{
	// String connString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
	String connString = builder.Configuration.GetConnectionString("DefaultConnection");
	options.UseSqlite(connString);
});
builder.Services.AddCors(options =>
	{
		options.AddPolicy("CorsPolicy",
			builder => builder
				.AllowAnyMethod()
				.AllowAnyHeader()
				.AllowCredentials()
				.WithOrigins("http://localhost:3000"));
	});
builder.Services.AddIdentityCore<User>(option =>
{
	option.User.RequireUniqueEmail = true;
})
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<StoreContext>();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddScoped<TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
try
{
	await context.Database.MigrateAsync();
	await DbInitializer.Initialize(context, userManager);
}
catch (Exception ex)
{
	logger.LogError(ex, "A problem occured during migration");
}

app.Run();
