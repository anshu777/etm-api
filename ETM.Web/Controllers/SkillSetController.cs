using ETM.Repository.Models;
using ETM.Service.Interfaces;
using ETM.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace ETM.Web.Controllers
{
	
	public class SkillSetController : ApiController
    {
		private ISkillSetService _skillSetService;
		public SkillSetController(ISkillSetService skillSetService)
		{
			_skillSetService = skillSetService;
		}

		[HttpGet]
		[Route("api/skillset/getlist")]
		public async Task<IHttpActionResult> GetList()
		{
			try
			{
				var result = await _skillSetService.GetSkills();
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

        [HttpPost]
        public async Task<IHttpActionResult> PostSkillset(SkillSet skset)
        {

            try
            {
                var result = await _skillSetService.AddSkill(skset);
                return this.JsonDataResult(result);
            }
            catch (Exception e)
            {
                //Logger.Log(LogLevel.Error, e);
                return new InternalServerErrorResult(this);
            }

        }
	}
}
