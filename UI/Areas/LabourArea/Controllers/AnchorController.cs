using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeFunModel;
using Newtonsoft.Json;
namespace UI.Areas.LabourArea.Controllers
{
    public class AnchorController : Controller
    {
        // GET: LabourArea/Anchor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetData()
        {
            //layui.table 格式必须
            string JsonStr = "{\"code\": 0,\"msg\": \"\",\"count\": 1000,\"data\": ";
            List<Announcer> anlist = new List<Announcer>();
            using (MyContext context = new MyContext())
            {
                anlist = context.Announcer.Where(x => x.State == 0).ToList();
            }
            string strJson = JsonConvert.SerializeObject(anlist);
            JsonStr += strJson + "}";
            return Content(JsonStr);
        }
    }
}