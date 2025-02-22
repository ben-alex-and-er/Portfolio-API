using DTOs.Authentication;


namespace Portfolio_API.DataAccessors.Authentication.Interfaces
{
	/// <summary>
	/// Interface for <see cref="UserPasswordDA"/>
	/// </summary>
	public interface IUserPasswordDA : ICreate<UserHashedPasswordDTO>, IRead<UserHashedPasswordDTO>
	{

	}
}
