using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Globalization;


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

		public override void ViewWillDisappear(bool animated)
		{
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
			if (!settings.Alerts)
			{
				NotificationHelper.cancelAllLocalNotifications();
			}
		}

		partial void NotSoundOnSwitchHandler(UISwitch sender)
				{
			SystemSettings settings = LocalBhasvicDB.getSystemSettings(LocalBhasvicDB.SettingsID);
			settings.AlertSound = sender.On;
			LocalBhasvicDB.updateSystemSettingsTable(settings);
		}

		//partial void LoadTestEvent_TouchUpInside(UIButton sender)
		//{
		//	List<Notification> allCurrentNotifications = LocalBhasvicDB.getAllNotifications();
		//	var notification = new Notification();
		//	notification.NotificationID = allCurrentNotifications.Count + 1;
		//	notification.AlertAction = "Init Action";
		//	notification.AlertBody = "Test Event";
		//	notification.AlertTitle = "Bhasvic Event";
		//	notification.NewsItemID = 1;
		//	notification.NotificationBadge = true;
		//	//notification.NotificationDate = DateTime.Now.AddMinutes(1).ToLongDateString();
		//	notification.NotificationDate = DateTime.Now.Date.ToString("yyyy-MM-dd") + "T" + DateTime.Now.AddMinutes(1).ToString("HH:mm:ss");//"2017-03-11T17:22:00";
		//	notification.Sound = true;
		//	LocalBhasvicDB.updateNotificationTable(notification);
		//	NotificationHelper.cancelAllLocalNotifications();
		//	List<Notification> localNotificationItems = LocalBhasvicDB.getAllNotifications();
		//	SystemSettings settings = LocalBhasvicDB.getSystemSettings(1);
		//	foreach (var localNotification in localNotificationItems)
		//	{
		//		NotificationHelper.createLocalIOSNotification(localNotification, settings);
		//	}

		//}
	}
}