using System;
using ToastSample;
using ToastSample.Droid;

using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(MyToast))]
namespace ToastSample.Droid
{
	public class MyToast : IMyToast
	{
		public void Show(string message)
		{
			Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
		}
	}
}
