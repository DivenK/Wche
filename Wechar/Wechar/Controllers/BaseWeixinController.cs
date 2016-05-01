using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Wechar.Controllers
{
    public class BaseWeixinController : Controller
    {
        public static string appID=System.Configuration.ConfigurationManager.AppSettings["appID"];
        public static string appsecret= System.Configuration.ConfigurationManager.AppSettings["appsecret"];
        public static string Url = "https://api.weixin.qq.com/cgi-bin/token";
        public static string GetToken = string.Empty;

        public BaseWeixinController()
        {
            if (string.IsNullOrWhiteSpace(GetToken))
            {
                GetToken = GetTokenAction();
            }
        }
        // GET: BaseWeixin


        private   string GetTokenAction()
        {
            if (!string.IsNullOrWhiteSpace(appID) && !string.IsNullOrWhiteSpace(appsecret))
            {
                string postDataStr =string.Format("grant_type={0}&appid={1}&secret={2}","client_credential", appID,appsecret);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream myResponseStream = response.GetResponseStream())
                {
                    using (StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8")))
                    {
                        string retString = myStreamReader.ReadToEnd();
                        retString=retString.Replace("/","");
                        string[] resArry = retString.Split(',');
                      
                        return retString = resArry[0];

                    }
                }
            }
            return null;
        }
    }
}