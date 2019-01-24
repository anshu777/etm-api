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
    public class CategoryController : ApiController
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _categoryService.GetAllCategory();
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
