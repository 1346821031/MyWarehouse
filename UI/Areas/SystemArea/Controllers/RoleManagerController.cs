using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeFunModel;
using Newtonsoft.Json;
namespace UI.Areas.SystemArea.Controllers
{
    public class RoleManagerController : Controller
    {
        // GET: SystemArea/RoleManager
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult GetData()
        {
            //layui.table 格式必须
            string JsonStr = "{\"code\": 0,\"msg\": \"\",\"count\": 1000,\"data\": ";
            List<SysRoles> list = new List<SysRoles>();
            using (MyContext context = new MyContext())
            {
                //string sqlstr = "select * from SysRoles where RoleState = 1";
                ////方式一
                //list= context.SysRoles.SqlQuery(sqlstr).ToList();
                list = context.SysRoles.ToList();
            }
            string strJson = JsonConvert.SerializeObject(list);
            JsonStr += strJson + "}";
            return Content(JsonStr);
        }
        public ActionResult AlterState(int RoleID) {
            int i;
            using (MyContext context = new MyContext())
            {
                SysRoles sysRoles = context.SysRoles.Where(x => x.RoleID == RoleID).FirstOrDefault();
                sysRoles.RoleState = 0;
                i = context.SaveChanges();
            }
            return Content(i.ToString());
        }
        public ActionResult DeleteState(int RoleID)
        {
            int i;
            using (MyContext context = new MyContext())
            {
                SysRoles sysRoles = context.SysRoles.Where(x => x.RoleID == RoleID).FirstOrDefault();
                context.SysRoles.Remove(sysRoles);
                i = context.SaveChanges();
            }
            return Content(i.ToString());
        }
        public ActionResult ADD()
        {

            return View();
        }
        public ActionResult Addstate(SysRoles s) {

            int i;
            s.RoleState = 1;
            using (MyContext context = new MyContext())
            {
                context.SysRoles.Add(s);
                i = context.SaveChanges();
            }
            return Content(i.ToString());
        }

        public ActionResult Update(int ID) {
            using (MyContext context=new MyContext())
            {
                SysRoles sys = context.SysRoles.Where(x => x.RoleID == ID).FirstOrDefault();
                if (sys!=null) {
                    ViewBag.Sysrole = sys;
                }
            }
            return View();
        }
        public ActionResult Updates(SysRoles sys)
        {
            int i = 0;
            using (MyContext context = new MyContext())
            {
                SysRoles sysx = context.SysRoles.Where(x => x.RoleID == sys.RoleID).FirstOrDefault();
                sysx.RoleName = sys.RoleName;
                sysx.RoleDesc = sys.RoleDesc;
                sysx.RoleState = sys.RoleState;
                 i=   context.SaveChanges();
            }
            return Content(i.ToString());
        }

        //设置角色权限
        public ActionResult OpenPop(int RoleID) {
            ViewBag.RoleID = RoleID;
            return View();
        }

        public JsonResult GetPop(int RoleID)
        {
            List<SysPopedoms> list;
            using (MyContext context = new MyContext())
            {
                list = context.SysPopedoms.ToList();
            }
            var data = new
            {
                count = list.Count(),
                code = 0,//code码是必须要的， 0 表述返回的数据没有问题
                data = list,
                msg = "权限信息"//描述
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}