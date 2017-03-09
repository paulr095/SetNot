using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace Bhasvic10th.iOS
{
	public partial class HomeVC : UITableViewController
	{
		

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
				var settings = new SystemSettings();
				settings.ID = 1;
				settings.Alerts = true;
				settings.AlertSound = true;
				settings.FinalWarningDelay = 10;
				settings.NumberOfAlerts = 1;
				LocalBhasvicDB.updateSystemSettingsTable(settings);
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
