using System;
using Xamarin.Forms;

namespace ListViewCustomCell
{
	public class ProdottoCell : ViewCell
	{
		public static readonly BindableProperty NameProperty = BindableProperty.Create("nomeArticolo", typeof(string), typeof(ProdottoCell), "nomeArticolo");
		
		public static readonly BindableProperty AgeProperty = BindableProperty.Create("codiceArticolo", typeof(string), typeof(ProdottoCell), "codiceArticolo");		

		public string nomeArticolo
		{
			get { return (string)GetValue(NameProperty); }
			set { SetValue(NameProperty, value); }
		}

		public string codiceArticolo
		{
			get { return (string)GetValue(NameProperty); }
			set { SetValue(NameProperty, value); }
		}

		public ProdottoCell()
		{
			//instantiate each of our views
			var image = new Image();
			StackLayout cellWrapper = new StackLayout();
			StackLayout horizontalLayout = new StackLayout();
			Label left = new Label();
			Label right = new Label();

			//set bindings
			left.SetBinding(Label.TextProperty, "nomeArticolo");
			right.SetBinding(Label.TextProperty, "codiceArticolo");

			//Set properties for desired design
			cellWrapper.BackgroundColor = Color.FromHex("#eee");
			horizontalLayout.Orientation = StackOrientation.Horizontal;
			right.HorizontalOptions = LayoutOptions.EndAndExpand;
			left.TextColor = Color.FromHex("#f35e20");
			right.TextColor = Color.FromHex("503026");

			//add views to the view hierarchy
			horizontalLayout.Children.Add(image);
			horizontalLayout.Children.Add(left);
			horizontalLayout.Children.Add(right);
			cellWrapper.Children.Add(horizontalLayout);
			View = cellWrapper;
		}

	}
}
