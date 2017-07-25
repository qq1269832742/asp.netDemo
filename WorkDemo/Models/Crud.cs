using System.Collections.Generic;
using System.Linq;

namespace WorkDemo.Models
{
    public class Crud : ICrud
    {
        /// <summary>
        /// 使用ef工具类生成
        /// </summary>
        PracticeEntities2 Db = new PracticeEntities2();
       
        /// <summary>
        /// 查出所有用户
        /// </summary>
        /// <returns>list</returns>
        public List<People> Find()
        {
            List<People> list = Db.People.Where(ps => ps.Id != 0).ToList();

            return list;
        }
        /// <summary>
        /// 根据条件查找
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>list</returns>
        public List<Info> Find(int id )
        {
            List<Info> list = Db.Info.Where(f => f.Pid == id).ToList();

            return list;
        }
        /// <summary>
        /// 修改信息，没有写页面，先写好逻辑
        /// </summary>
        /// <param name="pp">获取的用户ID</param>
        /// <returns>user</returns>
        public People Update(People pp)
        {
            People user = Db.People.FirstOrDefault(ps => ps.Id == pp.Id);
            if (user != null)
            {
                user.Name = pp.Name;
                user.Phone = pp.Phone;
                user.Company = pp.Company;
                Db.SaveChanges();
            }
            return user;
        }
        /// <summary>
        /// 员工教育信息添加
        /// </summary>
        /// <param name="infos">教育经理</param>
        /// <param name="Pid">Info表外键</param>
        /// <returns>infos</returns>
        public List<Info> Add(List<Info> infos,int Pid)
        {
            foreach(Info info in infos){
                Db.Info.Add(new Info()
                {
                    EduSystem = info.EduSystem,
                    Education=info.Education,
                    EndTime=info.EndTime,
                    StartTime=info.StartTime,
                    School=info.School,
                    Pid = Pid           
                });
            }
            if (Db.SaveChanges() > 0)
            {
                return infos;
            }
            else
                return null;
           
        }
        /// <summary>
        /// 员工添加
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>Id</returns>
        public int Add(People user)
        {
          
            People pp = new People()
                {
                    Flag=0,
                    Name = user.Name,
                    Phone = user.Phone,
                    Country = user.Country,
                    Birthday = user.Birthday,
                    Department = user.Department,
                    Company = user.Company,
                    Nation = user.Nation,
                    Sex = user.Sex,
                    Card = user.Card
                };
                pp = Db.People.Add(pp);
                Db.SaveChanges();
                return pp.Id;
        }

        /// <summary>
        /// 员工删除,逻辑删除
        /// </summary>
        /// <param name="pp">用户信息</param>
        public void Deleted(People pp)
        {
            People user = Db.People.FirstOrDefault(ps => ps.Id == pp.Id);
            if (user != null)
            {
                user.Flag= 1;
                Db.SaveChanges();
            }

        }
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="str">输入字符串，用于查询是否有此姓名</param>
        /// <returns></returns>
        public List<People> FindByName(string str)
        {
            List<People> list = Db.People.Where(pp => pp.Name.Contains(str)).ToList();

            return list;
        }
    }
}