using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskM.Models;

namespace TaskM.Controllers
{
    public class UsersController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: Users
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var usersView = new List<Usuario>();
            foreach(var user in users)
            {
                var userView = new Usuario
                {
                    Email = user.Email,
                    Nome = user.UserName,
                    UserId = user.Id
                };
                usersView.Add(userView);
            }
            return View(usersView);
        }

        public ActionResult AddRole(string userId)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();

            var user = users.Find(u => u.Id == userId);
            var userView = new Usuario
            {
                Email = user.Email,
                Nome = user.UserName,
                UserId = user.Id,
             
            };

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var list = roleManager.Roles.ToList();
            list.Add(new IdentityRole { Id = "", Name = "[Selecione uma Permissão!]" });
            list = list.OrderBy(c => c.Name).ToList();
            ViewBag.RoleId = new SelectList(list, "Id", "Name");

            return View(userView);
        }

            public ActionResult Roles(string userId)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();      

            var user = users.Find(u => u.Id == userId);

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var roles = roleManager.Roles.ToList();
            var rolesView = new List<Permissoes>();

            foreach (var item in user.Roles)
            {
                var role = roles.Find(r => r.Id == item.RoleId);
                var roleView = new Permissoes
                {
                    IdPermissao = role.Id,
                    Name = role.Name
                };
                rolesView.Add(roleView);

            }

            

            var userView = new Usuario
            {
                Email = user.Email,
                Nome = user.UserName,
                UserId = user.Id,
                Permissoes = rolesView
            };
            return View(userView);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}