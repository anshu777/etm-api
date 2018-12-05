using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETM.Repository
{
	public class Constants
	{
		public const string ConnectionName = "ETM";
		public const string Schema = "etm";

		public class TableNames
		{
			//Core Tables
			public const string Employee = "eployee";
			public const string Task = "task";
			public const string Timesheet = "timesheet";
			public const string Team = "team";
		}
	}
}