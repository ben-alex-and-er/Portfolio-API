using DTOs.Generic.Enums;
using DTOs.Permissions;
using DTOs.Permissions.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Portfolio_API.Services.Permissions
{
	using DataAccessors.Permissions.Interfaces;
	using Interface;
	using Providers.Database.Interfaces;


	/// <summary>
	/// Service for claims
	/// </summary>
	public class ClaimService : IClaimService
	{
		private readonly ITransactionManager transactionManager;

		private readonly IClaimDA claimDA;


		/// <summary>
		/// Constructor for <see cref="ClaimService"/>
		/// </summary>
		/// <param name="transactionManager"></param>
		/// <param name="claimDA"></param>
		public ClaimService(ITransactionManager transactionManager, IClaimDA claimDA)
		{
			this.transactionManager = transactionManager;
			this.claimDA = claimDA;
		}


		async Task<bool> IClaimService.AddClaims(IAddClaims addClaims)
		{
			using var transaction = await transactionManager.CreateTransactionAsync();

			foreach (var requiredClaim in addClaims.Claims)
			{
				var exists = await claimDA.Read()
					.Where(claim => claim.Type == requiredClaim.Type)
					.Where(claim => claim.Value == requiredClaim.Value)
					.AnyAsync();

				if (exists)
					continue;

				var claimDTO = new ClaimDTO(requiredClaim.Type, requiredClaim.Value, Guid.NewGuid());

				var createClaim = await claimDA.Create(claimDTO);

				if (createClaim != DAStatus.SUCCESS)
					return false;
			}

			transaction.Commit();

			return true;
		}
	}
}
