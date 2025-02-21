using DTOs.Authentication.Interfaces;


namespace Portfolio_API.Services.Authentication
{
	using Interfaces;


	/// <summary>
	/// Service for authentication related operations
	/// </summary>
	public class AuthenticationService : IAuthenticationService
	{
		Task<bool> IAuthenticationService.Login(ILogin request)
		{
			throw new NotImplementedException();
		}
	}
}
