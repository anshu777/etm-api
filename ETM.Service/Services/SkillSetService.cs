using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using ETM.Repository.Models;
using ETM.Service.Interfaces;

namespace ETM.Service.Services
{
	public class SkillSetService : ISkillSetService
	{
		public async Task<Technology> AddSkill(Technology skill)
		{
			try
			{
				using (var _context = new DatabaseContext())
				{
					_context.SkillSet.Add(skill);
					int x = await(_context.SaveChangesAsync());
				}
				return skill;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<Technology> Get(int skillId)
		{
			Technology technology = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					technology = await _context.SkillSet.Where(x => x.Id == skillId).FirstOrDefaultAsync<Technology>();
				}
				return technology;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<List<Technology>> GetSkills()
		{
			List<Technology> technology = null;
			try
			{
				using (var _context = new DatabaseContext())
				{
					technology = await _context.SkillSet.ToListAsync< Technology>();
				}
				return technology;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
