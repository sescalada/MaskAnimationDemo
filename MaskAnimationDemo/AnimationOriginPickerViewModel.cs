using System;
using UIKit;

namespace MaskAnimationDemo
{
	public class AnimationOriginPickerViewModel : UIPickerViewModel
	{
		private string[] data = new string[] { "Start", "Center", "End" };

		public event EventHandler<string> ValueChanged;

		public override nint GetComponentCount(UIPickerView pickerView)
		{
			return 1;
		}

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			return data.Length;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			return data[row];
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
			var handler = ValueChanged;

			if (handler != null)
			{
				handler.Invoke(pickerView, data[row]);
			}
		}
	}
}