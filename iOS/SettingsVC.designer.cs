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

namespace Bhasvic10th.iOS
{
    [Register ("SettingsVC")]
    partial class SettingsVC
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LastB4EventLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStepper LastB4EventStepper { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LoadTestEvent { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch NotificationsEnableSwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch NotSoundSwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NotsPerEventLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStepper NotsPerEventStepper { get; set; }

        [Action ("LastB4EventsChangedHandler:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void LastB4EventsChangedHandler (UIKit.UIStepper sender);

        [Action ("LoadTestEvent_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void LoadTestEvent_TouchUpInside (UIKit.UIButton sender);

        [Action ("NotsEnableChangedHandler:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void NotsEnableChangedHandler (UIKit.UISwitch sender);

        [Action ("NotSoundOnSwitchHandler:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void NotSoundOnSwitchHandler (UIKit.UISwitch sender);

        [Action ("NotsPerEventHandler:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void NotsPerEventHandler (UIKit.UIStepper sender);

        void ReleaseDesignerOutlets ()
        {
            if (LastB4EventLabel != null) {
                LastB4EventLabel.Dispose ();
                LastB4EventLabel = null;
            }

            if (LastB4EventStepper != null) {
                LastB4EventStepper.Dispose ();
                LastB4EventStepper = null;
            }

            if (LoadTestEvent != null) {
                LoadTestEvent.Dispose ();
                LoadTestEvent = null;
            }

            if (NotificationsEnableSwitch != null) {
                NotificationsEnableSwitch.Dispose ();
                NotificationsEnableSwitch = null;
            }

            if (NotSoundSwitch != null) {
                NotSoundSwitch.Dispose ();
                NotSoundSwitch = null;
            }

            if (NotsPerEventLabel != null) {
                NotsPerEventLabel.Dispose ();
                NotsPerEventLabel = null;
            }

            if (NotsPerEventStepper != null) {
                NotsPerEventStepper.Dispose ();
                NotsPerEventStepper = null;
            }
        }
    }
}