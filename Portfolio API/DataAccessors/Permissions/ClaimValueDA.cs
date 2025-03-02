using Database.Models;
using DTOs.Generic.Enums;
using Microsoft.EntityFrameworkCore;


namespace Portfolio_API.DataAccessors.Permissions
{
	using Interfaces;


	/// <summary>
	/// Data accessor for user.claim_value db table
	/// </summary>
	public class ClaimValueDA : IClaimValueDA
	{
		private readonly PortfolioContext context;


		/// <summary>
		/// Constructor for <see cref="ClaimValueDA"/>
		/// </summary>
		/// <param name="context"></param>
		public ClaimValueDA(PortfolioContext context)
		{
			this.context = context;
		}


		async Task<DAStatus> ICreate<string>.Create(string create)
		{
			var exists = await context.ClaimValues
				.AnyAsync(type => type.Value == create);

			if (exists)
				return DAStatus.INVALID_ARGUMENTS;

			context.ClaimValues.Add(new ClaimValue
			{
				Value = create
			});

			await context.SaveChangesAsync();

			return DAStatus.SUCCESS;
		}
	}
}
