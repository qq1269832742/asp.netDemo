using System;
namespace WorkDemo.Models
{
    interface ICrud
    {
        System.Collections.Generic.List<Info> Add(System.Collections.Generic.List<Info> infos, int Pid);
        int Add(People user);
        void Deleted(People pp);
        System.Collections.Generic.List<People> Find();
        System.Collections.Generic.List<Info> Find(int id);
        People Update(People pp);

        System.Collections.Generic.List<People> FindByName(string p);
    }
}
