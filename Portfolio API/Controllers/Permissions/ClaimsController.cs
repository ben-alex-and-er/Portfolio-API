using Microsoft.AspNetCore.Mvc;
using Requests.Permissions;


namespace Portfolio_API.Controllers.Permissions
{
	using Services.Permissions.Interface;


	/// <summary>
	/// Controller for claims related operations
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class ClaimsController
	{
		private readonly IClaimService claimService;


		/// <summary>
		/// Constructor for <see cref="ClaimsController"/>
		/// </summary>
		/// <param name="claimService"></param>
		public ClaimsController(IClaimService claimService)
		{
			this.claimService = claimService;
		}


		/// <summary>
		/// Adds new claims to db
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		[HttpPost("addclaims")]
		public Task<bool> AddClaims(AddClaimsRequest request)
			=> claimService.AddClaims(request);
	}
}
