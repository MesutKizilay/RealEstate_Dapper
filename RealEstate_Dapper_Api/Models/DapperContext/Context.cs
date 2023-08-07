using Microsoft.Data.SqlClient;
using System.Data;

namespace RealEstate_Dapper_Api.Models.DapperContext
{
	public class Context
	{
		readonly IConfiguration _configuration;
		readonly string _connectionString;

		public Context(IConfiguration configuration)
		{
			_configuration = configuration;
			_connectionString = _configuration.GetConnectionString("connection");
		}

		public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
	}
}