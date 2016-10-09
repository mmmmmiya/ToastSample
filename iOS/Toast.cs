﻿using System;

using ToastSample;
using ToastSample.iOS;

using UIKit;
using Foundation;
using CoreGraphics;

[assembly:Xamarin.Forms.Dependency(typeof(MyToast))]
namespace ToastSample.iOS
{
	public class MyToast : IMyToast
	{
		public void Show(string message)
		{
			var toast = new Toast();
			toast.Show(UIApplication.SharedApplication.KeyWindow.RootViewController.View, message);
		}
	}

	// 独自のToast View
	class Toast {
		UIView _view;
		UILabel _label;
		int _margin = 30;
		int _height = 40;
		int _width = 150;

		NSTimer _timer = null;

		public Toast() {
			// トーストビューの生成
			_view = new UIView(new CGRect(0, 0, 0, 0))
			{
				BackgroundColor = UIColor.Black,
			};
			_view.Layer.CornerRadius = (nfloat)20.0;
			//  メッセージ表示用のラベル
			_label = new UILabel(new CGRect(0, 0, 0, 0))
			{
				TextAlignment = UITextAlignment.Center,
				TextColor = UIColor.White
			};
			_view.AddSubview(_label);
		}

		// 表示開始
		public void Show(UIView parent, string message)
		{
			// 既に表示中の場合は、処理を停止する
			if (_timer != null)
			{
				_timer.Invalidate();
				_view.RemoveFromSuperview(); // 親ビューから削除する
			}

			// 当初、アルファ値0.7で表示を開始する
			_view.Alpha = (nfloat)0.7;

			// 親Viewからトーストのサイズを調整する
			_view.Frame = new CGRect(
				(parent.Bounds.Width - _width) / 2,
				parent.Bounds.Height - _height - _margin,
				_width,
				_height);

			_label.Frame = new CGRect(0, 0, _width, _height);
			_label.Text = message; // ラベルの表示文字列を設定する

			parent.AddSubview(_view);

			//タイマー開始
			var wait = 5; // 消え始めるまでのウエイト
			_timer = NSTimer.CreateRepeatingScheduledTimer(TimeSpan.FromMilliseconds(100), delegate
			{
				// alpha値が0になったらViewのサイズを0にしてタイマーを停止する
				if (_view.Alpha <= 0)
				{
					_timer.Invalidate();
					_view.RemoveFromSuperview(); // 親ビューから削除する
				}
				else {
					if (wait > 0)
					{
						wait--;
					}
					else {
						_view.Alpha -= (nfloat)0.05;
					}
				}
			});
		}
	}
}
