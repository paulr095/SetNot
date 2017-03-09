using SQLite;

namespace Bhasvic10th.iOS
{
	public class SystemSettings
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public bool Alerts { get; set;}
		public bool AlertSound { get; set; }
		public int NumberOfAlerts { get; set; }
		public int FinalWarningDelay { get; set; }
	}
}
