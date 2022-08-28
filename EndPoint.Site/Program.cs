using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FluentValidation.AspNetCore;
using FluentValidation;
using NLog;
using NLog.Web;


var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
//var logger1 = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();	

try 
{
	logger.Debug("init main");
	
	var builder = WebApplication.CreateBuilder(args);

	builder.Logging.ClearProviders();
	builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
	builder.Host.UseNLog();


	builder.Services.AddRazorPages();

	var connectionString =
		builder.Configuration.GetConnectionString(name: "ConnectionString");

	// AddDbContext -> using Microsoft.Extensions.DependencyInjection;
	builder.Services.AddDbContext<CRUD.Persistance.Contexts.DataBaseContext>
		(optionsAction: options =>
		{
			options
				// using Microsoft.EntityFrameworkCore.Proxies;
				.UseLazyLoadingProxies();

			options
				// using Microsoft.EntityFrameworkCore.SqlServer
				.UseSqlServer(connectionString: connectionString);
		});

	builder.Services.AddAutoMapper(typeof(CRUD.Infrastructure.AutoMapperProfiles.RoleProfile));



	builder.Services.AddValidatorsFromAssemblyContaining<CRUD.Domain.Validators.HiValidator>();
	builder.Services.AddFluentValidationAutoValidation();
	builder.Services.AddFluentValidationClientsideAdapters();


	//builder.Services.AddFluentValidation(Current =>
	//{
	//	Current.RegisterValidatorsFromAssemblyContaining<CRUD.Domain.Validators.HiValidator>();
	//	Current.LocalizationEnabled = true;	
	//	Current.AutomaticValidationEnabled = true;	
	//	Current.ImplicitlyValidateChildProperties = false;
	//	Current.ImplicitlyValidateRootCollectionElements = false;	
	//});	

	
	
	var app = builder.Build();

	app.UseHttpsRedirection();

	app.UseStaticFiles();

	app.MapRazorPages();

	app.Run();
	

}
catch (Exception ex) 
{
	logger.Error(ex,"stop program because of exception");
	throw;
}
finally 
{
	NLog.LogManager.Shutdown();
}	


