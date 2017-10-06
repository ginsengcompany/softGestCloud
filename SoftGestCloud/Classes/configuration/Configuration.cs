using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SoftGestCloud;
using SQLite;
using Utility;

namespace Configuration
{
	public class ConfigurationPresentation
	{

		public static async Task<List<Configuration>> GetConfiguration()
		{
			ConfigurationDelegate instanza = ConfigurationDelegate.Instance;

			return await instanza.GetConfiguration();
		}

		public static async Task<Configuration> GetConfiguration(string token)
		{
			ConfigurationDelegate instanza = ConfigurationDelegate.Instance;

			return await instanza.GetConfiguration(token);
		}


		public static async Task<int> Salva(Configuration configuration)
		{
			ConfigurationDelegate instanza = ConfigurationDelegate.Instance;
			return await instanza.Salva(configuration);
		}
	}

	public class ConfigurationDelegate
	{
		private static ConfigurationDelegate instance = null;
		private ConfigurationDB dao = null;

		// Do you prefer a Property?
		public static ConfigurationDelegate Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ConfigurationDelegate();
				}
				return instance;
			}
		}

		private ConfigurationDelegate()
		{
			this.dao = new ConfigurationDB();
		}

		public async Task<List<Configuration>> GetConfiguration()
		{
			return await dao.GetConfiguration();
		}

		public async Task<Configuration> GetConfiguration(string token)
		{
			var returnValue = await dao.GetConfigurationByToken(token);
			return returnValue;
		}


		public async Task<int> Salva(Configuration configuration)
		{
			var returnValue = await dao.Salva(configuration);
			return returnValue;
		}
	}

	public class ConfigurationDB
	{
		private SQLiteAsyncConnection connection = App.GetDatabase.GetConnection();

		public ConfigurationDB()
		{
			connection.CreateTableAsync<Configuration>().Wait();
		}

		public Task<List<Configuration>> GetConfiguration()
		{
			return connection.Table<Configuration>().ToListAsync();
		}

		public Task<Configuration> GetConfigurationByToken(string token)
		{
			return connection.Table<Configuration>().Where(i => i.Token == token).FirstOrDefaultAsync();
		}

		public Task<int> Salva(Configuration configuration)
		{
			if (configuration.PrimaryKey != null)
			{
				return connection.UpdateAsync(configuration);
			}
			else
			{
				return connection.InsertAsync(configuration);
			}
		}

		public Task<int> Delete(Configuration configuration)
		{
			return connection.DeleteAsync(configuration);
		}
	}

	public class Configuration
	{
		string token;

		[PrimaryKey]
		public string Token
		{
			get
			{
				return token;
			}

			set
			{
				token = value;
			}
		}

		string data;

		public string Data
		{
			get
			{
				return data;
			}

			set
			{
				data = value;
			}
		}

		Boolean attivo;

		public Boolean Attivo
		{
			get
			{
				return attivo;
			}

			set
			{
				attivo = value;
			}
		}


		string username;

		public string Username
		{
			get
			{
				return username;
			}

			set
			{
				username = value;
			}
		}


		string password;

		public string Password
		{
			get
			{
				return password;
			}

			set
			{
				password = value;
			}
		}

		string clientId;

		public string ClientId
		{
			get
			{
				return clientId;
			}

			set
			{
				clientId = value;
			}
		}


		string codiceAzienda;

		public string CodiceAzienda
		{
			get
			{
				return codiceAzienda;
			}

			set
			{
				codiceAzienda = value;
			}
		}

		string primaryKey;

		[Ignore]
		public string PrimaryKey
		{
			get
			{
				return primaryKey;
			}

			set
			{
				primaryKey = value;
			}
		}

	}
}
