using ETM.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Service.Interfaces
{
	public interface ISkillSetService
	{
		Task<List<Technology>> GetSkills();
		Task<Technology> Get(int skillid);
		Task<Technology> AddSkill(Technology skill);
	}
}
