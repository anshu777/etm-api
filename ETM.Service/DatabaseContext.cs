using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETM.Repository.Models;

namespace ETM.Service
{
	//public class ApplicationUser : IdentityUser
	//{
	//	public string FirstName { get; set; }
	//	public string LastName { get; set; }
	//}
	public partial class DatabaseContext : DbContext // IdentityDbContext<ApplicationUser>
	{
		public DatabaseContext()
			: base("name=ETMDBContext") //, throwIfV1Schema: false)
		{
			Configuration.LazyLoadingEnabled = false;
		}

		public DbSet<Employee> Employee { get; set; }
		public DbSet<Team> Team { get; set; }
		public DbSet<EmployeeTask> EmployeeTask { get; set; }
		public DbSet<Client> Client { get; set; }
		public DbSet<Project> Project { get; set; }
		public DbSet<Timesheet> TimeSheet { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<Designation> Designation { get; set; }
		public DbSet<SkillSet> SkillSet { get; set; }
		public DbSet<UserModel> UserModel { get; set; }
		public DbSet<ProjectSkills> ProjectSkills { get; set; }
		public DbSet<ProjectResource> ProjectResource { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//AspNetUsers -> User
			//modelBuilder.Entity<ApplicationUser>()
			//	.ToTable("User");
			////AspNetRoles -> Role
			//modelBuilder.Entity<IdentityRole>()
			//	.ToTable("Role");
			////AspNetUserRoles -> UserRole
			//modelBuilder.Entity<IdentityUserRole>()
			//	.ToTable("UserRole");
			////AspNetUserClaims -> UserClaim
			//modelBuilder.Entity<IdentityUserClaim>()
			//	.ToTable("UserClaim");
			////AspNetUserLogins -> UserLogin
			//modelBuilder.Entity<IdentityUserLogin>()
			//	.ToTable("UserLogin");

			// for many to many relationships, create a transition-mapping table, 
			// with no entity
			//modelBuilder.Entity<Project>()
			//	.HasMany(x => x.Teams)
			//	.WithMany(x => x.)
			//	.Map(m =>
			//	{
			//		m.ToTable("project_team");
			//		m.MapLeftKey("project_id");
			//		m.MapRightKey("team_id");
			//	});
		}
	}
}
