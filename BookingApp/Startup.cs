using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MvcUserRoles.Models;
using Owin;
using System.Data.Entity.Validation;
using System.Diagnostics;

[assembly: OwinStartupAttribute(typeof(MvcUserRoles.Startup))]
namespace MvcUserRoles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        private void createRolesandUsers()
        {
            var context = ApplicationDbContext.Create();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));



            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin role   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "admin1@gmail.com";
                user.Email = "admin1@gmail.com";
                user.Name = "Admin1";
                
                string userPWD = "admin1";
                var chkUser = UserManager.Create(user, userPWD);


                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // Creating Traveler role  

            if (!roleManager.RoleExists("Traveler"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Traveler";
                roleManager.Create(role);

                //Here we create a Traveler user                   

                var user = new ApplicationUser();
                user.UserName = "traveler1@gmail.com";
                user.Email = "traveler1@gmail.com";
                user.Name = "Traveler1";
                string userPWD = "traveler1";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Traveler");

                }
                //Here we create a Traveler user                   

                user = new ApplicationUser();
                user.UserName = "traveler2@gmail.com";
                user.Email = "traveler2@gmail.com";
                user.Name = "Traveler2";
                userPWD = "traveler2";

                chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Traveler");

                }
            }

            if (!roleManager.RoleExists("Owner"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Owner";
                roleManager.Create(role);

                //Here we create an Owner user                   

                var user = new ApplicationUser();
                user.UserName = "owner1@gmail.com";
                user.Email = "owner1@gmail.com";
                user.Name = "Owner1";
                string userPWD = "owner1";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Owner");

                }

                //Here we create an Owner user                   

                user = new ApplicationUser();
                user.UserName = "owner2@gmail.com";
                user.Email = "owner2@gmail.com";
                user.Name = "Owner2";
                userPWD = "owner2";

                chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Owner");

                }
            }

        }
    }
}
