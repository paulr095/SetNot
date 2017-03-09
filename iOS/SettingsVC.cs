using Foundation;
using System;
using UIKit;

namespace Bhasvic10th.iOS
{
	public partial class SettingsVC : UITableViewController
    {
		public SettingsVC (IntPtr handle) : base (handle)
        {
        }

		public override void ViewWillAppear(bool animated)
		{
			SystemSettings settings = LocalBhasvicDB.getSystemSettings(LocalBhasvicDB.SettingsID);
			this.LastB4EventLabel.Text = settings.FinalWarningDelay.ToString();
			this.LastB4EventStepper.Value = settings.FinalWarningDelay;
			this.NotsPerEventLabel.Text = settings.NumberOfAlerts.ToString();
			this.NotsPerEventStepper.Value = settings.NumberOfAlerts;
			this.NotificationsEnableSwitch.On = settings.Alerts;
			this.NotSoundSwitch.On = settings.AlertSound;

			base.ViewWillAppear(animated);
		}



		partial void LastB4EventsChangedHandler(UIStepper sender)
		{
			this.LastB4EventLabel.Text = sender.Value.ToString();
			SystemSettings settings = LocalBhasvicDB.getSystemSettings(LocalBhasvicDB.SettingsID);
			settings.FinalWarningDelay = (int)sender.Value;
			LocalBhasvicDB.updateSystemSettingsTable(settings);
		}

		partial void NotsPerEventHandler(UIStepper sender)
		{
			this.NotsPerEventLabel.Text = sender.Value.ToString();
			SystemSettings settings = LocalBhasvicDB.getSystemSettings(LocalBhasvicDB.SettingsID);
			settings.NumberOfAlerts = (int)sender.Value;
			LocalBhasvicDB.updateSystemSettingsTable(settings);
		}

		partial void NotsEnableChangedHandler(UISwitch sender)
		{
			SystemSettings settings = LocalBhasvicDB.getSystemSettings(LocalBhasvicDB.SettingsID);
			settings.Alerts = sender.On;
			LocalBhasvicDB.updateSystemSettingsTable(settings);
		}

		partial void NotSoundOnSwitchHandler(UISwitch sender)
				{
			SystemSettings settings = LocalBhasvicDB.getSystemSettings(LocalBhasvicDB.SettingsID);
			settings.AlertSound = sender.On;
			LocalBhasvicDB.updateSystemSettingsTable(settings);
		}
	}
}