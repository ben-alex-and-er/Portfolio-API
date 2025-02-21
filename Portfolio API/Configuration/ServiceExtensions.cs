using Portfolio_API.Configuration.ServiceSetup.Interfaces;

namespace Portfolio_API.Configuration
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddServiceSetup<T>(this IServiceCollection services) where T : IServiceRegister, new()
		{
			var register = new T();

			register.RegisterServices(services);

			return services;
		}
	}
}
