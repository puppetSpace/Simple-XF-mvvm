using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pi.Xf.AppTest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void BtnNavigation_Clicked(object sender, EventArgs e)
		{
			App.Current.MainPage = new Pi.Xf.SimpleMvvm.NavigationPage(this);
		}

		private void BtnShell_Clicked(object sender, EventArgs e)
		{
			App.Current.MainPage = new AppShell();
		}
	}
}