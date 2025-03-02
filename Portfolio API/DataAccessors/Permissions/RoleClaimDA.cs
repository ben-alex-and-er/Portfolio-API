using Database.Models;
using DTOs.Permissions;
using Microsoft.EntityFrameworkCore;


namespace Portfolio_API.DataAccessors.Permissions
{
	using Interfaces;


	/// <summary>
	/// Data accessor for user.role_claim db table
	/// </summary>
	public class RoleClaimDA : IRoleClaimDA
	{
		private readonly PortfolioContext context;


		/// <summary>
		/// Constructor for <see cref="RoleClaimDA"/>
		/// </summary>
		/// <param name="context"></param>
		public RoleClaimDA(PortfolioContext context)
		{
			this.context = context;
		}


		IQueryable<RoleClaimDTO> IRead<RoleClaimDTO>.Read()
			=> context.RoleClaims
				.AsNoTracking()
				.Select(roleClaim => new RoleClaimDTO
				{
					Role = roleClaim.Role.Name,
					Claim = new ClaimDTO
					{
						Type = roleClaim.Claim.ClaimType.Type,
						Value = roleClaim.Claim.ClaimValue.Value,
						Guid = roleClaim.Claim.Guid
					}
				});
	}
}
