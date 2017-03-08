using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SQLite;
//using SQLiteNetExtensions;
//using SQLiteNetExtensions.Attributes;

namespace Bhasvic10th.iOS
{
	public class SystemSettings
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
	//	[ForeignKey(typeof(ChosenCategories))]
		public bool Alerts { get; set;}
	//	[ManyToOne]
	//	public ChosenCategories ChosenCategories { get; set;}
		public int NumberOfAlerts { get; set; }
		public int FinalWarningDelay { get; set; }

	}
}
