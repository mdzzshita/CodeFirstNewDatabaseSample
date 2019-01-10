using StudentClass.DataAccessLayer;
using StudentClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass.BusinessLayer
{
   public class RemoveBusinessLayer
    {
        public void Add(Remove remove)
        {
            using (var db = new RemovegingContext())
            {
                

                //或者将实体状态为添加
                db.Entry(remove).State = EntityState.Added;

                //保存状态改变
                db.SaveChanges();
                
            }
        }

        public List<Remove> Query()
        {
            using (var db = new RemovegingContext())
            {
               
                var query = from b in db.Removes
                            orderby b.RemoveName
                            select b;
               
                return query.ToList();
            }
        }

        public void Update(Remove remove)
        {
            using (var db = new RemovegingContext())
            {
                
                db.Entry(remove).State = EntityState.Modified;
                //保存状态
                db.SaveChanges();
            }
        }

        public Remove Query(int id)
        {
            using (var db = new RemovegingContext())
            {
                return db.Removes.Find(id);
            }
        }

        public void Delete(Remove remove)
        {
            using (var db = new RemovegingContext())
            {
               
                db.Entry(remove).State = EntityState.Deleted;
                ////或者
                //db.Blogs.Remove(blog);
                //保存状态
                db.SaveChanges();
            }
        }
    }
}
