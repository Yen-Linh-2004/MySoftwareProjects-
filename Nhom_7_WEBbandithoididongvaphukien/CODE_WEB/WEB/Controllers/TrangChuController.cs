using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class TrangChuController : Controller
    {
        QL_DIENTHOAIEntities4 db = new QL_DIENTHOAIEntities4();
        // GET: TrangChu
        public ActionResult Header()
        {
            return View();
        }
        public ActionResult Header1()
        {
            return View();
        }
        public ActionResult Banner()
        {
            return View();
        }
        public ActionResult Menu()
        {
            return View(db.DANHMUCs.ToList());
        }
        public ActionResult SapXep()
        {
            return View();
        }
        public ActionResult ChinhSach()
        {
            return View();
        }
        public ActionResult ThongtinHoTro()
        {
            return View();
        }
        public ActionResult ListFooter()
        {
            return View();
        }
        public ActionResult Footer()
        {
            return View();
        }
    }
}