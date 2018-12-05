using ETM.Service.Interfaces;
using ETM.Web.Common;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace ETM.Web.Controllers
{
	
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
    }
}
