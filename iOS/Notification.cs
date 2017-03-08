using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SQLite;

namespace Bhasvic10th.iOS
{

	public class Notification
	{

		[PrimaryKey, AutoIncrement]
		public int NotificationID { get; set; }
		public int NewsItemID { get; set; }
		public bool Sound { get; set; }
		public bool NotificationBadge { get; set; }
		public string NotificationText { get; set; }
		public string NotificationDate { get; set; }
		public string DateOfFirstNotification { get; set; }
		public int NumberOfResends { get; set; }
		public int ResendInterval { get; set; }
	}





}
