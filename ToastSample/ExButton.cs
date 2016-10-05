using System;

using Xamarin.Forms;

namespace ToastSample
{
	public class ExButton : Button
	{
		public event EventHandler LongPress;

		public void OnLongPress()
		{
			if (LongPress != null)
			{
				LongPress(this, new EventArgs());
			}
		}
	}
}
