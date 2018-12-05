using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETM.Web.Common
{
	public class DataActionResult<T> where T : class
	{
		public DataActionResult()
		{
			Errors = new List<DataError>();
		}
		public T Data { get; set; }
		public int TotalRowCount { get; set; }
		public List<DataError> Errors { get; set; }

		public void AddError(ErrorType type, String message)
		{
			var error = new DataError()
			{
				ErrorType = type,
				ErrorMessage = message
			};
			Errors.Add(error);
		}
	}

	public enum ErrorType
	{
		Info,
		Warning,
		Error
	}

	public class DataError
	{
		public ErrorType ErrorType { get; set; }
		public string ErrorMessage { get; set; }
	}
}