using StudentClass.BusinessLayer;
using StudentClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryRemove();
            CreateRemove();
            //Updata();
            //Delete();
            QueryRemove();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }

        static void AddStudent()
        {

        }

        static void CreateRemove()
        {
            
            Console.Write("请输入一个班级名称：");
            string name = Console.ReadLine();
            Remove remove = new Remove();
            remove.RemoveName = name;
            RemoveBusinessLayer rbl = new RemoveBusinessLayer();
            rbl.Add(remove);
        }

        static void QueryRemove()
        {
            RemoveBusinessLayer rbl = new RemoveBusinessLayer();
            
            var query = rbl.Query();
            Console.WriteLine("所有数据库中的班级：");
            foreach (var item in query)
            {
                Console.Write(item.RemoveId + " ");
                Console.WriteLine(item.RemoveName);
            }
        }

        static void Updata()
        {
            RemoveBusinessLayer rbl = new RemoveBusinessLayer();
            Console.Write("请输入要修改班级ID：");
            int id = int.Parse(Console.ReadLine());
            Remove remove = rbl.Query(id);
            Console.Write("请输入新班级名：");
            string name = Console.ReadLine();
            remove.RemoveName = name;
            rbl.Update(remove);
        }

        static void Delete()
        {
            RemoveBusinessLayer rbl = new RemoveBusinessLayer();
            Console.Write("请输入删除班级ID：");
            int id = int.Parse(Console.ReadLine());
            Remove remove = rbl.Query(id);
            rbl.Delete(remove);
        }
    }
}
