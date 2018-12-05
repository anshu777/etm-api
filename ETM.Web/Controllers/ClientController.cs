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
	
	public class ClientController : ApiController
    {
		private IClientService _clientService;
		public ClientController(IClientService clientService)
		{
			_clientService = clientService;
		}

		[HttpGet]
		[Route("api/client/getlist")]
		public async Task<IHttpActionResult> GetList()
		{
			try
			{
				var result = await _clientService.GetClients();
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
