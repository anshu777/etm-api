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
using System.Web.Http.Cors;

namespace ETM.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
			//List<Roles> roles = _userService.GetRoles();
			return this.Request.CreateResponse(HttpStatusCode.OK);//, roles);
		}

		[HttpPost]
		[Route("api/user/login")]
		[AllowAnonymous]
		public async Task<HttpResponseMessage> Login(UserModel model)
		{
			 await _userService.Login(model.UserName, model.Password);
			return null;
		}
	}
}
