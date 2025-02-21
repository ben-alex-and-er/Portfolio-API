namespace Portfolio_API.Configuration.ServiceSetup
{
	using Interfaces;
	using Services.Authentication;
	using Services.Authentication.Interfaces;


	/// <summary>
	/// Setup for authentication related services
	/// </summary>
	public class AuthenticationSetup : IServiceRegister
	{
		void IServiceRegister.RegisterServices(IServiceCollection services)
		{
			services.AddTransient<IAuthenticationService, AuthenticationService>();
		}
	}
}
