using Database.Models;
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


		async Task<DAStatus> ICreate<string>.Create(string create)
		{
			var exists = await context.Passwords
				.AnyAsync(user => user.Hash == create);

			if (exists)
				return DAStatus.INVALID_ARGUMENTS;

			context.Passwords.Add(new Password
			{
				Hash = create,
			});

			await context.SaveChangesAsync();

			return DAStatus.SUCCESS;
		}
	}
}
