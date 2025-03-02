using DTOs.Authentication;
using DTOs.Authentication.Interfaces;
using DTOs.Generic.Enums;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Responses.Authentication;
using Responses.Authentication.Enums;
using System.Security.Claims;


namespace Portfolio_API.Services.Authentication
{
	using DataAccessors.Authentication.Interfaces;
	using DataAccessors.Permissions.Interfaces;
	using Interfaces;
	using Providers.Authentication;
	using Providers.Database.Interfaces;
	using Providers.Security.Interfaces;


	/// <summary>
	/// Service for authentication related operations
	/// </summary>
	public class AuthenticationService : IAuthenticationService
	{
		private readonly IJwtTokenHandler jwtTokenHandler;

		private readonly ITransactionManager transactionManager;

		private readonly IPasswordDA passwordDA;

		private readonly IRoleClaimDA roleClaimDA;

		private readonly IUserDA userDA;

		private readonly IUserPasswordDA userPasswordDA;

		private readonly IUserRoleDA userRoleDA;


		/// <summary>
		/// Constructor for <see cref="AuthenticationService"/>
		/// </summary>
		/// <param name="jwtTokenHandler"></param>
		/// <param name="transactionManager"></param>
		/// <param name="passwordDA"></param>
		/// <param name="roleClaimDA"></param>
		/// <param name="userDA"></param>
		/// <param name="userPasswordDA"></param>
		/// <param name="userRoleDA"></param>
		public AuthenticationService(
			IJwtTokenHandler jwtTokenHandler,
			ITransactionManager transactionManager,
			IPasswordDA passwordDA,
			IRoleClaimDA roleClaimDA,
			IUserDA userDA,
			IUserPasswordDA userPasswordDA,
			IUserRoleDA userRoleDA)
		{
			this.jwtTokenHandler = jwtTokenHandler;
			this.transactionManager = transactionManager;
			this.passwordDA = passwordDA;
			this.roleClaimDA = roleClaimDA;
			this.userDA = userDA;
			this.userPasswordDA = userPasswordDA;
			this.userRoleDA = userRoleDA;
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


		async Task<LoginResponse> IAuthenticationService.Login(ILogin request)
		{
			var userPassword = await userPasswordDA.Read()
				.Where(userPassword => userPassword.User == request.Username)
				.FirstOrDefaultAsync();

			if (userPassword == null)
				return new LoginResponse(LoginResponseStatus.USER_NOT_FOUND);


			var verifyPassword = PasswordHasher.VerifyPassword(request.Password, userPassword.HashedPassword);

			if (!verifyPassword)
				return new LoginResponse(LoginResponseStatus.INCORRECT_PASSWORD);


			var roles = userRoleDA.Read()
				.Where(userRole => userRole.User == request.Username)
				.Select(userRole => userRole.Role);

			var claims = roleClaimDA.Read()
				.Where(roleClaim => roles.Contains(roleClaim.Role))
				.Select(roleClaim => new Claim(roleClaim.Claim.Type, roleClaim.Claim.Value))
				.AsEnumerable();

			var tokenClaims = claims.Prepend(new Claim(ClaimTypes.NameIdentifier, request.Username));

			var tokenString = jwtTokenHandler.CreateToken(tokenClaims);

			return new LoginResponse(LoginResponseStatus.SUCCESS, tokenString);
		}
	}
}
