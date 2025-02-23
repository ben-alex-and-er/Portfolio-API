using DTOs.Authentication;
using DTOs.Authentication.Interfaces;
using DTOs.Generic.Enums;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;


namespace Portfolio_API.Services.Authentication
{
	using DataAccessors.Authentication.Interfaces;
	using Interfaces;
	using Providers.Authentication;
	using Providers.Database.Interfaces;


	/// <summary>
	/// Service for authentication related operations
	/// </summary>
	public class AuthenticationService : IAuthenticationService
	{
		private readonly ITransactionManager transactionManager;

		private readonly IPasswordDA passwordDA;

		private readonly IUserDA userDA;

		private readonly IUserPasswordDA userPasswordDA;


		/// <summary>
		/// Constructor for <see cref="AuthenticationService"/>
		/// </summary>
		/// <param name="transactionManager"></param>
		/// <param name="passwordDA"></param>
		/// <param name="userDA"></param>
		/// <param name="userPasswordDA"></param>
		public AuthenticationService(
			ITransactionManager transactionManager,
			IPasswordDA passwordDA,
			IUserDA userDA,
			IUserPasswordDA userPasswordDA)
		{
			this.transactionManager = transactionManager;
			this.passwordDA = passwordDA;
			this.userDA = userDA;
			this.userPasswordDA = userPasswordDA;
		}


		async Task<bool> IAuthenticationService.AddUser(ILogin request)
		{
			using var transaction = await transactionManager.CreateTransactionAsync();


			var user = await userDA.Create(request.Username);

			if (user != DAStatus.SUCCESS)
				return false;


			var hashedPassword = PasswordHasher.HashPassword(request.Password);

			var password = await passwordDA.Create(hashedPassword);

			if (password != DAStatus.SUCCESS)
				return false;


			var userPassword = await userPasswordDA.Create(new UserHashedPasswordDTO(request.Username, hashedPassword));

			if (userPassword != DAStatus.SUCCESS)
				return false;


			await transaction.CommitAsync();

			return true;
		}


		async Task<bool> IAuthenticationService.Login(ILogin request)
		{
			var userPassword = await userPasswordDA.Read()
				.Where(userPassword => userPassword.User == request.Username)
				.FirstOrDefaultAsync();

			if (userPassword == null)
				return false;


			var verifyPassword = PasswordHasher.VerifyPassword(request.Password, userPassword.HashedPassword);

			return verifyPassword;
		}
	}
}
