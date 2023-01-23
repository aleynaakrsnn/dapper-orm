using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using mutfakdapper.Models;

namespace mutfakdapper.Controllers
{
    public class AnaYemekController : Controller
    {
        // GET: AnaYemek
        public ActionResult Index()
        {
            return View(DP.ReturnList<AnaYemekModel>("AnaYemekListele"));
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
                param.Add("@YemekNo", id);
                return View(DP.ReturnList<AnaYemekModel>("AnaYemekSirala", param).FirstOrDefault<AnaYemekModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(AnaYemekModel anayemek)
        {
            //view oluştuturken edit olanı seçiyoruz
            DynamicParameters param = new DynamicParameters();
            param.Add("@YemekNo", anayemek.YemekNo);
            param.Add("@YemekAdi", anayemek.YemekAdi);
            param.Add("@YemekAdedi", anayemek.YemekAdedi);
            param.Add("@CikarilanMalzeme", anayemek.CikarilanMalzeme);
            param.Add("@EkstraMalzeme", anayemek.EkstraMalzeme);

            DP.ExecuteWReturn("AnaYemekEY", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@YemekNo", id);
            DP.ExecuteWReturn("AnaYemekSil", param);
            return RedirectToAction("Index");
        }


    }
}