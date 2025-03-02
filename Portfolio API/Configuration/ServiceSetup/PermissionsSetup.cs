namespace Portfolio_API.Configuration.ServiceSetup
{
	using DataAccessors.Permissions;
	using DataAccessors.Permissions.Interfaces;
	using Interfaces;
	using Services.Permissions;
	using Services.Permissions.Interface;


	/// <summary>
	/// Setup for permissions related services
	/// </summary>
	public class PermissionsSetup : IServiceRegister
	{
		void IServiceRegister.RegisterServices(IServiceCollection services)
		{
			services.AddTransient<IClaimDA, ClaimDA>();
			services.AddTransient<IClaimTypeDA, ClaimTypeDA>();
			services.AddTransient<IClaimValueDA, ClaimValueDA>();
			services.AddTransient<IRoleClaimDA, RoleClaimDA>();
			services.AddTransient<IUserRoleDA, UserRoleDA>();

			services.AddTransient<IClaimService, ClaimService>();
		}
	}
}
