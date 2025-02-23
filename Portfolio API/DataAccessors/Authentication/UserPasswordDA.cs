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


		async Task<DAStatus> ICreate<UserHashedPasswordDTO>.Create(UserHashedPasswordDTO create)
		{
			var userEntry = await context.Users
				.FirstOrDefaultAsync(identifier => identifier.Identifier == create.User);

			if (userEntry == null)
				return DAStatus.INVALID_ARGUMENTS;

			var passwordEntry = await context.Passwords
				.FirstOrDefaultAsync(password => password.Hash == create.HashedPassword.ToString());

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

		IQueryable<UserHashedPasswordDTO> IRead<UserHashedPasswordDTO>.Read()
			=> context.UserPasswords
				.AsNoTracking()
				.Select(userPassword => new UserHashedPasswordDTO
				{
					User = userPassword.User.Identifier,
					HashedPassword = new(userPassword.Password.Hash),
				});
	}
}
