using System;

using Android.Views;
namespace ToastSample.Droid
{
	internal class MyGestureListener : GestureDetector.SimpleOnGestureListener
	{
		public ExButton ExButton { private get; set; }

		public override void OnLongPress(MotionEvent e)
		{
			base.OnLongPress(e);
			if (ExButton != null)
			{
				ExButton.OnLongPress();
			}
		}
	}
}