using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace EasyUiDemo.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            ViewBag.MenueName = "系统权限";
            return View();
        }

        public ActionResult Tree()
        {
            List<Cnode> cn1 = new List<Cnode>();
            attribute a = new attribute
            {
                //icon = "icon-save",
                icon = "",
                aurl = "http://www.baidu.com",
                desc = "这是个描述"
            };
            cn1.Add(new Cnode
            {
                id = 11,
                text = "设置权限",
                attributes = a,
            });
            cn1.Add(new Cnode
            {
                id = 12,
                text = "设置角色",
                attributes = a,
            });
            cn1.Add(new Cnode
            {
                id = 13,
                text = "设置分组",
                attributes = a,
            });
            cn1.Add(new Cnode
            {
                id = 14,
                text = "开通帐号",
                attributes = a,
            });
            //================
            List<Cnode> cn2 = new List<Cnode>();
            cn2.Add(new Cnode
            {
                id = 21,
                text = "设置权限2",
                attributes = a,
            });
            cn2.Add(new Cnode
            {
                id = 22,
                text = "设置角色2",
                attributes = a,
            });
            cn2.Add(new Cnode
            {
                id = 23,
                text = "设置分组2",
                attributes = a,
            });
            cn2.Add(new Cnode
            {
                id = 24,
                text = "开通帐号2",
                attributes = a,
            });

//             Pnode n1 = new Pnode
//             {
//                 id = 1,
//                 text = "用户管理",
//                 children = cn1
//             }; 
            List<Pnode> plist = new List<Pnode>();
         
            plist.Add(new Pnode
            {
                id = 1,
                text = "用户管理",
                attributes = a,
                //iconCls = "icon-save",
                children = cn1
            });
          
            plist.Add(new Pnode{
                id=2,
                text = "用户管理2",
                state = "closed",
                //iconCls = "icon-save",
                attributes = a,
                children = cn2
            });

            string result =JsonConvert.SerializeObject(plist);
       
            return Content(result, "application/json");
        }

        public ActionResult Check()
        {
            string data = "11,14,22,23";
            return Content(data, "text");
        }
       
    }

    public class Pnode
    {
        public Pnode()
        {
            children = new List<Cnode>();
            attributes = new attribute();
        }
        public int id { get; set; }
        public string text { get; set; }
        public string state { get; set; }
        public bool Checked { get; set; }
        public string iconCls { get; set; }
        public attribute attributes { get; set; }
        public List<Cnode> children { get; set; }
    }
    public class Cnode
    {
        public Cnode()
        {
            attributes = new attribute();
        }
        public int id { get; set; }
        public string text { get; set; }
        public string state { get; set; }
        public bool Checked { get; set; }
        public string iconCls { get; set; }
        public attribute attributes { get; set; }
    }

    public class attribute
    {
        public string icon { get; set; }

        public string aurl { get; set; }

        public string desc { get; set; }
    }
}
