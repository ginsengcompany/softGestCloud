using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SoftGestCloud
{
	public partial class ConfigurationPage : ContentPage
	{


		public ConfigurationPage()
		{
			InitializeComponent();

			if (App.Configurazione.Attivo)
			{
				txtStato.Text = "Attivo";
				txtStato.TextColor = Color.DarkGreen;

				txtAttenzione.IsVisible = false;
				txtAttenzioneDescrizione.IsVisible = false;
			}
			else
			{
				txtStato.Text = "Non Attivo";
				txtStato.TextColor = Color.DarkRed;

				txtAttenzione.IsVisible = true;
				txtAttenzioneDescrizione.IsVisible = true;
			}

			txtUsername.Text = App.Configurazione.Username;
			txtIdDispositivo.Text = App.Configurazione.ClientId;

			cmbAzienda.Items.Add("Prova 1");
			cmbAzienda.Items.Add("Prova 2");

			cmbAzienda.SelectedItem = "Prova 2";
				
		}

		void OnClick(object sender, System.EventArgs e)
		{
			//cmbAzienda.Items.Add("Prova 1");
			Console.WriteLine(cmbAzienda.SelectedItem);
		}
	}
}
