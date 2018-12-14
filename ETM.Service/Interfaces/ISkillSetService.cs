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
		Task<List<SkillSet>> GetSkills();
		Task<SkillSet> Get(int skillid);
		Task<SkillSet> AddSkill(SkillSet skill);
	}
}
