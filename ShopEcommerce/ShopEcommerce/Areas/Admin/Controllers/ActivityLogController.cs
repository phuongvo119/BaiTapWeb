using ShopEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopEcommerce.Areas.Admin.Controllers {
    public class ActivityLogController : AdminBaseController {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ActivityLog
        public ActionResult Index() {
            var items = db.LoginSessions.Include("UserCreated").ToList();
            return View(items);
        }
    }
}