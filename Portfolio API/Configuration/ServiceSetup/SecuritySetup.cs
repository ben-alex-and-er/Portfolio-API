namespace Portfolio_API.Configuration.ServiceSetup
{
	using Configuration.Data;
	using Interfaces;
	using Providers.Security;
	using Providers.Security.Interfaces;


	/// <summary>
	/// Setup for security related services
	/// </summary>
	public class SecuritySetup : IServiceRegister
	{
		void IServiceRegister.RegisterServices(IServiceCollection services)
		{
			services.AddSingleton<JwtCredentials>();
			services.AddSingleton<IJwtTokenHandler, JwtTokenHandler>();
		}
	}
}
