using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WeFunModel;
namespace UI.Areas.SystemArea.Controllers
{
    public class PopedomManagerController : Controller
    {
        // GET: SystemArea/PopedomManager
        public ActionResult Index()
        {
            return View();
        }


     

        public JsonResult GetData()
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

        public ActionResult ChangePopdomState(int PopID, int State) {
            int i;
            using (MyContext context=new MyContext())
            {
                SysPopedoms sys = context.SysPopedoms.Where(x => x.PopID == PopID).FirstOrDefault();
                sys.PopState = State;
                i = context.SaveChanges();
            }
            return Content(i.ToString());
        }

        public ActionResult ADDNode(int parentID)
        {
            ViewBag.parentID = parentID;
            return View();
        }
        //添加父级菜单
        public ActionResult AddParent(SysPopedoms sys) {
            int i;
            using (MyContext context=new MyContext())
            {
                 context.SysPopedoms.Add(sys);
                context.SaveChanges();
                //拿最后一个父节点最后一个元素


                int parent =Convert.ToInt32(sys.Parent);
                SysPopedoms s = context.SysPopedoms.Where(x=>x.Parent==parent).OrderByDescending(x=>x.PopID).FirstOrDefault();
                s.PopIndex = s.PopID;
                s.PopPath = s.PopID.ToString();
                i=  context.SaveChanges();
            }
            
           
            return Content(i.ToString());
        }
        //添加子级
        public ActionResult ADDNodesublevel() {
            List<SysPopedoms> list = new List<SysPopedoms>();
            using (MyContext context=new MyContext())
            {
             list=   context.SysPopedoms.Where(x => x.Parent == -1).ToList();

            }
            ViewBag.list = list;    
            return View();
        }
        public ActionResult Addsublevel(SysPopedoms sys) {
            int i;
            using (MyContext context=new MyContext())
            {
                //填充 区域area
                SysPopedoms s = context.SysPopedoms.Where(x => x.PopID == sys.Parent).FirstOrDefault();
                sys.PopArea = s.PopArea;
                
                //添加
                context.SysPopedoms.Add(sys);
                context.SaveChanges();

                //填充  poppath
                SysPopedoms  s1 = context.SysPopedoms.Where(x => x.Parent >0).OrderByDescending(x => x.PopID).FirstOrDefault();
               
                s1.PopPath = s.PopID+","+s1.PopID;
                i = context.SaveChanges();
            }
            return Content(i.ToString());
        }

        public ActionResult Deletes(int PopID) {
            int i;
            using (MyContext context=new MyContext())
            {
                SysPopedoms sys = context.SysPopedoms.Where(x => x.PopID == PopID).FirstOrDefault();
                context.SysPopedoms.Remove(sys);
                i=context.SaveChanges();
            }
            return Content(i.ToString());
        }
    }
}