using ETM.Repository.Dto;
using ETM.Service.Interfaces;
using ETM.Web.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace ETM.Web.Controllers
{
    //
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
       
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
		[Route("api/employee/getlist")]
		public async Task<IHttpActionResult> GetList()
        {
            try
            {
                var result = await _employeeService.GetAllEmployee();
                return this.JsonDataResult(result);
            }
            catch (Exception e)
            {
                //Logger.Log(LogLevel.Error, e);
                return new InternalServerErrorResult(this);
            }
        }
		
		[HttpGet]
		[Route("api/employee/getByDesignationId/{id}")]
        public async Task<IHttpActionResult> GetByDesignationId(int id)
        {
            try
            {
                var result = await _employeeService.GetByDesignationId(id);
                return this.JsonDataResult(result);
            }
            catch (Exception e)
            {
                //Logger.Log(LogLevel.Error, e);
                return new InternalServerErrorResult(this);
            }
        }

		[Route("api/employee/get/{id}")]
		public async Task<IHttpActionResult> GetById(int id)
		{
			try
			{
				var result = await _employeeService.GetById(id);
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}


		/// <summary>
		/// Returns id and name only
		/// </summary>
		/// <returns></returns>
		[Route("api/employee/getoptionlist")]
		public async Task<IHttpActionResult> GetOptionList()
		{
			try
			{
				var result = await _employeeService.GetOptionList();
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}


        [HttpPost]
		public async Task<IHttpActionResult> Post([FromBody]EmployeeDto esheet)
        {
            try
            {
                var result = await _employeeService.AddEmployee(esheet);
                return this.JsonDataResult(result);
            }
            catch (Exception e)
            {
                //Logger.Log(LogLevel.Error, e);
                return new InternalServerErrorResult(this);
            }
        }

        [HttpPut]
        [Route("api/employee/put")]
        public async Task<IHttpActionResult> Put([FromBody]EmployeeDto edto)
        {
            try
            {
                var result = await _employeeService.UpdateEmployee(edto);
                return this.JsonDataResult(result);
            }
            catch(Exception e)
            {
                return new InternalServerErrorResult(this);
            }
        }

		[Route("api/employee/getallbyclients")]
		public async Task<IHttpActionResult> GetAllByClients()
		{
			try
			{
				var result = await _employeeService.GetAllByClients();
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

		[Route("api/employee/getallbysalary")]
		public async Task<IHttpActionResult> GetAllBySalary()
		{
			try
			{
				var result = await _employeeService.GetAllBySalary();
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

		[Route("api/employee/getallbyriskstatus")]
		public async Task<IHttpActionResult> GetAllByRiskStatus()
		{
			try
			{
				var result = await _employeeService.GetAllByRiskStatus();
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

		[Route("api/employee/getallbyreportingstructure")]
		public async Task<IHttpActionResult> GetAllByReportingStructure()
		{
			try
			{
				var result = await _employeeService.GetAllByReportingStructure();
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

		[Route("api/employee/getsummarybytechnology")]
		public async Task<IHttpActionResult> GetSummaryByTechnology()
		{
			try
			{
				var result = await _employeeService.GetSummaryByTechnology();
				return this.JsonDataResult(result);
			}
			catch (Exception e)
			{
				//Logger.Log(LogLevel.Error, e);
				return new InternalServerErrorResult(this);
			}
		}

		[Route("api/employee/getdetailbytechnology")]
		public async Task<IHttpActionResult> GetDetailByTechnology()
		{
			try
			{
				var result = await _employeeService.GetDetailByTechnology();
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
