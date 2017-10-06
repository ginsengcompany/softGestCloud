using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using ViewModels;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace SoftGestCloud
{
	public partial class Prodotti : ContentPage
	{
		ProdottiViewModel pvm = null;
		List<Prodotto> lista = new List<Prodotto>();

		public Prodotti()
		{
			InitializeComponent();
			loadData();
			BindingContext = new ProdottiViewModel();
			pvm = (ProdottiViewModel)this.BindingContext;
			pvm.IsBusy = true;
			//listView.IsPullToRefreshEnabled = true;
			/*listView.ItemTapped += async (sender, e) =>
			{
				await DisplayAlert("Tapped", e.Item.ToString() + " was selected.", "OK");
			};*/
			//this.loadData();
		}

		void OnSearchButtonPressed(object sender, EventArgs e)
		{
			var keyword = SearchBarProdotti.Text;
			DisplayAlert("Item Selected", keyword.ToString(), "Ok");
			listView.ItemsSource = lista.Where(x => x.nomeArticolo.ToLower().Contains(keyword));
		}

		void OnTextChanged(object sender, EventArgs e)
		{
			var keyword = SearchBarProdotti.Text;
			listView.ItemsSource = lista.Where(x => x.nomeArticolo.ToLower().Contains(keyword));
		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}
			Prodotto prodotto = (Prodotto)e.SelectedItem;
			this.loadPrezziArticolo(prodotto.codiceArticolo);
			//DisplayAlert("Item Selected", prodotto.id, "Ok");
			listView.SelectedItem = null;
		}

		public void OnMore(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
		}

		public void OnDelete(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
		}

		private void loadPrezziArticolo(String codiceArticolo)
		{
			pvm.IsBusy = true;
			Task.Run(async() => await caricaPrezziArticolo(codiceArticolo)).ContinueWith(task =>
			 {
				Console.WriteLine("PASSO ULTIMO");
				pvm.IsBusy = false;
				//this.verificaUtente();
			});			
		}

		private void loadData()
		{
			Task.Run(async () => await caricaProdotti()).ContinueWith(task =>
			 {
				 pvm.IsBusy = false;
				 //this.verificaUtente();
			 });
		}


		private async Task caricaProdotti()
		{
			ProdottiNT prodottiNT = new ProdottiNT();

			string response = await prodottiNT.getLista();
			try { 
				JObject json = JObject.Parse(response);
				if ((bool)json["esito"])
				{
					this.lista = JsonConvert.DeserializeObject<List<Prodotto>>(json["data"].ToString());

					Device.BeginInvokeOnMainThread(() =>
					{
						listView.ItemsSource = this.lista;
					});
				}
				else
				{
					Device.BeginInvokeOnMainThread(async() =>
					{
						await DisplayAlert("Attenzione", json["messaggio"].ToString(), "OK");
					});
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				Device.BeginInvokeOnMainThread(async() =>
				{
						await DisplayAlert("Attenzione", "Connessione al server non disponibile", "OK");
				});
			}


		}

		private async Task caricaPrezziArticolo(String codiceArticolo)
		{
			ProdottiNT prodottiNT = new ProdottiNT();

			string response = await prodottiNT.getPrezziListino(codiceArticolo);
			try { 
				JObject json = JObject.Parse(response);

				if ((bool)json["esito"])
				{
					List<PrezzoArticolo> listaProdottoPrezzi = JsonConvert.DeserializeObject<List<PrezzoArticolo>>(json["data"].ToString());

					Console.WriteLine(json["data"].ToString());
					StringBuilder prezzi = new StringBuilder();
					foreach (PrezzoArticolo prezzoArticolo in listaProdottoPrezzi)
					{
						float prezzoListino = float.Parse( ((prezzoArticolo.prezzoListino == null) ? "0" : prezzoArticolo.prezzoListino), System.Globalization.CultureInfo.InvariantCulture); 
						string prezzo = String.Format("{0,-20}  {1,10:C}", prezzoArticolo.descrizioneListino, prezzoListino);

						prezzi.AppendLine(prezzo);
					}
					Device.BeginInvokeOnMainThread(async() =>
					{		
						await DisplayAlert("Prezzi", prezzi.ToString(), "OK");
					});
				}
				else
				{
					Device.BeginInvokeOnMainThread(async() =>
					{
						await DisplayAlert("Attenzione", json["messaggio"].ToString(), "OK");
					});
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				Console.WriteLine("ECCEZZIONE");
				Device.BeginInvokeOnMainThread(async() =>
				{
						await DisplayAlert("Attenzione", "Connessione al server non disponibile", "OK");
				});
			}


		}
	}
}
