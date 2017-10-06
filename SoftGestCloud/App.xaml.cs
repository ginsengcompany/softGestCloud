using Utility;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using Configuration;
using System;
using PushNotification.Plugin;
using Newtonsoft.Json.Linq;
using Utenti;
using Newtonsoft.Json;

namespace SoftGestCloud
{

	public partial class App : Application
	{
		public readonly static string APPLICATION_NAME = "SoftGest";
		static Database database;
		static string token;
		static string impronta;
		//static JObject configurazione;
		static Configuration.Configuration configurazione = null;
		static Utente utente = null;

		public App()
		{
			InitializeComponent();

			if (AppCostants.utente == null)
			{
				//MainPage = new NavigationPage(new ConfigurationPage());
				MainPage = new NavigationPage(new LoginPage());
				//MainPage = new LaginPage();
				/*string json = "{\"id\":\"1\",\"lastname\":\"Toscano\",\"firstname\":\"Carmine\",\"username\":\"toscano\",\"profilo\":\"utente\",\"scadenzaUtenza\":\"2016-12-15\"}";
				Utente profilo = JsonConvert.DeserializeObject<Utente> (json);
				Console.WriteLine(profilo.Lastname);*/
			}
			else
			{
				MainPage = new SoftGestCloudPage();
			}
		}
		public static Database GetDatabase
		{
			get
			{
				if (database == null)
				{
					database = new Database(DependencyService.Get<ILocalDbHelper>().GetLocalFilePath("SoftGest.db3"));
				}
				return database;

			}
		}

		public static string Token
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

		public static Utente Utente
		{
			get
			{
				return utente;
			}

			set
			{
				utente = value;
			}
		}

		public static string Impronta
		{
			get
			{
				return impronta;
			}

			set
			{
				impronta = value;
			}
		}

		public static Configuration.Configuration Configurazione
		{
			get
			{
				return configurazione;
			}

			set
			{
				configurazione = value;
			}
		}

		protected override void OnStart()
		{
			Task.Run(async () =>
			{
				List<Configuration.Configuration> configuartionList = await ConfigurationPresentation.GetConfiguration();
				if (configuartionList.Count != 0)
				{
					Configuration.Configuration configuration = configuartionList[0];
					App.Token = configuration.Token;
					App.Configurazione = configuration; // = //JObject.Parse(configuration.Data);
				}
				else
				{
					//configurazione = new JSONObject("{\"nome\":\"Stito\"}");
					//zConsole.WriteLine("NOME: " + configurazione.Get("nome"));
					CrossPushNotification.Current.Register();
					/*Configuration.Configuration configuration = new Configuration.Configuration();
					configuration.Token = App.Token;
					configuration.Data = "{}";
					int a = await ConfigurationPresentation.Salva(configuration);*/
				}
			});
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		public static void OnNotification(Newtonsoft.Json.Linq.JObject values)
		{
			string operazione = "";
			if (values["operazione"] != null)
			{
				operazione = values["operazione"].ToString();
			}

			switch (operazione)
			{
				case "attivaDispositivo":
					App.AttivaDispositivo();
					break;
			}
		}

		private static async void AttivaDispositivo()
		{
			List<Configuration.Configuration> configuartionList = await ConfigurationPresentation.GetConfiguration();
			if (configuartionList.Count != 0)
			{
				Configuration.Configuration configuration = configuartionList[0];
				configuration.PrimaryKey = configuration.Token;
				configuration.Attivo = true;
				App.Configurazione = configuration;
				int i = await ConfigurationPresentation.Salva(configuration);
				Console.WriteLine("Riposta al Salvataggio: " + i);
				if (i != 0)
				{
				}
			}
		}
	}

}
