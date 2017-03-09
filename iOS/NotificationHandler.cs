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

        public static void createLocalIOSNotification(Notification n, SystemSettings settings)
        {
			var notification = new UILocalNotification();

			notification.FireDate = (NSDate) DateTime.ParseExact(n.NotificationDate, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
			notification.AlertAction = n.AlertAction;
			notification.AlertBody = n.AlertBody;
			notification.ApplicationIconBadgeNumber = 1;
			if (n.AlertSound | settings.AlertSound) 
			{
				notification.SoundName = UILocalNotification.DefaultSoundName;
			}

			UIApplication.SharedApplication.ScheduleLocalNotification(notification);
		}
		
		public static string generateFireDateString(string dateOfEvent, int finalWarningDelay, int daysBefore)
		{
			
		}
		
		public static string generateFireDateString(string notificationDate)
		{
		}
	}
}
