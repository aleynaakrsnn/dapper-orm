using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mutfakdapper.Models
{
    public class AnaYemekModel
    {

        public int YemekNo { get; set; }
        public string YemekAdi { get; set; }
        public int YemekAdedi { get; set; }
        public string CikarilanMalzeme { get; set; }
        public string EkstraMalzeme { get; set; }
    }
}