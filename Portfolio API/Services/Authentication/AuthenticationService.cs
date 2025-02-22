using DTOs.Authentication;
using DTOs.Authentication.Interfaces;
using DTOs.Generic.Enums;
using Microsoft.EntityFrameworkCore;


namespace Portfolio_API.Services.Authentication
{
	using DataAccessors.Authentication.Interfaces;
	using Interfaces;


	/// <summary>
	/// Service for authentication related operations
	/// </summary>
	public class AuthenticationService : IAuthenticationService
	{
		private readonly IPasswordDA passwordDA;

		private readonly IUserDA userDA;

		private readonly IUserPasswordDA userPasswordDA;


		/// <summary>
		/// Constructor for <see cref="AuthenticationService"/>
		/// </summary>
		/// <param name="passwordDA"></param>
		/// <param name="userDA"></param>
		/// <param name="userPasswordDA"></param>
		public AuthenticationService(
			IPasswordDA passwordDA,
			IUserDA userDA,
			IUserPasswordDA userPasswordDA)
		{
			this.passwordDA = passwordDA;
			this.userDA = userDA;
			this.userPasswordDA = userPasswordDA;
		}


		async Task<bool> IAuthenticationService.AddUser(ILogin request)
		{
			var user = await userDA.Create(request.Username);

			if (user != DAStatus.SUCCESS)
				return false;


			var password = await passwordDA.Create(request.Password);

			if (password != DAStatus.SUCCESS)
				return false;


			var userPassword = await userPasswordDA.Create(new LoginDTO(request.Username, request.Password));

			if (userPassword != DAStatus.SUCCESS)
				return false;


			return true;
		}


		Task<bool> IAuthenticationService.Login(ILogin request)
		{
			var correctAuth = userPasswordDA.Read()
				.Where(userPassword => userPassword.User == request.Username)
				.Where(userPassword => userPassword.Password == request.Password)
				.AnyAsync();

			return correctAuth;
		}
	}
}
