using System;
using Foundation;
using UIKit;

namespace Bhasvic10th.iOS
{
	public static class NotificationHandler
	{
		static NotificationHandler()
		{
		}

        public static void createLocalIOSNotification(Notification n)
        {
			// create the notification
			var notification = new UILocalNotification();

			// set the fire date (the date time in which it will fire)
			notification.FireDate = NSDate.FromTimeIntervalSinceNow(10);

			// configure the alert
			notification.AlertAction = n.AlertAction;
			notification.AlertBody = n.AlertBody;

			// modify the badge
			notification.ApplicationIconBadgeNumber = 1;

			if (n.AlertSound == true) 
			{
				notification.SoundName = UILocalNotification.DefaultSoundName;
			}


			// schedule it
			UIApplication.SharedApplication.ScheduleLocalNotification(notification);
			Console.WriteLine("Scheduled...");

		}
		
		public static string generateFireDateString(string dateOfEvent, int finalWarningDelay, int daysBefore)
		{
		}
		
		public static string generateFireDateString(string notificationDate)
		{
		}
	}
}
