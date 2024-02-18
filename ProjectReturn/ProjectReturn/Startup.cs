using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ProjectReturn.Data;
using ProjectReturn.Data.Interfaces;
using ProjectReturn.Data.Repository;
using ProjectReturn.Data.Model;

namespace ProjectReturn;

public class Startup
{
    private IConfigurationRoot _confSting;

	public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv)
    {
        _confSting = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {
		services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confSting.GetConnectionString("DefaultConnection")));
		services.AddTransient<IAllCars, CarRepository>();
        services.AddTransient<ICarsCategory, CategoryRepository>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
		services.AddScoped(sp => ShopCart.GetCart(sp));


		services.AddMvc();
		services.Configure<MvcOptions>(options =>
		{
			options.EnableEndpointRouting = false;
		});
		services.AddMemoryCache();
		services.AddSession();
	}

    public void Configure(IApplicationBuilder app)
    {
        app.UseDeveloperExceptionPage();
        app.UseStatusCodePages();
		app.UseStaticFiles();
		app.UseSession();
		app.UseMvcWithDefaultRoute();

		using (var scope = app.ApplicationServices.CreateScope())
		{
			AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
			DBObjects.Initial(content);
		}
	}
}