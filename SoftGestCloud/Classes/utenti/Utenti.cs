using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SoftGestCloud;
using SQLite;
using Utility;

namespace Utenti
{
	public class Dispositivo
	{
		public string Id { get; set; }
		public string Model { get; set; }
		public string Piattaforma { get; set; }
		public string ApplicationName { get; set; }
		public string Type { get; set; }
		public string Impronta { get; set; }
	}

	public class UtentiNT
	{
		public async System.Threading.Tasks.Task<List<Utente>> getLista()
		{
			List<Utente> lista = new List<Utente>();

			var client = new HttpClient();

			var response = await client.GetStringAsync("http://localhost:8080/Login/rest/token");
			Console.WriteLine("OK Sisto: " + response);
			//var todoItems = JsonConvert.DeserializeObject<List<TodoItem>>(response);
			return lista;
		}

		public async System.Threading.Tasks.Task<string> login(string username, string password, Dispositivo dispositivo)
		{
			string returnValue = null;
			var client = new HttpClient();
			var parametri = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("grant_type", "client_credentials"),
				new KeyValuePair<string, string>("client_id", dispositivo.Id),
				new KeyValuePair<string, string>("client_secret", password),
				new KeyValuePair<string, string>("impronta", dispositivo.Impronta),
				new KeyValuePair<string, string>("application", dispositivo.ApplicationName),
				new KeyValuePair<string, string>("tipo", dispositivo.Piattaforma),
				new KeyValuePair<string, string>("descrizione", "Dispositivo " + dispositivo.Model),
				new KeyValuePair<string, string>("applicazione", "SoftGest "),
				new KeyValuePair<string, string>("dispositive_type", "D")
			};

			string encoding = Convert.ToBase64String(Encoding.ASCII.GetBytes((username + ":" + password)));
			//request.setHeader("user-agent", "AdvaSoft");
			//request.setHeader("Authorization", "Basic " + encoding);
			client.DefaultRequestHeaders.Add("user-agent", "AdvaSoftMobile");
			client.DefaultRequestHeaders.Add("Authorization", "Basic " + encoding);
			var content = new FormUrlEncodedContent(parametri);

			//var response = client.PostAsync("http://192.168.125.7:8080/AdvaSoftLogin/rest/token", content).Result;
			var response = client.PostAsync(RestFullConnection.LOGIN_LINK + "rest/token", content).Result;

			if (response.IsSuccessStatusCode)
			{
				returnValue = await response.Content.ReadAsStringAsync();
				Console.WriteLine(returnValue);
			}
			else
			{
				returnValue = await response.Content.ReadAsStringAsync();
			}



			return returnValue;
		}
	}

	public class UtentiDB
	{

		private SQLiteAsyncConnection connection = App.GetDatabase.GetConnection();

		public UtentiDB()
		{
			connection.CreateTableAsync<Utente>().Wait();
		}

		public Task<List<Utente>> GetConfiguration()
		{
			return connection.Table<Utente>().ToListAsync();
		}

		public Task<Utente> GetConfigurationByToken(string id)
		{
			return connection.Table<Utente>().Where(i => i.Id == id).FirstOrDefaultAsync();
		}

		public Task<int> Salva(Utente utente)
		{
			if (utente.Id != null)
			{
				return connection.UpdateAsync(utente);
			}
			else
			{
				return connection.InsertAsync(utente);
			}
		}

		public Task<int> Delete(UtentiDB configuration)
		{
			return connection.DeleteAsync(configuration);
		}

	}

	public class Menu
	{
		public string text { get; set; }
		public string view { get; set; }
		public bool leaf { get; set; }
		public string iconCls { get; set; }
		public string routeId { get; set; }
	}

	public class Azienda
	{
		public string CodiceAzienda { get; set; }
		public string Denominazione { get; set; }
		public string Indirizzo { get; set; }
		public string cap { get; set; }
		public string localita { get; set; }
		public string provincia { get; set; }
		public string piva { get; set; }
		public string cf { get; set; }
		public string cciaa { get; set; }
		public string condizioniVendita { get; set; }
		public string condizioniAssistenza { get; set; }
		public string proprietario { get; set; }
	}

	public class Utente
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string Id { get; set; }
		public string Lastname { get; set; }
		public string Firstname { get; set; }
		public string Profilo { get; set; }
		public string ScadenzaUtenza { get; set; }
		public string Image { get; set; }
		public List<Menu> menu { get; set; }
		public List<Azienda> aziende { get; set; }
	}
}
