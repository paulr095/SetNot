using System;
using System.Globalization;
using Foundation;
using UIKit;

namespace Bhasvic10th.iOS
{
	public static class NotificationHelper
	{
		static NotificationHelper()
		{
		}

		public static NSDate DateTimeToNSDate(this DateTime date)
		{
			DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(
				new DateTime(2001, 1, 1, 0, 0, 0));
			return NSDate.FromTimeIntervalSinceReferenceDate(
				(date - reference).TotalSeconds);
		}

        public static void createLocalIOSNotification(Notification n, SystemSettings settings)
        {
			if (settings.Alerts)
			{
				var notification = new UILocalNotification();

				notification.FireDate = DateTime.ParseExact(n.NotificationDate, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture).DateTimeToNSDate();
				notification.AlertAction = n.AlertAction;
				notification.AlertBody = n.AlertBody;
				notification.ApplicationIconBadgeNumber = 1;
				if (n.Sound | settings.AlertSound)
				{
					notification.SoundName = UILocalNotification.DefaultSoundName;
				}

				UIApplication.SharedApplication.ScheduleLocalNotification(notification);
				Console.WriteLine("Local Notification Count: " + UIApplication.SharedApplication.ScheduledLocalNotifications.Length.ToString());
			}
		}
		
		public static string generateFireDateString(string dateOfEvent, int finalWarningDelay, int daysBefore)
		{
			return "";
		}
		
		public static string generateFireDateString(string notificationDate)
		{
			return "";
		}

		public static void cancelAllLocalNotifications()
		{
			UIApplication.SharedApplication.CancelAllLocalNotifications();
		}
	}
}
