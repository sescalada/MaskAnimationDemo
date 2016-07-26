// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MaskAnimationDemo
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIImageView logoImageView { get; set; }


        [Outlet]
        UIKit.UIButton magicButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView AnimationOriginPicker { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AnimationOriginPicker != null) {
                AnimationOriginPicker.Dispose ();
                AnimationOriginPicker = null;
            }

            if (logoImageView != null) {
                logoImageView.Dispose ();
                logoImageView = null;
            }

            if (magicButton != null) {
                magicButton.Dispose ();
                magicButton = null;
            }
        }
    }
}