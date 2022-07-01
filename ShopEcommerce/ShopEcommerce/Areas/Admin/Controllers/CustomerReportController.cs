using ShopEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopEcommerce.Areas.Admin.Controllers
{
    public class CustomerReportController : AdminBaseController {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/CustomerReport
        public ActionResult Index()
        {
            return View();
        }
    }
}