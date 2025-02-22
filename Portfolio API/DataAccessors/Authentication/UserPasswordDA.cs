using Database.Models;
using DTOs.Authentication;
using DTOs.Generic.Enums;
using Microsoft.EntityFrameworkCore;


namespace Portfolio_API.DataAccessors.Authentication
{
	using Interfaces;


	/// <summary>
	/// Data accessor for user_password db table
	/// </summary>
	public class UserPasswordDA : IUserPasswordDA
	{
		private readonly PortfolioContext context;


		/// <summary>
		/// Constructor for <see cref="UserPasswordDA"/>
		/// </summary>
		/// <param name="context"></param>
		public UserPasswordDA(PortfolioContext context)
		{
			this.context = context;
		}


		async Task<DAStatus> ICreate<LoginDTO>.Create(LoginDTO create)
		{
			var userEntry = await context.Users
				.FirstOrDefaultAsync(identifier => identifier.Identifier == create.User);

			if (userEntry == null)
				return DAStatus.INVALID_ARGUMENTS;

			var passwordEntry = await context.Passwords
				.FirstOrDefaultAsync(password => password.Hash == create.Password);

			if (passwordEntry == null)
				return DAStatus.INVALID_ARGUMENTS;


			context.UserPasswords.Add(new UserPassword
			{
				User = userEntry,
				Password = passwordEntry
			});


			await context.SaveChangesAsync();


			return DAStatus.SUCCESS;
		}

		IQueryable<LoginDTO> IRead<LoginDTO>.Read()
			=> context.UserPasswords
				.AsNoTracking()
				.Select(userPassword => new LoginDTO
				{
					User = userPassword.User.Identifier,
					Password = userPassword.Password.Hash,
				});
	}
}
