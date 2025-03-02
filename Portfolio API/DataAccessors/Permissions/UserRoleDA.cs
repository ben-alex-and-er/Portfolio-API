using Database.Models;
using DTOs.Permissions;
using Microsoft.EntityFrameworkCore;


namespace Portfolio_API.DataAccessors.Permissions
{
	using Interfaces;


	/// <summary>
	/// Data accessor for user.user_role db table
	/// </summary>
	public class UserRoleDA : IUserRoleDA
	{
		private readonly PortfolioContext context;


		/// <summary>
		/// Constructor for <see cref="UserRoleDA"/>
		/// </summary>
		/// <param name="context"></param>
		public UserRoleDA(PortfolioContext context)
		{
			this.context = context;
		}


		IQueryable<UserRoleDTO> IRead<UserRoleDTO>.Read()
			=> context.UserRoles
				.AsNoTracking()
				.Select(userRole => new UserRoleDTO
				{
					User = userRole.User.Identifier,
					Role = userRole.Role.Name
				});
	}
}
