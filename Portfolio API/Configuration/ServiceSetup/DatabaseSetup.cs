using Database.Models;
using Microsoft.EntityFrameworkCore;


namespace Portfolio_API.Configuration.ServiceSetup
{
	using Data;
	using Interfaces;
	using Providers.Database;
	using Providers.Database.Interfaces;


	/// <summary>
	/// Setup for mysql database
	/// </summary>
	public class DatabaseSetup : IServiceRegister
	{
		void IServiceRegister.RegisterServices(IServiceCollection services)
		{
			services.AddSingleton<MySQLConnection>();


			services.AddDbContext<PortfolioContext>(options =>
			{
				var connection = services.BuildServiceProvider().GetRequiredService<MySQLConnection>();

				options.UseMySql(connection.ToString(), ServerVersion.AutoDetect(connection.ToString()));
			});

			services.AddTransient<ITransactionManager, TransactionManager>();
		}
	}
}
