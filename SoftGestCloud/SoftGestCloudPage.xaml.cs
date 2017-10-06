using System;
using System.Collections.Generic;
using Utenti;
using Utility;
using Xamarin.Forms;

namespace SoftGestCloud
{
	public partial class SoftGestCloudPage : MasterDetailPage
	{
		public SoftGestCloudPage()
		{
			InitializeComponent();
			Detail = new NavigationPage(new Dashboard());
		}

		void BtnDashboardClick(object sender, System.EventArgs e)
		{
			Detail = new NavigationPage(new Dashboard());
			IsPresented = false;
		}

		void BtnProdottiClick(object sender, System.EventArgs e)
		{

			Detail = new NavigationPage(new Prodotti());
			IsPresented = false;
			Console.WriteLine("Sisto Andolfi");
		}

		void BtnDocumentiClick(object sender, System.EventArgs e)
		{
			Detail = new NavigationPage(new Documenti());
			IsPresented = false;
			//String a = await RestFullConnection.GetAsync("", "");

			//Console.WriteLine(a);
		}

		void BtnConfigurazioneClick (object sender, System.EventArgs e)
		{
			Detail = new NavigationPage(new ConfigurationPage());
			IsPresented = false;
		}
	}
}
