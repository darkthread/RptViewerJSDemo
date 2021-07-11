using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;

namespace DemoWeb.Controllers
{
    public class MvcApiController : Controller
    {
        public ActionResult SaveParam(string st, string ed, string s)
        {
            var key = Guid.NewGuid().ToString();
            MemoryCache.Default.Add(key, new Dictionary<string, string>
            {
                ["st"] = st,
                ["ed"] = ed,
                ["s"] = s
            }, DateTime.Now.AddSeconds(30));
            return Content(key);
        }
    }
}