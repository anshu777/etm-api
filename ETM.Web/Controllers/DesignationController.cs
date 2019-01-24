using ETM.Service.Interfaces;
using ETM.Web.Common;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace ETM.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DesignationController : ApiController
    {
        private IDesignationService _designationService;

        public DesignationController(IDesignationService designationService)
        {
            _designationService = designationService;
        }
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _designationService.GetAllDesignation();
                return this.JsonDataResult(result);
            }
            catch (Exception e)
            {
                //Logger.Log(LogLevel.Error, e);
                return new InternalServerErrorResult(this);
            }
        }

		[Route("api/designation/getsummarybydesignation")]
		public async Task<IHttpActionResult> GetSummaryByDesignation()
		{
			try
			{
				var result = await _designationService.GetSummaryByDesignation();
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
