using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Utility;

namespace SoftGestCloud
{
	public class Prodotto
	{
		public string codiceArticolo { get; set; }
		public string codiceBarre { get; set; }
		public string nomeArticolo { get; set; }
		public string descrizioneArticolo { get; set; }
		public string scontoArticolo { get; set; }
		public string sottoscortaArticolo { get; set; }
		public string prezzoAcquistoStandard { get; set; }
		public string colliArticolo { get; set; }
		public string pesoArticolo { get; set; }
		public string lunghezzaArticolo { get; set; }
		public string altezzaArticolo { get; set; }
		public string larghezzaArticolo { get; set; }
		public string noteArticolo { get; set; }
		public string um { get; set; }
		public string categoria { get; set; }
		public string codiceTipoArticolo { get; set; }
		public string marca { get; set; }
		public string descrizioneMultiplo { get; set; }
		public string descrizioneImballo { get; set; }
		public string codiceAzienda { get; set; }
		public string id { get; set; }
		public string codiceIva { get; set; }
		public string ultimoPrezzoAcquisto { get; set; }
		public string prezzoMedioAcquisto { get; set; }
		public int giacenze { get; set; }

		public Prodotto()
		{
		}
	}

	public class PrezzoArticolo
	{
		public string codiceArticolo { get; set; }
		public string nomeArticolo { get; set; }
		public string codiceListino { get; set; }
		public string rincaroListino { get; set; }
		public string descrizioneListino { get; set; }
		public string prezzoListino { get; set; }
	}

	public class ProdottiPresentation
	{

