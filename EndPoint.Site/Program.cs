using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;




var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddAutoMapper(typeof(Program));	

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapRazorPages();

app.Run();
