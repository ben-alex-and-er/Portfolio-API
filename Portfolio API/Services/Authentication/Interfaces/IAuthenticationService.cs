using DTOs.Authentication.Interfaces;


namespace Portfolio_API.Services.Authentication.Interfaces
{
	/// <summary>
	/// Interface for <see cref="AuthenticationService"/>
	/// </summary>
	public interface IAuthenticationService
	{
		/// <summary>
		/// Login a user using username and password
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		Task<bool> Login(ILogin request);
	}
}
