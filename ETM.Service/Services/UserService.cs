using ETM.Repository.Models;
using ETM.Service.Interfaces;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ETM.Service.Services
{
	public class UserService : IUserService
	{
		public UserModel GetUserClaims(IEnumerable<Claim> claims)
		{

			return new UserModel();
			//{
			//	UserName = claims.FindFirst("Username").Value,
			//	Email = claims.FindFirst("Email").Value,
			//	FirstName = identityClaims.FindFirst("FirstName").Value,
			//	LastName = identityClaims.FindFirst("LastName").Value,
			//	LoggedOn = identityClaims.FindFirst("LoggedOn").Value
			//};
		}

		public IdentityResult Register(UserModel userModel)
		{
			IdentityResult result = null;
			using (var _context = new DatabaseContext())
			{
				//var userStore = new UserStore<ApplicationUser>(_context);
				//var manager = new UserManager<ApplicationUser>(userStore);
				//var user = new ApplicationUser() { UserName = userModel.UserName, Email = userModel.Email };
				//user.FirstName = userModel.FirstName;
				//user.LastName = userModel.LastName;
				//manager.PasswordValidator = new PasswordValidator
				//{
				//	RequiredLength = 3
				//};

				//result = manager.Create(user, userModel.Password);
				//manager.AddToRoles(user.Id, userModel.Roles);
			}
			
			return result;
		}

		public async Task<List<string>> GetRolesById(int userId)
		{
			List<string> roles = null;
			using (var _context = new DatabaseContext())
			{
				//var roleStore = new RoleStore<IdentityRole>(_context);
				//var roleMngr = new RoleManager<IdentityRole>(roleStore);

				//roles = roleMngr.Roles
				//	.Select(x => new Roles { Id= x.Id, Name = x.Name })
				//	.ToList();
			}
			return roles;
		}

		public async Task<UserModel> Login(string username, string password)
		{
			UserModel user;
			using (var _context = new DatabaseContext())
			{
				user = await _context.UserModel.FindAsync(username, password);
			}
			return user;
		}
	}
}
