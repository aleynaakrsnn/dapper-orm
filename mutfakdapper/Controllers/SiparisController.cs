using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using mutfakdapper.Models;

namespace mutfakdapper.Controllers
{
    public class SiparisController : Controller
    {
        // GET: Siparis
        public ActionResult Index()
        {
            return View(DP.ReturnList<SiparisModel>("SiparisListele"));
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
                param.Add("@SiparisNo", id);
                return View(DP.ReturnList<IcecekModel>("SiparisSirala", param).FirstOrDefault<IcecekModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(IcecekModel siparis)
        {
            //view oluştuturken edit olanı seçiyoruz
            DynamicParameters param = new DynamicParameters();
            param.Add("@SiparisNo", siparis.IcecekNo);
            param.Add("@SiparisAdi", siparis.IcecekAdi);
            param.Add("@SiparisAdresi", siparis.Adet);
            param.Add("@SiparisTelefon", siparis.Adet);


            DP.ExecuteWReturn("SiparisEY", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@SiparisNo", id);
            DP.ExecuteWReturn("SiparisSil", param);
            return RedirectToAction("Index");
        }

    }
}