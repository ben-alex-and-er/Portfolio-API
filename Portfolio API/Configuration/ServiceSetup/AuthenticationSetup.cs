using Microsoft.AspNetCore.Identity;


namespace Portfolio_API.Configuration.ServiceSetup
{
	using DataAccessors.Authentication;
	using DataAccessors.Authentication.Interfaces;
	using Interfaces;
	using Providers.Authentication;
	using Providers.Authentication.Interfaces;
	using Services.Authentication;
	using Services.Authentication.Interfaces;


	/// <summary>
	/// Setup for authentication related services
	/// </summary>
	public class AuthenticationSetup : IServiceRegister
	{
		void IServiceRegister.RegisterServices(IServiceCollection services)
		{
			services.AddTransient<IPasswordDA, PasswordDA>();
			services.AddTransient<IUserDA, UserDA>();
			services.AddTransient<IUserPasswordDA, UserPasswordDA>();

			services.AddTransient<IAuthenticationService, AuthenticationService>();

			services.AddSingleton<IPasswordHasher<string>, PasswordHasher<string>>();
			services.AddSingleton<IHasher, Hasher>();
		}
	}
}
