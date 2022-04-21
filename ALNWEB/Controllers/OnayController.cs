using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Data;
using ALNWEB.Models;
using System.IO;


namespace ALNWEB.Controllers
{
    public class OnayController : Controller
    {
        ALANSISEntities db = new ALANSISEntities();


        // GET: Onay
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Onay(int id)
        {
            using (var db = new ALANSISEntities())
            {
                var onay = db.EO_ALANSIS_SATIS.Find(id);

                onay.URETIM_ONAY = "NOK";
                db.SaveChanges();
                return View();
            }

        }
        public ActionResult Onaylist(int sayfa = 1)
        {
            var degerler = db.EO_ALANSIS_SATIS.ToList().ToPagedList(sayfa, 20);
            return View(degerler);
        }
    }
}