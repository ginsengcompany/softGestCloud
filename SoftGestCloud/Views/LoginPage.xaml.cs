using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SoftGestCloud;
using Plugin.DeviceInfo;

using Utenti;
using ViewModels;
using Xamarin.Forms;

namespace SoftGestCloud
{
	public partial class LoginPage : ContentPage
	{
		LoginViewModel lvm = null;
		Dispositivo dispositivo = null;
		String messaggio = "Errore nel contattare il server!";
		Boolean errorMessage = true;
		public LoginPage()
		{

			InitializeComponent();
			this.BindingContext = new ViewModels.LoginViewModel();

		}

		void OnLoginButtonClicked(object sender, System.EventArgs e)
		{
			this.lvm = (ViewModels.LoginViewModel)this.BindingContext;
			lvm.IsBusy = true;
			this.dispositivo = new Dispositivo();
			this.dispositivo.Piattaforma = Device.RuntimePlatform; ;
			this.dispositivo.Id = CrossDeviceInfo.Current.Id;
			this.dispositivo.Model = CrossDeviceInfo.Current.Model;
			this.dispositivo.ApplicationName = App.APPLICATION_NAME;
			this.dispositivo.Impronta = App.Impronta;
			string piattaforma = Device.RuntimePlatform;
			/*Console.WriteLine("Piattaforma: " + piattaforma);
			Console.WriteLine("Id: " + CrossDeviceInfo.Current.Id);
			Console.WriteLine("Model: " + CrossDeviceInfo.Current.Model);
			Console.WriteLine("OK Sisto: " + this.Height);*/
			//string username = txtUsename.Text;

			Task.Run(async () => await login("", "")).ContinueWith(task =>
			{
				lvm.IsBusy = false;
				this.verificaUtente();
			});

			/*if ((lvm.Username == "admin") && lvm.Password.Equals("password"))
			{
				Application.Current.MainPage = new SoftGestCloudPage();
			}
			else
			{
				DisplayAlert("Attenzione", "Username e/o password non corretti " + lvm.Username, "OK");
			}*/


		}

		private void verificaUtente()
		{
			if (App.Utente == null)
			{
				Device.BeginInvokeOnMainThread(async () =>
				{
					if (errorMessage)
					{
						await DisplayAlert("Attenzione", messaggio, "OK");
					}
					 //"Username e/o password non corretti"
				});

			}
			else
			{
				if (!App.Configurazione.Attivo)
				{
					Device.BeginInvokeOnMainThread(async () =>
					{
						await Navigation.PushAsync(new ConfigurationPage());
					});
				}
				else
				{
					Device.BeginInvokeOnMainThread(() =>
					{
						Application.Current.MainPage = new SoftGestCloudPage();
					});
					//App.Current.MainPage = new SoftGestCloudPage();
				}

			}
		}

		private async Task login(string username, string password)
		{
			if (App.Configurazione == null)
			{
				UtentiNT utenteNT = new UtentiNT();
				var response = await utenteNT.login(lvm.Username, lvm.Password, this.dispositivo);

				try
				{
					JObject jsonResponse = JObject.Parse(response);
					Console.WriteLine("**********");
					Console.WriteLine(jsonResponse);
					Console.WriteLine("***********");
					if (jsonResponse["error"] == null)
					{
						Configuration.Configuration configuration = new Configuration.Configuration();
						configuration.Token = jsonResponse["access_token"].ToString();
						configuration.Data = response;
						configuration.Attivo = false;
						configuration.Username = lvm.Username;
						configuration.Password = lvm.Password;
						configuration.ClientId = this.dispositivo.Id;

						App.Configurazione = configuration;

						int i = await Configuration.ConfigurationPresentation.Salva(configuration);

						Console.WriteLine("RISULTATO INSERIMENTO: ");
						Console.WriteLine(i);

						if (i > 0)
						{
							this.setUtente();
						}

					}
					else
					{
						this.messaggio = jsonResponse["error_description"].ToString();
						Console.WriteLine("Quindi entro qu!!!");
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			else
			{
				if (App.Configurazione.Username == lvm.Username && App.Configurazione.Password == lvm.Password)
				{
					this.setUtente();
				}
				else
				{
					errorMessage = true;
					messaggio = "Username e/o password non corretti!";
				}
			}
		}

		private void setUtente()
		{
			App.Utente = new Utente();
			App.Utente.Username = lvm.Username;
			App.Utente.Password = lvm.Password;

		}
	}

}
