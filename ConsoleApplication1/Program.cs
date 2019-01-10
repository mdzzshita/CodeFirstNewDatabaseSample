using ConsoleApplication1.BusinessLayer;
using ConsoleApplication1.DataAccessLayer;
using ConsoleApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //QueryBlog();
            ////创建一个新博客
            //CreateBlog();
            ////更新某个博客
            //Updata();
            ////删除某个博客
            //Delete();
            ////显示所有博客

            //AddPost();
            //UpdataPost();
            //DeletePost();
            //Start();
            GetBlogName();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
           
        }

        static void GetBlogName()
        {
            Console.WriteLine("输入查询的博客名称:");
            string name = Console.ReadLine();
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            var query = bbl.Query(name);
            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }

        }
        static void Start()
        {
            QueryBlog();
            Console.WriteLine("--1、退出--  --2、新增博客--  --3、更改博客--  --4、删除博客--  --5、操作帖子--");
            Console.WriteLine("请输入操作指令：");
            int i = int.Parse(Console.ReadLine());
            if(i==1)
            {
                return;
            }
            if(i==2)
            {
                CreateBlog();
                QueryBlog();
                Console.Clear();
                Start();
            }
            if (i == 3)
            {
                Updata();
                QueryBlog();
                Console.Clear();
                Start();
            }
            if (i == 4)
            {
                Delete();
                QueryBlog();
                Console.Clear();
                Start();
            }
            if (i == 5)
            {
                int blogId = GetBlogId();
                DisplayPosts(blogId);
                Start();
            }

        }

        /// <summary>
        /// 新增帖子
        /// </summary>
        static void AddPost()
        {
            //显示博客列表
            QueryBlog();
            //用户选择某个博客（id）
            int blogId= GetBlogId();
            //显示指定博客的帖子列表
            DisplayPosts(blogId);
            //根据指定到博客信息创建新帖子 

            //新建帖子
            Post post = new Post();
            //填帖子属性
            Console.WriteLine("请输入要加的帖子标题");
            post.Title= Console.ReadLine();
            Console.WriteLine("请输入要加的帖子内容");
            post.Content = Console.ReadLine();
            post.BlogId = blogId;
            //帖子通过数据上下文新增
            using (var db = new BloggingContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }

            //显示指定博客的帖子列表
            DisplayPosts(blogId);
        }

        /// <summary>
        /// 修改帖子
        /// </summary>
        static void UpdataPost()
        {
            //显示博客列表
            QueryBlog();
            //用户选择某个博客（id）
            int blogId = GetBlogId();
            //显示指定博客的帖子列表
            DisplayPosts(blogId);
            
            int postId = GetPostId();
            PostBusinessLayer pbl = new PostBusinessLayer();
            Post post = pbl.Query(postId);
            Console.Write("请输入新帖子标题：");
            string title = Console.ReadLine();
            Console.WriteLine("请输入新帖子帖子内容");
            string content = Console.ReadLine();
            post.Title = title;
            post.Content = content;
            using (var db = new BloggingContext())
            {
                
                db.Entry(post).State = EntityState.Modified;
                
                db.SaveChanges();
            }
            //显示指定博客的帖子列表
            DisplayPosts(blogId);
        }

        /// <summary>
        /// 删除帖子
        /// </summary>
        static void DeletePost()
        {
            //显示博客列表
            QueryBlog();
            //用户选择某个博客（id）
            int blogId = GetBlogId();
            //显示指定博客的帖子列表
            DisplayPosts(blogId);

            int postId = GetPostId();
            PostBusinessLayer pbl = new PostBusinessLayer();
            Post post = pbl.Query(postId);
            using (var db = new BloggingContext())
            {
                db.Entry(post).State = EntityState.Deleted;
                db.SaveChanges();
            }
            //显示指定博客的帖子列表
            DisplayPosts(blogId);
        }

        static int GetBlogId()
        {
            Console.WriteLine("输入选择的博客Id:");
            int id = int.Parse(Console.ReadLine());
            return id;
        }

        static int GetPostId()
        {
            Console.WriteLine("输入操作帖子的Id:");
            int id = int.Parse(Console.ReadLine());
            return id;
        }

        static void DisplayPosts(int blogId)
        {
            Console.WriteLine(blogId + "的帖子列表");
           
            List<Post> list = null;
            //根据博客id获取博客
            using (var db = new BloggingContext())
            {
                Blog blog = db.Blogs.Find(blogId);
                //根据博客导航属性，获取所有该博客的帖子
                list = blog.Posts;
            }
            
                
            //遍历所有帖子，显示帖子标题（博客号-帖子标题）
            foreach(var item in list)
            {
                Console.WriteLine("博客号:"+item.Blog.BlogId + "  " + "帖子标题:" + item.Title + "  " + "帖子内容:" + item.Content+"  " + "帖子Id:" + item.PostId);
            }


        }

        /// <summary>
        /// 创建一个新博客
        /// </summary>
        static void CreateBlog()
        {
            //创建一个新博客
            Console.Write("请输入一个新博客名：");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            bbl.Add(blog);
        }

        /// <summary>
        /// 显示所有博客
        /// </summary>
        static void QueryBlog()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            //显示所有数据库中博客
            var query = bbl.Query();
            Console.WriteLine("所有数据库中的博客：");
            foreach(var item in query)
            {
                Console.Write("博客号（Id）:"+item.BlogId + " ");
                Console.WriteLine("博客名:"+item.Name);
            }
        }

        /// <summary>
        /// 更新某个博客
        /// </summary>
        static void Updata()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.Write("请输入一个修改博客ID：");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            Console.Write("请输入新博客名：");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }

        /// <summary>
        /// 删除某个博客
        /// </summary>
        static void Delete()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.Write("请输入一个删除博客ID：");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
        }
    }
}
