using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SoftGestCloud;

namespace Utility
{
	public static class RestFullConnection
	{

		//public static readonly string LOGIN_LINK = "http://192.168.1.33:8080/AdvaSoftLogin/";//<--GESAN
		//public static readonly string APPLICATION_LINK = "http://192.168.1.33:8080/PubbliGestCloud/";//<--GESAN		

		//public static readonly string LOGIN_LINK = "http://10.10.99.18:8080/AdvaSoftLogin/";//<--ASL
		//public static readonly string APPLICATION_LINK = "http://10.10.99.18:8080/PubbliGestCloud/";//<--ASL

		public static readonly string LOGIN_LINK = "http://192.168.125.56:3000/";//<--CASA
		public static readonly string APPLICATION_LINK = "http://192.168.125.56:3000/";//<--CASA		

		private static HttpClient client;


		/// <summary>
		/// Gets the todo items async.
		/// </summary>
		/// <returns>The todo items async.</returns>
		/*public static async Task<String> GetAsync(String path, string queryParams)
		{
			client.DefaultRequestHeaders.Add("user-agent", "AdvaSoftMobile");
			client.DefaultRequestHeaders.Add("Authorization", "Bearer " + App.Configurazione.Token);
			client.DefaultRequestHeaders.Add("client_id", App.Configurazione.ClientId);

			Uri link = new Uri(APPLICATION_LINK + path);
			link = RestFullConnection.AttachParameters(link, new NameValueCollection { { "Bill", "Gates" }, { "Steve", "Jobs" } });

			var response = await client.GetStringAsync(link);
			Console.WriteLine(response);
			//var todoItems = JsonConvert.DeserializeObject<List<TodoItem>>(response);
			return "{}";
		}*/

		public static async Task<String> GetAsync(String path, NameValueCollection queryParams)
		{
			Uri link = new Uri(APPLICATION_LINK + path);

			link = RestFullConnection.AttachParameters(link, queryParams);	

			//Console.WriteLine(link);
			HttpClient httpClient = RestFullConnection.GetHttpClient();

			string strResponse = "";
			var response = httpClient.GetAsync(link).Result;
			//client.Dispose();

			if (response.IsSuccessStatusCode)
			{
				strResponse = await response.Content.ReadAsStringAsync();
			}
			else
			{
				strResponse = await response.Content.ReadAsStringAsync();
			}

			//var todoItems = JsonConvert.DeserializeObject<List<TodoItem>>(response);
			return strResponse;
		}


		/// <summary>
		/// Adds the todo item async.
		/// </summary>
		/// <returns>The todo item async.</returns>
		/// <param name="itemToAdd">Item to add.</param>
		/*public async Task<int> AddTodoItemAsync(TodoItem itemToAdd)
		{
			
			//var data = JsonConvert.SerializeObject(itemToAdd);
			//var content = new StringContent(data, Encoding.UTF8, "application/json");
			//var response = await client.PostAsync("http://localhost:5000/api/todo/item", content);
			//var result = JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
			return result;
		}*/

		/// <summary>
		/// Updates the todo item async.
		/// </summary>
		/// <returns>The todo item async.</returns>
		/// <param name="itemIndex">Item index.</param>
		/// <param name="itemToUpdate">Item to update.</param>
		/*public async Task<int> UpdateTodoItemAsync(int itemIndex, TodoItem itemToUpdate)
		{
			var data = JsonConvert.SerializeObject(itemToUpdate);
			var content = new StringContent(data, Encoding.UTF8, "application/json");
			var response = await client.PutAsync(string.Concat("http://localhost:5000/api/todo/", itemIndex), content);
			return JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
		}*/

		/// <summary>
		/// Deletes the todo item async.
		/// </summary>
		/// <returns>The todo item async.</returns>
		/// <param name="itemIndex">Item index.</param>
		/*public async Task DeleteTodoItemAsync(int itemIndex)
		{
			await client.DeleteAsync(string.Concat("http://localhost:5000/api/todo/", itemIndex));
		}*/

		private static Uri AttachParameters(this Uri uri, NameValueCollection parameters)
		{
			var stringBuilder = new StringBuilder();
			string str = "?";
			for (int index = 0; index < parameters.Count; ++index)
			{
				stringBuilder.Append(str + parameters.AllKeys[index] + "=" + parameters[index]); str = "&";
			}

			return new Uri(uri + stringBuilder.ToString());
		}

		private static HttpClient GetHttpClient()
		{
			if (RestFullConnection.client == null)
			{
				RestFullConnection.client = new HttpClient();
				client.DefaultRequestHeaders.Add("user-agent", "AdvaSoftMobile");
				client.DefaultRequestHeaders.Add("client_id", App.Configurazione.ClientId);
				client.DefaultRequestHeaders.Add("Authorization", "Bearer " + App.Configurazione.Token);
			}

			return RestFullConnection.client;
		}

	}
}
