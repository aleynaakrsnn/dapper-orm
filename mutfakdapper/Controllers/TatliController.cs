using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using mutfakdapper.Models;


namespace mutfakdapper.Controllers
{
    public class TatliController : Controller
    {
        // GET: Tatli
        public ActionResult Index()
        {
            return View(DP.ReturnList<TatliModel>("TatliListele"));
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
                param.Add("@Tatli", id);
                return View(DP.ReturnList<TatliModel>("TatliSirala", param).FirstOrDefault<TatliModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(TatliModel tatli)
        {
            //view oluştuturken edit olanı seçiyoruz
            DynamicParameters param = new DynamicParameters();
            param.Add("@TatliNo", tatli.TatliNo);
            param.Add("@TatliAdi", tatli.TatliAdi);
            param.Add("@SosTercihi", tatli.SosTercihi);
         

            DP.ExecuteWReturn("TatliEY", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@TatliNo", id);
            DP.ExecuteWReturn("TatliSil", param);
            return RedirectToAction("Index");
        }
    }
}