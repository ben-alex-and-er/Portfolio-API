using Database.Models;
using DTOs.Generic.Enums;
using Microsoft.EntityFrameworkCore;


namespace Portfolio_API.DataAccessors.Permissions
{
	using Interfaces;


	/// <summary>
	/// Data accessor for user.claim_types db table
	/// </summary>
	public class ClaimTypeDA : IClaimTypeDA
	{
		private readonly PortfolioContext context;


		/// <summary>
		/// Constructor for <see cref="ClaimTypeDA"/>
		/// </summary>
		/// <param name="context"></param>
		public ClaimTypeDA(PortfolioContext context)
		{
			this.context = context;
		}


		async Task<DAStatus> ICreate<string>.Create(string create)
		{
			var exists = await context.ClaimTypes
				.AnyAsync(type => type.Type == create);

			if (exists)
				return DAStatus.INVALID_ARGUMENTS;

			context.ClaimTypes.Add(new ClaimType
			{
				Type = create
			});

			await context.SaveChangesAsync();

			return DAStatus.SUCCESS;
		}
	}
}
