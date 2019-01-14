using ETM.Repository.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ETM.Service.Interfaces
{
	public interface IUserService
	{
		UserModel GetUserClaims(IEnumerable<Claim> claims);
		IdentityResult Register(UserModel user);
		Task<List<string>> GetRolesById(int userId);
		//Task<List<Roles>> GetRoles();
		Task<UserModel> Login(string username, string password);
	}
}
