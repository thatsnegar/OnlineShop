using DAL;
using Microsoft.EntityFrameworkCore;
using Parbad.Builder;
using Parbad.Gateway.Mellat;
using Parbad.Gateway.ParbadVirtual;

var builder = WebApplication.CreateBuilder(args);

// **************************************************
// **************************************************

#region Add Routing
builder.Services.AddRouting(options =>
{
	options.LowercaseUrls = true;
	options.LowercaseQueryStrings = true;

	//options.AppendTrailingSlash
	//options.SuppressCheckForUnhandledSecurityMetadata = false;
});

builder.Services.AddControllersWithViews();
#endregion

#region Add Connection String
// GetConnectionString() -> using Microsoft.Extensions.Configuration;
var connectionString =
	builder.Configuration.GetConnectionString(name: "DefaultConnection");

// AddDbContext -> using Microsoft.Extensions.DependencyInjection;
builder.Services.AddDbContext<DAL.DatabaseContext>
	(optionsAction: options =>
	{
		// Microsoft.EntityFrameworkCore.Proxies
		options.UseLazyLoadingProxies();

		// using Microsoft.EntityFrameworkCore;
		options.UseSqlServer(connectionString: connectionString);

		//options.UseMySql(connectionString: connectionString, null);

		builder.Services.AddSession(options =>
		{
			options.IdleTimeout = TimeSpan.FromMinutes(30);
			options.Cookie.IsEssential = true;
		});
	});
#endregion

#region Add Authentication
builder.Services
	.AddAuthentication(defaultScheme: Infrastructure.Security.Utility.AuthenticationScheme)
	.AddCookie(authenticationScheme: Infrastructure.Security.Utility.AuthenticationScheme, options =>
	{
		options.LoginPath = "/Account/Login";
		options.LogoutPath = "/Account/Logout";
		options.AccessDeniedPath = "/Account/Login";
        options.ExpireTimeSpan = TimeSpan.FromDays(10);
	});
#endregion

#region Add Database Context (Configure Unit of Work)
builder.Services.AddTransient<DAL.IUnitOfwork, DAL.UnitOfwork>(sp =>
{
	DAL.Tools.Options options =
		new(connectionString: connectionString)
		{
			Provider =
				(DAL.Tools.Enums.Provider)
				System.Convert.ToInt32(builder.Configuration.GetSection(key: "DatabaseProvider").Value),
		};

	return new DAL.UnitOfwork(options: options);
});
#endregion

#region Add Services (DI)
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<Services.IFilesService, Services.FileService>();
builder.Services.AddScoped<Services.SMS.ISmsService, Services.SMS.SmsService>();
builder.Services.AddHttpClient<GoogleReCaptcha.V3.Interface.ICaptchaValidator, GoogleReCaptcha.V3.GoogleReCaptchaValidator>();
builder.Services.AddParbad()
	.ConfigureGateways(gateways =>
{
	gateways.AddMellat()
	.WithAccounts(accounts =>
	{
		accounts.AddInMemory(account =>
		{
			account.TerminalId = 123;
			account.UserName = "Admin";
			account.UserPassword = "123";
		});
	});

	gateways
	.AddParbadVirtual()
	.WithOptions(options => options.GatewayPath = "/MyVirtualGateway");


})
	.ConfigureHttpContext(builder => builder.UseDefaultAspNetCore())
	.ConfigureStorage(builder => builder.UseMemoryCache());

#endregion

#region Add Settings Configure
// **************************************************
// Configure() -> using Microsoft.Extensions.DependencyInjection;

builder.Services.Configure
	<ViewModels.Settings.Domain>
	(builder.Configuration.GetSection(key: ViewModels.Settings.Domain.KeyName));

builder.Services.Configure
	<ViewModels.Settings.InfoCompany>
	(builder.Configuration.GetSection(key: ViewModels.Settings.InfoCompany.KeyName));

builder.Services.Configure
	<ViewModels.Settings.Popp>
	(builder.Configuration.GetSection(key: ViewModels.Settings.Popp.KeyName));

builder.Services.Configure
	<ViewModels.Settings.Smtp>
	(builder.Configuration.GetSection(key: ViewModels.Settings.Smtp.KeyName));

builder.Services.Configure
	<ViewModels.Settings.KavenegarInfo>
	(builder.Configuration.GetSection(key: ViewModels.Settings.KavenegarInfo.KeyName));
// ************************************************** 
#endregion

var app = builder.Build();
// **************************************************
// **************************************************

// **************************************************
// **************************************************
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");

	app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

//app.UseStatusCodePagesWithRedirects("Home/Error/{0}");

app.UseSession();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "admin",
		pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.UseParbadVirtualGateway();

app.Run();
// **************************************************
// **************************************************
