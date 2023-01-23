using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using mutfakdapper.Models;

namespace mutfakdapper.Controllers
{
    public class FastFoodController : Controller
    {
        // GET: FastFood
        public ActionResult Index()
        {
            return View(DP.ReturnList<FastFoodModel>("FastFoodListele"));
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
                param.Add("@FastFoodNo", id);
                return View(DP.ReturnList<FastFoodModel>("FastFoodSirala", param).FirstOrDefault<FastFoodModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(FastFoodModel fastfood)
        {
            //view oluştuturken edit olanı seçiyoruz
            DynamicParameters param = new DynamicParameters();
            param.Add("@FastFoodNo", fastfood.FastFoodNo);
            param.Add("@FastFoodAdi", fastfood.FastFoodAdi);
            param.Add("@FastFoodMenu", fastfood.FastFoodMenu); 
            param.Add("@PatatesTercihi", fastfood.PatatesTercihi);
            param.Add("@CikarilanMalzeme", fastfood.CikarilanMalzeme);
            param.Add("@EkstraMalzeme", fastfood.EkstraMalzeme);

            DP.ExecuteWReturn("FastFoodEY", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@FastFoodNo", id);
            DP.ExecuteWReturn("FastFoodSil", param);
            return RedirectToAction("Index");
        }

    }
}