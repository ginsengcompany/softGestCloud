using System;
namespace ViewModels
{
	public class ProdottiViewModel : ViewModelBase
	{

		Boolean isBusy;

		public Boolean IsBusy
		{
			get
			{
				return isBusy;
			}

			set
			{
				isBusy = value;
                this.Notify("IsBusy");
			}
		}

		public ProdottiViewModel()
		{
		}
	}
}
