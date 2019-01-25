using ETM.Repository.Models;
using ETM.Service;
using ETM.Service.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Results;
using WebAPI.Models;
using System.Data.Entity;
using System.Linq;

namespace ETM.Web
{
	public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
	{
		//private IUserService _userService;

		//public ApplicationOAuthProvider(IUserService userService)
		//{

		//	_userService = userService;
		//}

		//public ApplicationOAuthProvider()
		//{

		//}
		public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			//context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

			context.Validated();
		}

		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
			context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, PUT, DELETE, POST, OPTIONS" });
			context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Content-Type, Accept, Authorization, X-Custom-Header" });
			context.Response.Headers.Add("Access-Control-Max-Age", new[] { "1728000" });

			try
			{
				using (var _context = new DatabaseContext())
				{
					//	var userStore = new UserStore<ApplicationUser>(_context);
					//	var manager = new UserManager<ApplicationUser>(userStore);
					//	var user = await _context.UserModel.FindAsync(context.UserName, context.Password);
					//}
					var user = await _context.UserModel.Where(x => x.UserName == context.UserName && x.Password == context.Password)
								.FirstOrDefaultAsync<UserModel>();

					if (user != null)
					{
						var identity = new ClaimsIdentity(context.Options.AuthenticationType);
						identity.AddClaim(new Claim("Username", user.UserName));
						identity.AddClaim(new Claim("Email", user.Email));
						identity.AddClaim(new Claim("FirstName", user.FirstName));
						identity.AddClaim(new Claim("LastName", user.LastName));
                        identity.AddClaim(new Claim("EmpId", user.EmpId.ToString()));
                        identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
						var userRoles = await (from u in _context.UserRoles
											   join r in _context.Roles
											   on u.RoleId equals r.Id
											   where u.UserId == user.Id
											   select new { r.Name }).ToListAsync();

						List<string> userRoleList = new List<string>();
						 userRoles.ForEach(x =>
						{
							userRoleList.Add(x.Name);
						});
											 
						foreach (string role in userRoleList)
						{
							identity.AddClaim(new Claim(ClaimTypes.Role, role));
						}
                        var additionalData = new AuthenticationProperties(new Dictionary<string, string>{
                        {
                            "role", Newtonsoft.Json.JsonConvert.SerializeObject(userRoles)
                        },
                        {
                            "empid",Newtonsoft.Json.JsonConvert.SerializeObject(user.EmpId)
                        },
                        {
                            "teamid",Newtonsoft.Json.JsonConvert.SerializeObject(1)
                        }
                        });
						var token = new AuthenticationTicket(identity, additionalData);
						context.Validated(token);
					}
					else
						return;
				}
			}
			catch (Exception ex)
			{
				return;
			}
		}

		public override Task TokenEndpoint(OAuthTokenEndpointContext context)
		{
			foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
			{
				context.AdditionalResponseParameters.Add(property.Key, property.Value);
			}

			return Task.FromResult<object>(null);
		}
	}
}