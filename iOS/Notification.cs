using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SQLite;

namespace Bhasvic10th.iOS
{

	public class Notification
	{

		[PrimaryKey]
		public int NotificationID { get; set; }
		public int NewsItemID { get; set; }
		public bool Sound { get; set; }
		public bool NotificationBadge { get; set; }
		public string AlertAction { get; set; }
		public string AlertBody { get; set; }
		public string AlertTitle { get; set; }
		public string NotificationDate { get; set; }
	}





}
