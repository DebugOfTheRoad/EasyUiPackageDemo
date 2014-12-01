using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyUiDemo.Controllers
{
    public class TreeGridController : Controller
    {
        //
        // GET: /TreeGrid/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<UserInfo> ulist = new List<UserInfo>();
            for (int i = 0; i < 20;++i )
            {
                UserInfo model = new UserInfo();
                model.Id = i;
                model.Name = "孙悟空" + i.ToString();
                model.CeratedBy = "System";
                model.CreatedTime = DateTime.Now;
                ulist.Add(model);
            }
            List<UserInfo> ulist2 = new List<UserInfo>();
            for (int i = 0; i < 20; ++i)
            {
                UserInfo model = new UserInfo();
                model.Id = i;
                model.Name = "孙悟空" + i.ToString();
                model.CeratedBy = "System";
                model.CreatedTime = DateTime.Now;
                ulist2.Add(model);
            }

            List<UserInfo> ulist3 = new List<UserInfo>();
            UserInfo u1 = new UserInfo
            {
                Id = 100,
                Name = "用户组1",
                Pwd = "",
                state = "closed",
                children = ulist
            };

            UserInfo u2 = new UserInfo
            {
                Id = 200,
                Name = "用户组2",
                state = "closed",
                Pwd = "",
                children = ulist2
            };

            ulist3.Add(u1);
            ulist3.Add(u2);

            int total = ulist3.Count;
            var result = new { total = total, rows = ulist3 };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }

    public class UserInfo
    {
        public UserInfo()
        {
            children = new List<UserInfo>();
        }
        public string state { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        public string CeratedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public List<UserInfo> children { get; set; }
    }
}
