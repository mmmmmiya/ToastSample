using System;

using Xamarin.Forms;

namespace ToastSample
{
	public class App : Application
	{
		public App()
		{
			MainPage = new MyPage();
		}
	}

	internal class MyPage : ContentPage
	{
		public MyPage()
		{
			var button = new Button { Text = "*** Show Toast ***" };

			Content = new StackLayout
			{
				Children = { button },
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};

			button.Clicked += (sender, e) => {
				DependencyService.Get<IMyToast>().Show("hogehoge");
			};
		}
	}
}
