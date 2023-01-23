using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using mutfakdapper.Models;


namespace mutfakdapper.Controllers
{
    public class IcecekController : Controller
    {
        // GET: Icecek
        public ActionResult Index()
        {
            return View(DP.ReturnList<IcecekModel>("IcecekListele"));
        }
        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View();

            }

            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@IcecekNo", id);
                return View(DP.ReturnList<IcecekModel>("IcecekSirala", param).FirstOrDefault<IcecekModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(IcecekModel icecek)
        {
            //view oluştuturken edit olanı seçiyoruz
            DynamicParameters param = new DynamicParameters();
            param.Add("@IcecekNo", icecek.IcecekNo);
            param.Add("@IcecekAdi", icecek.IcecekAdi);
            param.Add("@Adet", icecek.Adet);
    

            DP.ExecuteWReturn("IcecekEY", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@IcecekNo", id);
            DP.ExecuteWReturn("IcecekSil", param);
            return RedirectToAction("Index");
        }

    }
}