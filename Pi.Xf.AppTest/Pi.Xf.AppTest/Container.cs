using Pi.Xf.AppTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi.Xf.AppTest
{
    public class Container
    {
		private readonly SimpleInjector.Container _container = new SimpleInjector.Container();

		public Container()
		{
			_container.Register<FirstPageViewModel>();
			_container.Register<SecondPageViewModel>();
			_container.Register<MainPageViewModel>();
		}

		public MainPageViewModel MainPageViewModel
		{
			get { return _container.GetInstance<MainPageViewModel>(); }
		}

		public FirstPageViewModel FirstPageViewModel
		{
			get { return _container.GetInstance<FirstPageViewModel>(); }
		}

		public SecondPageViewModel SecondPageViewModel
		{
			get { return _container.GetInstance<SecondPageViewModel>(); }
		}
	}
}
