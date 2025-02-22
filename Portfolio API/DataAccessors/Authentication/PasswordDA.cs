using Database.Models;
using DTOs.Authentication;
using DTOs.Generic.Enums;
using Microsoft.EntityFrameworkCore;


namespace Portfolio_API.DataAccessors.Authentication
{
	using Interfaces;


	/// <summary>
	/// Data accessor for user.password db table
	/// </summary>
	public class PasswordDA : IPasswordDA
	{
		private readonly PortfolioContext context;


		/// <summary>
		/// Constructor for <see cref="UserDA"/>
		/// </summary>
		/// <param name="context"></param>
		public PasswordDA(PortfolioContext context)
		{
			this.context = context;
		}


		async Task<DAStatus> ICreate<HashedPassword>.Create(HashedPassword create)
		{
			var exists = await context.Passwords
				.AnyAsync(user => user.Hash == create.Hash);

			if (exists)
				return DAStatus.INVALID_ARGUMENTS;

			context.Passwords.Add(new Password
			{
				Hash = create.Hash,
			});

			await context.SaveChangesAsync();

			return DAStatus.SUCCESS;
		}

		async Task<DAStatus> IUpdate<HashedPassword, HashedPassword>.Update(HashedPassword identifer, HashedPassword newValue)
		{
			var entry = await context.Passwords
				.FirstOrDefaultAsync(password => password.Hash == identifer.Hash);

			if (entry == null)
				return DAStatus.INVALID_ARGUMENTS;

			entry.Hash = newValue.Hash;

			await context.SaveChangesAsync();

			return DAStatus.SUCCESS;
		}
	}
}
