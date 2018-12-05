using ETM.Repository.Models;
using ETM.Service.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ETM.Web.Controllers
{
	public class UserController : ApiController
	{
		private IUserService _userService;
		public UserController(IUserService userService)
		{

			_userService = userService;
		}

		[HttpGet]
		
		[Route("api/user/getuserclaims")]
		public UserModel GetUserClaims()
		{
			var identityClaims = (ClaimsIdentity)User.Identity;
			IEnumerable<Claim> claims = identityClaims.Claims;
			return new UserModel()
			{
				UserName = identityClaims.FindFirst("Username").Value,
				Email = identityClaims.FindFirst("Email").Value,
				FirstName = identityClaims.FindFirst("FirstName").Value,
				LastName = identityClaims.FindFirst("LastName").Value,
				LoggedOn = identityClaims.FindFirst("LoggedOn").Value
			};
			//return _userService.GetUserClaims(claims);
		}


		[Route("api/user/register")]
		[HttpPost]
		[AllowAnonymous]
		public IdentityResult Register(UserModel model)
		{
			return _userService.Register(model);
		}

		[HttpGet]
		[Route("api/user/getallroles")]
		[AllowAnonymous]
		public HttpResponseMessage GetRoles()
		{
			List<Roles> roles = _userService.GetRoles();
			return this.Request.CreateResponse(HttpStatusCode.OK, roles);
		}

		[HttpPost]
		[Route("api/user/login")]
		[AllowAnonymous]
		public async Task<HttpResponseMessage> Login(UserModel model)
		{
			var request = HttpContext.Current.Request;
			var tokenServiceUrl = request.Url.GetLeftPart(UriPartial.Authority) + request.ApplicationPath + "/api/Token";
			using (var client = new HttpClient())
			{
				var requestParams = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("grant_type", "password"),
				new KeyValuePair<string, string>("username", model.UserName),
				new KeyValuePair<string, string>("password", model.Password)
			};
				var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
				var tokenServiceResponse = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
				var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();
				var responseCode = tokenServiceResponse.StatusCode;
				var responseMsg = new HttpResponseMessage(responseCode)
				{
					Content = new StringContent(responseString, Encoding.UTF8, "application/json")
				};
				return responseMsg;
			}

			//return await _userService.Login(username, password);
		}
	}
}
