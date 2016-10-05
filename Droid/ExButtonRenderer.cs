using System;
using Android.Views;
using ToastSample;
using ToastSample.Droid;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(ExButton), typeof(ExButtonRenderer))]
namespace ToastSample.Droid
{
	internal class ExButtonRenderer : ButtonRenderer
	{
		private readonly MyGestureListener _listener;
		private readonly GestureDetector _detector;
		public ExButtonRenderer()
		{
			_listener = new MyGestureListener();
			_detector = new GestureDetector(_listener);
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			_listener.ExButton = Element as ExButton;

			GenericMotion += (s,a) => _detector.OnTouchEvent(a.Event);
			Touch += (s,a) => _detector.OnTouchEvent(a.Event);
		}
	}
}
