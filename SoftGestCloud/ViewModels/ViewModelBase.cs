using System;
using System.ComponentModel;

namespace ViewModels
{
	public abstract class ViewModelBase : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;

		protected void Notify(string propertyName)
		{
			if (this.PropertyChanged != null) {
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
