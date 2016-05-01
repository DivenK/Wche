using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wechar.Controllers
{
    public class WeiXinController :BaseWeixinController
    {
        // GET: WeiXin
        public ActionResult Index()
        {
            string toKen = GetToken;
            return View();
        }
    }
}