		public static List<Prodotto> getLista()
		{

			String test = "{\"data\":[{\"codiceArticolo\":\"SIM0M8\",\"codiceBarre\":\"\",\"nomeArticolo\":\"MOTORE SIMAC 220\",\"descrizioneArticolo\":\"MOTORE SIMAC 220 \",\"scontoArticolo\":\"0\",\"sottoscortaArticolo\":\"0\",\"prezzoAcquistoStandard\":\"120\",\"colliArticolo\":\"0\",\"pesoArticolo\":\"0\",\"lunghezzaArticolo\":\"0\",\"altezzaArticolo\":\"0\",\"larghezzaArticolo\":\"0\",\"noteArticolo\":\"\",\"um\":\"Pz.\",\"categoria\":\"GENERICA\",\"codiceTipoArticolo\":\"MRC\",\"marca\":\"GENERICA\",\"descrizioneMultiplo\":\"1\",\"descrizioneImballo\":\"a vista\",\"codiceAzienda\":\"AZ000001\",\"id\":\"AZ000001-SIM0M8\",\"codiceIva\":\"ORD\",\"ultimoPrezzoAcquisto\":\"0\",\"prezzoMedioAcquisto\":\"0\",\"giacenze\":-4},{\"codiceArticolo\":\"RM-306239-2-00\",\"codiceBarre\":\"RM-306239-2-00\",\"nomeArticolo\":\"(GR) PERNO\",\"descrizioneArticolo\":\"(GR) PERNO\",\"scontoArticolo\":\"0\",\"sottoscortaArticolo\":\"0\",\"prezzoAcquistoStandard\":\"52.4099998474121094\",\"colliArticolo\":\"1\",\"pesoArticolo\":\"0\",\"lunghezzaArticolo\":\"0\",\"altezzaArticolo\":\"0\",\"larghezzaArticolo\":\"0\",\"noteArticolo\":\"\",\"um\":\"Pz.\",\"categoria\":\"GENERICA\",\"codiceTipoArticolo\":\"MRC\",\"marca\":\"GENERICA\",\"descrizioneMultiplo\":\"1\",\"descrizioneImballo\":\"a vista\",\"codiceAzienda\":\"AZ000001\",\"id\":\"AZ000001-RM-306239-2-00\",\"codiceIva\":\"ORD\",\"giacenze\":0},{\"codiceArticolo\":\"SIM0M8\",\"codiceBarre\":\"\",\"nomeArticolo\":\"MOTORE SIMAC 220\",\"descrizioneArticolo\":\"MOTORE SIMAC 220 \",\"scontoArticolo\":\"0\",\"sottoscortaArticolo\":\"0\",\"prezzoAcquistoStandard\":\"120\",\"colliArticolo\":\"0\",\"pesoArticolo\":\"0\",\"lunghezzaArticolo\":\"0\",\"altezzaArticolo\":\"0\",\"larghezzaArticolo\":\"0\",\"noteArticolo\":\"\",\"um\":\"Pz.\",\"categoria\":\"GENERICA\",\"codiceTipoArticolo\":\"MRC\",\"marca\":\"GENERICA\",\"descrizioneMultiplo\":\"1\",\"descrizioneImballo\":\"a vista\",\"codiceAzienda\":\"AZ000001\",\"id\":\"AZ000001-SIM0M8\",\"codiceIva\":\"ORD\",\"ultimoPrezzoAcquisto\":\"0\",\"prezzoMedioAcquisto\":\"0\",\"giacenze\":-4},{\"codiceArticolo\":\"RM-306239-2-00\",\"codiceBarre\":\"RM-306239-2-00\",\"nomeArticolo\":\"(GR) PERNO\",\"descrizioneArticolo\":\"(GR) PERNO\",\"scontoArticolo\":\"0\",\"sottoscortaArticolo\":\"0\",\"prezzoAcquistoStandard\":\"52.4099998474121094\",\"colliArticolo\":\"1\",\"pesoArticolo\":\"0\",\"lunghezzaArticolo\":\"0\",\"altezzaArticolo\":\"0\",\"larghezzaArticolo\":\"0\",\"noteArticolo\":\"\",\"um\":\"Pz.\",\"categoria\":\"GENERICA\",\"codiceTipoArticolo\":\"MRC\",\"marca\":\"GENERICA\",\"descrizioneMultiplo\":\"1\",\"descrizioneImballo\":\"a vista\",\"codiceAzienda\":\"AZ000001\",\"id\":\"AZ000001-RM-306239-2-00\",\"codiceIva\":\"ORD\",\"giacenze\":0},{\"codiceArticolo\":\"SIM0M8\",\"codiceBarre\":\"\",\"nomeArticolo\":\"MOTORE SIMAC 220\",\"descrizioneArticolo\":\"MOTORE SIMAC 220 \",\"scontoArticolo\":\"0\",\"sottoscortaArticolo\":\"0\",\"prezzoAcquistoStandard\":\"120\",\"colliArticolo\":\"0\",\"pesoArticolo\":\"0\",\"lunghezzaArticolo\":\"0\",\"altezzaArticolo\":\"0\",\"larghezzaArticolo\":\"0\",\"noteArticolo\":\"\",\"um\":\"Pz.\",\"categoria\":\"GENERICA\",\"codiceTipoArticolo\":\"MRC\",\"marca\":\"GENERICA\",\"descrizioneMultiplo\":\"1\",\"descrizioneImballo\":\"a vista\",\"codiceAzienda\":\"AZ000001\",\"id\":\"AZ000001-SIM0M8\",\"codiceIva\":\"ORD\",\"ultimoPrezzoAcquisto\":\"0\",\"prezzoMedioAcquisto\":\"0\",\"giacenze\":-4},{\"codiceArticolo\":\"RM-306239-2-00\",\"codiceBarre\":\"RM-306239-2-00\",\"nomeArticolo\":\"(GR) PERNO\",\"descrizioneArticolo\":\"(GR) PERNO\",\"scontoArticolo\":\"0\",\"sottoscortaArticolo\":\"0\",\"prezzoAcquistoStandard\":\"52.4099998474121094\",\"colliArticolo\":\"1\",\"pesoArticolo\":\"0\",\"lunghezzaArticolo\":\"0\",\"altezzaArticolo\":\"0\",\"larghezzaArticolo\":\"0\",\"noteArticolo\":\"\",\"um\":\"Pz.\",\"categoria\":\"GENERICA\",\"codiceTipoArticolo\":\"MRC\",\"marca\":\"GENERICA\",\"descrizioneMultiplo\":\"1\",\"descrizioneImballo\":\"a vista\",\"codiceAzienda\":\"AZ000001\",\"id\":\"AZ000001-RM-306239-2-00\",\"codiceIva\":\"ORD\",\"giacenze\":0},{\"codiceArticolo\":\"SIM0M8\",\"codiceBarre\":\"\",\"nomeArticolo\":\"MOTORE SIMAC 220\",\"descrizioneArticolo\":\"MOTORE SIMAC 220 \",\"scontoArticolo\":\"0\",\"sottoscortaArticolo\":\"0\",\"prezzoAcquistoStandard\":\"120\",\"colliArticolo\":\"0\",\"pesoArticolo\":\"0\",\"lunghezzaArticolo\":\"0\",\"altezzaArticolo\":\"0\",\"larghezzaArticolo\":\"0\",\"noteArticolo\":\"\",\"um\":\"Pz.\",\"categoria\":\"GENERICA\",\"codiceTipoArticolo\":\"MRC\",\"marca\":\"GENERICA\",\"descrizioneMultiplo\":\"1\",\"descrizioneImballo\":\"a vista\",\"codiceAzienda\":\"AZ000001\",\"id\":\"AZ000001-SIM0M8\",\"codiceIva\":\"ORD\",\"ultimoPrezzoAcquisto\":\"0\",\"prezzoMedioAcquisto\":\"0\",\"giacenze\":-4},{\"codiceArticolo\":\"RM-306239-2-00\",\"codiceBarre\":\"RM-306239-2-00\",\"nomeArticolo\":\"(GR) PERNO\",\"descrizioneArticolo\":\"(GR) PERNO\",\"scontoArticolo\":\"0\",\"sottoscortaArticolo\":\"0\",\"prezzoAcquistoStandard\":\"52.4099998474121094\",\"colliArticolo\":\"1\",\"pesoArticolo\":\"0\",\"lunghezzaArticolo\":\"0\",\"altezzaArticolo\":\"0\",\"larghezzaArticolo\":\"0\",\"noteArticolo\":\"\",\"um\":\"Pz.\",\"categoria\":\"GENERICA\",\"codiceTipoArticolo\":\"MRC\",\"marca\":\"GENERICA\",\"descrizioneMultiplo\":\"1\",\"descrizioneImballo\":\"a vista\",\"codiceAzienda\":\"AZ000001\",\"id\":\"AZ000001-RM-306239-2-00\",\"codiceIva\":\"ORD\",\"giacenze\":0},{\"codiceArticolo\":\"SIM0M8\",\"codiceBarre\":\"\",\"nomeArticolo\":\"MOTORE SIMAC 220\",\"descrizioneArticolo\":\"MOTORE SIMAC 220 \",\"scontoArticolo\":\"0\",\"sottoscortaArticolo\":\"0\",\"prezzoAcquistoStandard\":\"120\",\"colliArticolo\":\"0\",\"pesoArticolo\":\"0\",\"lunghezzaArticolo\":\"0\",\"altezzaArticolo\":\"0\",\"larghezzaArticolo\":\"0\",\"noteArticolo\":\"\",\"um\":\"Pz.\",\"categoria\":\"GENERICA\",\"codiceTipoArticolo\":\"MRC\",\"marca\":\"GENERICA\",\"descrizioneMultiplo\":\"1\",\"descrizioneImballo\":\"a vista\",\"codiceAzienda\":\"AZ000001\",\"id\":\"AZ000001-SIM0M8\",\"codiceIva\":\"ORD\",\"ultimoPrezzoAcquisto\":\"0\",\"prezzoMedioAcquisto\":\"0\",\"giacenze\":-4},{\"codiceArticolo\":\"RM-306239-2-00\",\"codiceBarre\":\"RM-306239-2-00\",\"nomeArticolo\":\"(GR) PERNO\",\"descrizioneArticolo\":\"(GR) PERNO\",\"scontoArticolo\":\"0\",\"sottoscortaArticolo\":\"0\",\"prezzoAcquistoStandard\":\"52.4099998474121094\",\"colliArticolo\":\"1\",\"pesoArticolo\":\"0\",\"lunghezzaArticolo\":\"0\",\"altezzaArticolo\":\"0\",\"larghezzaArticolo\":\"0\",\"noteArticolo\":\"\",\"um\":\"Pz.\",\"categoria\":\"GENERICA\",\"codiceTipoArticolo\":\"MRC\",\"marca\":\"GENERICA\",\"descrizioneMultiplo\":\"1\",\"descrizioneImballo\":\"a vista\",\"codiceAzienda\":\"AZ000001\",\"id\":\"AZ000001-RM-306239-2-00\",\"codiceIva\":\"ORD\",\"giacenze\":0},{\"codiceArticolo\":\"SIM0M8\",\"codiceBarre\":\"\",\"nomeArticolo\":\"MOTORE SIMAC 220\",\"descrizioneArticolo\":\"MOTORE SIMAC 220 \",\"scontoArticolo\":\"0\",\"sottoscortaArticolo\":\"0\",\"prezzoAcquistoStandard\":\"120\",\"colliArticolo\":\"0\",\"pesoArticolo\":\"0\",\"lunghezzaArticolo\":\"0\",\"altezzaArticolo\":\"0\",\"larghezzaArticolo\":\"0\",\"noteArticolo\":\"\",\"um\":\"Pz.\",\"categoria\":\"GENERICA\",\"codiceTipoArticolo\":\"MRC\",\"marca\":\"GENERICA\",\"descrizioneMultiplo\":\"1\",\"descrizioneImballo\":\"a vista\",\"codiceAzienda\":\"AZ000001\",\"id\":\"AZ000001-SIM0M8\",\"codiceIva\":\"ORD\",\"ultimoPrezzoAcquisto\":\"0\",\"prezzoMedioAcquisto\":\"0\",\"giacenze\":-4},{\"codiceArticolo\":\"RM-306239-2-00\",\"codiceBarre\":\"RM-306239-2-00\",\"nomeArticolo\":\"(GR) PERNO\",\"descrizioneArticolo\":\"(GR) PERNO\",\"scontoArticolo\":\"0\",\"sottoscortaArticolo\":\"0\",\"prezzoAcquistoStandard\":\"52.4099998474121094\",\"colliArticolo\":\"1\",\"pesoArticolo\":\"0\",\"lunghezzaArticolo\":\"0\",\"altezzaArticolo\":\"0\",\"larghezzaArticolo\":\"0\",\"noteArticolo\":\"\",\"um\":\"Pz.\",\"categoria\":\"GENERICA\",\"codiceTipoArticolo\":\"MRC\",\"marca\":\"GENERICA\",\"descrizioneMultiplo\":\"1\",\"descrizioneImballo\":\"a vista\",\"codiceAzienda\":\"AZ000001\",\"id\":\"AZ000001-RM-306239-2-00\",\"codiceIva\":\"ORD\",\"giacenze\":0},{\"codiceArticolo\":\"SIM0M8\",\"codiceBarre\":\"\",\"nomeArticolo\":\"MOTORE SIMAC 220\",\"descrizioneArticolo\":\"MOTORE SIMAC 220 \",\"scontoArticolo\":\"0\",\"sottoscortaArticolo\":\"0\",\"prezzoAcquistoStandard\":\"120\",\"colliArticolo\":\"0\",\"pesoArticolo\":\"0\",\"lunghezzaArticolo\":\"0\",\"altezzaArticolo\":\"0\",\"larghezzaArticolo\":\"0\",\"noteArticolo\":\"\",\"um\":\"Pz.\",\"categoria\":\"GENERICA\",\"codiceTipoArticolo\":\"MRC\",\"marca\":\"GENERICA\",\"descrizioneMultiplo\":\"1\",\"descrizioneImballo\":\"a vista\",\"codiceAzienda\":\"AZ000001\",\"id\":\"AZ000001-SIM0M8\",\"codiceIva\":\"ORD\",\"ultimoPrezzoAcquisto\":\"0\",\"prezzoMedioAcquisto\":\"0\",\"giacenze\":-4},{\"codiceArticolo\":\"RM-306239-2-00\",\"codiceBarre\":\"RM-306239-2-00\",\"nomeArticolo\":\"(GR) PERNO\",\"descrizioneArticolo\":\"(GR) PERNO\",\"scontoArticolo\":\"0\",\"sottoscortaArticolo\":\"0\",\"prezzoAcquistoStandard\":\"52.4099998474121094\",\"colliArticolo\":\"1\",\"pesoArticolo\":\"0\",\"lunghezzaArticolo\":\"0\",\"altezzaArticolo\":\"0\",\"larghezzaArticolo\":\"0\",\"noteArticolo\":\"\",\"um\":\"Pz.\",\"categoria\":\"GENERICA\",\"codiceTipoArticolo\":\"MRC\",\"marca\":\"GENERICA\",\"descrizioneMultiplo\":\"1\",\"descrizioneImballo\":\"a vista\",\"codiceAzienda\":\"AZ000001\",\"id\":\"AZ000001-RM-306239-2-00\",\"codiceIva\":\"ORD\",\"giacenze\":0}]}";

			JObject jsonResponse = JObject.Parse(test);



			List<Prodotto> lista = JsonConvert.DeserializeObject<List<Prodotto>>(jsonResponse["data"].ToString());
			return lista;
		}
	}

