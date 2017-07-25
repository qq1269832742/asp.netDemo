using System.Collections.Generic;
using System.Web.Mvc;
using WorkDemo.Models;
namespace WorkDemo.Controllers
{
    public class PracticeController : Controller
    {
       /// <summary>
       /// 调用封装好的CRUD
       /// </summary>
        ICrud crud = new Crud();

        /// <summary>
        /// 默认显示所有数据
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<People> list = crud.Find();
            ViewBag.list = list;

            return View();
        }
        /// <summary>
        /// 跳转添加页面
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Add()
        {

            return View();
        }
        /// <summary>
        /// 跳转录入添加页面
        /// </summary>
        /// <param name="People">需添加的用户信息</param>
        /// <returns>视图</returns>
        [HttpPost]
        public ActionResult ToAddEdu(People People)
        {
            int id = crud.Add(People);
            ViewBag.PeopleId = id;
            return View();
        }
        /// <summary>
        /// 录入完成
        /// </summary>
        /// <param name="p">需要用户里面的教育信息</param>
        /// <param name="Pid">教育信息的外键</param>
        /// <returns>视图</returns>
        [HttpPost]
        public ActionResult ToAddInfo(People p, int Pid)
        {
            crud.Add(p.List,Pid);

            return View();
        }
        /// <summary>
        /// 返回主界面
        /// </summary>
        /// <param name="pp">删除用户需要知道ID</param>
        /// <returns></returns>
        public ActionResult ToDeleteInfo( People pp)
        {
            crud.Deleted(pp);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 跳转查询教育信息页面
        /// </summary>
        /// <param name="Id">用户ID</param>
        /// <returns>视图</returns>
        public ActionResult ToFindInfo(int Id)
        {
            List<Info> list = crud.Find(Id);
            ViewBag.list = list;
            return View();
        }
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="People">用户信息</param>
        /// <returns>视图</returns>
        public ActionResult FindByName(People People)
        {
            ViewBag.list =  crud.FindByName(People.Name);  
            return View();
        }
    }
}
