using ETM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Service.Interfaces
{
	public interface IDashboardService
	{
		Task<List<TaskTimeDto>> GetTaskTimeChart(int month, int year, int teamId);
	}
}