	public class ProdottiNT
	{
		public async System.Threading.Tasks.Task<string> getLista()
		{
			string codiceAzienda = "AZ000001";

			NameValueCollection restParams = new NameValueCollection { { "codiceAzienda", codiceAzienda } };

			var response = await RestFullConnection.GetAsync("api/prodotti", restParams);

			/*string strResponse = "";
			var client = new HttpClient();

			client.DefaultRequestHeaders.Add("user-agent", "AdvaSoftMobile");
			client.DefaultRequestHeaders.Add("client_id", App.Configurazione.ClientId);
			client.DefaultRequestHeaders.Add("Authorization", "Bearer " + App.Configurazione.Token);

			string link = RestFullConnection.APPLICATION_LINK + "api/prodotti?codiceAzienda=" + codiceAzienda;
			Console.WriteLine(link);
			var response = client.GetAsync(link).Result;

			if (response.IsSuccessStatusCode)
			{
				strResponse = await response.Content.ReadAsStringAsync();
				JObject jsonResponse = JObject.Parse(strResponse);
				returnValue = JsonConvert.DeserializeObject<List<Prodotto>>(jsonResponse["data"].ToString());
			}
			else
			{
				strResponse = await response.Content.ReadAsStringAsync();
			}

			Console.WriteLine(App.Configurazione.Token);
			Console.WriteLine(strResponse);*/

			return response.ToString();
		}

		public async System.Threading.Tasks.Task<string> getPrezziListino(String codiceArticolo)
		{
			string codiceAzienda = "AZ000001";
			Console.WriteLine(codiceArticolo);
			Console.WriteLine("PASSO 2 A");

			NameValueCollection restParams = new NameValueCollection { { "codiceAzienda", codiceAzienda }, { "codiceArticolo", codiceArticolo } };

			var response = await RestFullConnection.GetAsync("api/listini/prezziarticolo", restParams);

			return response.ToString();
		}


	}
}
