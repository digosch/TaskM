using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TaskM.Models;
using static System.Data.Entity.Migrations.Model.UpdateDatabaseOperation;

namespace TaskM
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            //  Database.SetInitializer(new MigrateDatabaseToLatestVersion<Models.ApplicationDbContext, Migration.Configuration>());
            ApplicationDbContext db = new ApplicationDbContext();
            CriarRoles(db);
            CriarSuperUser(db);
            AddPermissoesSuperUser(db);
            db.Dispose();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void AddPermissoesSuperUser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName("admin@admin.com");
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if(!userManager.IsInRole(user.Id, "Admin"))
            {
                userManager.AddToRole(user.Id, "Admin");
            }
            if (!userManager.IsInRole(user.Id, "User"))
            {
                userManager.AddToRole(user.Id, "User");
            }
         
        }

        private void CriarSuperUser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName("admin@admin.com");

            if(user == null)
            {
                user = new ApplicationUser
                {
                    Nome = "admin",
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };
                userManager.Create(user, "Admin*1");
            }
        }

        private void CriarRoles(ApplicationDbContext db)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if(!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }
            if (!roleManager.RoleExists("User"))
            {
                roleManager.Create(new IdentityRole("User"));
            }
        
        }
    }
}
