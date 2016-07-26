using System;
using CoreGraphics;
using UIKit;

namespace MaskAnimationDemo
{
    public partial class ViewController : UIViewController
    {
        private UIView maskView;
        private AnimationOriginPickerViewModel originViewModel;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            originViewModel = new AnimationOriginPickerViewModel();
            originViewModel.ValueChanged += AnimationSelectionChanged;

            AnimationOriginPicker.Model = originViewModel;

            maskView = new UIView()
            {
                BackgroundColor = UIColor.White
            };
            maskView.Layer.AnchorPoint = CGPoint.Empty;

            logoImageView.MaskView = maskView;

            magicButton.TouchUpInside += (sender, e) =>
                ExecuteAnimation();
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            maskView.Frame = new CGRect(0, 0, logoImageView.Frame.Width, logoImageView.Frame.Height);
            ResetMaskBounds();
        }

        private void ExecuteAnimation()
        {
            ResetMaskBounds();

            UIView.BeginAnimations("discoverLogoAnimation");
            UIView.SetAnimationDuration(2);
            UIView.SetAnimationCurve(UIViewAnimationCurve.Linear);

            maskView.Bounds = new CGRect(0, 0, logoImageView.Frame.Width, logoImageView.Frame.Height);

            UIView.CommitAnimations();
        }

        private void ResetMaskBounds()
        {
            var bounds = maskView.Bounds;
            bounds.Width = 0;
            maskView.Bounds = bounds;
        }

        private void AnimationSelectionChanged(object sender, string e)
        {
            switch (e)
            {
                case "End":
                    maskView.Layer.AnchorPoint = new CGPoint(1, 1);

                    break;
                case "Center":
                    maskView.Layer.AnchorPoint = new CGPoint(0.5, 0.5);
                    break;
                default:
                    maskView.Layer.AnchorPoint = CGPoint.Empty;
                    break;
            }

            maskView.Frame = new CGRect(0, 0, logoImageView.Frame.Width, logoImageView.Frame.Height);
        }
    }
}

