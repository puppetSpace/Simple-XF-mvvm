using Pi.Xf.TestApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Pi.Xf.TestApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SimpleMvvm.Navigator.Instance.Configure(nameof(MainPage), typeof(MainPage));
            SimpleMvvm.Navigator.Instance.Configure(nameof(SecondPage), typeof(SecondPage));

            MainPage = new Pi.Xf.SimpleMvvm.NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
