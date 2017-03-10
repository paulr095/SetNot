using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Globalization;


namespace Bhasvic10th.iOS
{
	public partial class HomeVC : UITableViewController
	{
		
		public int SettingsID = 1;

		public HomeVC(IntPtr handle) : base(handle)
		{
		}
		public override  void ViewWillAppear(bool animated)
		{
			Console.WriteLine(ChosenCategories.ChosenCategory);
			TableView.Source = new HomeTableSource(LocalBhasvicDB.getCatItemList(ChosenCategories.ChosenCategory));
			base.ViewWillAppear(animated);

		}
		public override async void ViewDidLoad()
		{



			base.ViewDidLoad();

			NewsItemGrabber _newsItemGrabber;
			_newsItemGrabber = new NewsItemGrabber();
			//LocalBhasvicDB.dropNewsItemTable();
			LocalBhasvicDB.createNewsItemTable();
			var jsonString = await _newsItemGrabber.getNews();
			Console.WriteLine(jsonString);
			LocalBhasvicDB.updateDBWithJSON(jsonString);
			Console.WriteLine(LocalBhasvicDB.getItemList());

			if (LocalBhasvicDB.getTableInfo("AlertCategory").Count == 0)
			{
				LocalBhasvicDB.createAlertCategoryTable();
				var alertCat = new AlertCategory();
				foreach (var category in ChosenCategories.categories)
				{
					alertCat.Alert = true;
					alertCat.Category = category;
					LocalBhasvicDB.updateAlertCategoryTable(alertCat);
				}
			}

			if (LocalBhasvicDB.getTableInfo("SystemSettings").Count == 0)
			{
				LocalBhasvicDB.createSettingsItemTable();
				var s = new SystemSettings();
				s.ID = SettingsID;
				s.Alerts = true;
				s.AlertSound = true;
				s.FinalWarningDelay = 10;
				s.NumberOfAlerts = 1;
				LocalBhasvicDB.updateSystemSettingsTable(s);
			}

			if (LocalBhasvicDB.getTableInfo("Notification").Count == 0)
			{
				LocalBhasvicDB.createNotificationTable();
			}


			NotificationHelper.cancelAllLocalNotifications();
			SystemSettings settings = LocalBhasvicDB.getSystemSettings(SettingsID);
			List<NewsItem> eventItems = LocalBhasvicDB.getEventList();
			int i = 1;
			foreach (var eventItem in eventItems)
			{
				Notification n = new Notification();
				n.NotificationID = i; i++;
				n.AlertAction = "Random";
				n.AlertBody = eventItem.DateOfEvent + ": " + eventItem.Summary;
				n.AlertTitle = "Bhasvic Event";
				n.NewsItemID = eventItem.ID;
				n.NotificationBadge = true;
				n.NotificationDate = eventItem.NotificationDate;
				n.Sound = settings.AlertSound;
				LocalBhasvicDB.updateNotificationTable(n);
			}


			var notification = new Notification();
			notification.NotificationID = i; i++;
			notification.AlertAction = "Init Action";
			notification.AlertBody = "Test Body";
			notification.AlertTitle = "Bhasvic Event";
			notification.NewsItemID = 1;
			notification.NotificationBadge = true;
			//notification.NotificationDate = DateTime.Now.AddMinutes(1).ToLongDateString();
			notification.NotificationDate = "2017-03-10T16:12:00";
			notification.Sound = true;
			LocalBhasvicDB.updateNotificationTable(notification);






			List<Notification> localNotificationItems = LocalBhasvicDB.getAllNotifications();
			foreach (var localNotification in localNotificationItems)
			{
				NotificationHelper.createLocalIOSNotification(localNotification, settings);
			}
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "HomeEventsSegue")
			{ // set in Storyboard
				var navctlr = segue.DestinationViewController as HomeItemDetailedVCz;
				if (navctlr != null)
				{
					var source = TableView.Source as HomeTableSource;
					var rowPath = TableView.IndexPathForSelectedRow;
					var item = source.GetItem(rowPath.Row);
					navctlr.SetTask(this, item);

				}
			}
		}
	}

}
