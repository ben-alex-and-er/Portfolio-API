using DTOs.Generic.Enums;
using Microsoft.EntityFrameworkCore;


namespace Portfolio_API.DataAccessors.Authentication
{
	using Database.Models;
	using Interfaces;


	/// <summary>
	/// Data accessor for user.user db table
	/// </summary>
	public class UserDA : IUserDA
	{
		private readonly PortfolioContext context;


		/// <summary>
		/// Constructor for <see cref="UserDA"/>
		/// </summary>
		/// <param name="context"></param>
		public UserDA(PortfolioContext context)
		{
			this.context = context;
		}


		async Task<DAStatus> ICreate<string>.Create(string create)
		{
			var exists = await context.Users
				.AnyAsync(user => user.Identifier == create);

			if (exists)
				return DAStatus.INVALID_ARGUMENTS;

			context.Users.Add(new User
			{
				Identifier = create,
			});

			await context.SaveChangesAsync();

			return DAStatus.SUCCESS;
		}
	}
}
