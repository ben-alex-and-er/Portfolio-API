using Database.Models;
using DTOs.Generic.Enums;
using DTOs.Permissions;
using Microsoft.EntityFrameworkCore;


namespace Portfolio_API.DataAccessors.Permissions
{
	using Interfaces;


	/// <summary>
	/// Data accessor for user.claim db table
	/// </summary>
	public class ClaimDA : IClaimDA
	{
		private readonly PortfolioContext context;

		private readonly IClaimTypeDA claimTypeDA;

		private readonly IClaimValueDA claimValueDA;


		/// <summary>
		/// Constructor for <see cref="ClaimDA"/>
		/// </summary>
		/// <param name="context"></param>
		/// <param name="claimTypeDA"></param>
		/// <param name="claimValueDA"></param>
		public ClaimDA(
			PortfolioContext context,
			IClaimTypeDA claimTypeDA,
			IClaimValueDA claimValueDA)
		{
			this.context = context;
			this.claimTypeDA = claimTypeDA;
			this.claimValueDA = claimValueDA;
		}


		async Task<DAStatus> ICreate<ClaimDTO>.Create(ClaimDTO create)
		{
			var typeValueExists = await context.Claims
				.Where(claim => claim.ClaimType.Type == create.Type)
				.Where(claim => claim.ClaimValue.Value == create.Value)
				.AnyAsync();

			var guidExists = await context.Claims
				.AnyAsync(claim => claim.Guid == create.Guid);

			if (typeValueExists || guidExists)
				return DAStatus.INVALID_ARGUMENTS;

			var typeEntry = await context.ClaimTypes
				.FirstOrDefaultAsync(type => type.Type == create.Type);

			if (typeEntry == null)
			{
				await claimTypeDA.Create(create.Type);
			}

			var valueEntry = await context.ClaimValues
				.FirstOrDefaultAsync(value => value.Value == create.Value);

			if (valueEntry == null)
			{
				await claimValueDA.Create(create.Value);
			}

			context.Claims.Add(new Claim
			{
				ClaimType = typeEntry,
				ClaimValue = valueEntry,
				Guid = create.Guid
			});

			await context.SaveChangesAsync();

			return DAStatus.SUCCESS;
		}
	}
}
