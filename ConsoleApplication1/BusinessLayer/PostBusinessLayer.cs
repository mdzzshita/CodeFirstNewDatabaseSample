using ConsoleApplication1.DataAccessLayer;
using ConsoleApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.BusinessLayer
{
    public class PostBusinessLayer
    {
        public Post Query(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Posts.Find(id);
            }
        }
        public List<Post> Query(string name)
        {
            using (var db = new BloggingContext())
            {
                //Linq查询所有的博客，以博客名为排序依序返回数据集
                var query = from b in db.Posts
                            orderby b.Title.Contains(name)
                            select b;
                //将数据集转换为列表
                return query.ToList();
            }
        }
    }
}
