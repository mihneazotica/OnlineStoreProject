using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using OnlineStoreAPI.Extensions;
using OnlineStoreAPI.Helpers;
using OnlineStoreAPI.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddDbContext<StoreContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly(nameof(Infrastructure))));
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200", "https://192.168.1.227:4200","http://192.168.1.227:4200");
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{

    var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<StoreContext>();
        db.Database.Migrate();
    }
    catch (Exception ex)
    {
        logger.CreateLogger<Program>().LogError(ex, "An error occurred during migration");
    }

}

app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
