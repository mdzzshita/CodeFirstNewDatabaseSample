
using ConsoleApplication1.DataAccessLayer;
using ConsoleApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.BusinessLayer
{
   public class BlogBusinessLayer
    {
        public void Add(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                //向Blogs数据集添加一个实体
                db.Blogs.Add(blog);

                ////或者将实体状态为添加
                //db.Entry(blog).State = EntityState.Added;

                //保存状态改变
                db.SaveChanges();
            }
        }

        public List<Blog>Query()
        {
            using (var db = new BloggingContext())
            {
                //Linq查询所有的博客，以博客名为排序依序返回数据集
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;
                //将数据集转换为列表
                return query.ToList();
            }
        }

        public List<Blog> Query(string name)
        {
            using (var db = new BloggingContext())
            {
                // 查询所有包含字符串name的博客
                var blogs = from b in db.Blogs
                            where b.Name.Contains(name)
                            select b;
                return blogs.ToList();
            }
        }


        public void Update(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                //修改博客实体状态
                db.Entry(blog).State = EntityState.Modified;
                //保存状态
                db.SaveChanges();
            }
        }

        public Blog Query(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.Find(id);
            }
        }

        public void Delete(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                //修改博客实体状态
                db.Entry(blog).State = EntityState.Deleted;
                ////或者
                //db.Blogs.Remove(blog);
                //保存状态
                db.SaveChanges();
            }
        }
    }
}
