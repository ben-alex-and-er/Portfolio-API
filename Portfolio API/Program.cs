using Portfolio_API.Configuration;
using Portfolio_API.Configuration.ServiceSetup;


internal class Program
{
	private static void AddServices(IHostApplicationBuilder builder)
	{
		builder.Services
			.AddServiceSetup<AuthenticationSetup>()
			.AddServiceSetup<DatabaseSetup>()
			.AddServiceSetup<PermissionsSetup>()
	}

	private static void Main(string[] args)
	{
		// Builder
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers();

		AddServices(builder);


		// App
		var app = builder.Build();

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}