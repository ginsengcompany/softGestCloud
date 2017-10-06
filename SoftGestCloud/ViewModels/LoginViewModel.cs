using System;
namespace ViewModels
{
	public class LoginViewModel : ViewModelBase
	{
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
				this.Notify("Username");
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
                this.Notify("Password");

			}
		}
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

		public LoginViewModel()
		{
		}
	}
}
