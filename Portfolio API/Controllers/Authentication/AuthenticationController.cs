using Microsoft.AspNetCore.Mvc;
using Requests.Authentication;
using Responses.Authentication;


namespace Portfolio_API.Controllers.Authentication
{
	using Services.Authentication.Interfaces;


	/// <summary>
	/// Controller for authetication related operations
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class AuthenticationController : ControllerBase
	{
		private readonly IAuthenticationService authenticationService;


		/// <summary>
		/// Constructor for <see cref="AuthenticationController"/>
		/// </summary>
		/// <param name="authenticationService"></param>
		public AuthenticationController(IAuthenticationService authenticationService)
		{
			this.authenticationService = authenticationService;
		}


		/// <summary>
		/// Adds a new user to the system
		/// </summary>
		/// <param name="loginRequest"></param>
		/// <returns></returns>
		[HttpPost("adduser")]
		public Task<bool> AddUser(LoginRequest loginRequest)
			=> authenticationService.AddUser(loginRequest);


		/// <summary>
		/// Login a user using username and password
		/// </summary>
		/// <param name="loginRequest"></param>
		/// <returns></returns>
		[HttpPost("login")]
		public Task<LoginResponse> Login(LoginRequest loginRequest)
			=> authenticationService.Login(loginRequest);
	}
}
