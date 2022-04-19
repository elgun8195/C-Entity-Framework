using C_Sharp_Entity_Framework.DAL;
using C_Sharp_Entity_Framework.Exceptions;
using C_Sharp_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Sharp_Entity_Framework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddPost();
            //GetAllPost();


            //try
            //{
            //    EditPostByTitle(5, "Elgusn");
            //}
            //catch (NullReferenceException ex)
            //{
            //    throw new NullReferenceException(ex.Message);
            //}
            //catch (NotFoundException ex)
            //{
            //    throw new NotFoundException(ex.Message);
            //}

            //try
            //{
            //    DeletePostById(1);
            //}
            //catch (NullReferenceException ex)
            //{

            //    throw new NullReferenceException(ex.Message);
            //}
            //catch (NotFoundException ex)
            //{
            //    throw new NotFoundException(ex.Message);
            //}

            try
            {
                GetPostById(1);
            }
            catch (NullReferenceException ex)
            {

                throw new NullReferenceException(ex.Message);
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
        }

        static void AddPost()
        {
            Post post = new Post()
            {
                Title = "Test1 title",
                Content = "Test1 content",
                Image = "Path1 image"
            };

            using (AppDbContext dbContext = new AppDbContext())
            {
                dbContext.Posts.Add(post);
                dbContext.SaveChanges();
            }
            Console.WriteLine($"{post.Title} created!");
        }

        static void GetAllPost()
        {
            using (AppDbContext dbContext = new AppDbContext())
            {
                List<Post> posts = dbContext.Posts.ToList();
                Console.WriteLine($"Post list:");
                foreach (var post in posts)
                {
                    Console.WriteLine($"Id: {post.Id} - Title: {post.Title} - Contend: {post.Content} - Image: {post.Image}");
                }
            }
        }

        static void GetPostById(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("Id Null Ola Bilmez");
            }
            using (AppDbContext dbContext = new AppDbContext())
            {
                Post posts = dbContext.Posts.FirstOrDefault(x => x.Id == id);
                if (posts == null)
                {
                    throw new NotFoundException("Post Tapilmadi");
                }
                Console.WriteLine($"Id: {posts.Id} - Title: {posts.Title} - Contend: {posts.Content} - Image: {posts.Image}");
            }
        }

        static void EditPostByTitle(int? id, string title)
        {
            if (id == null)
            {
                throw new NullReferenceException("Id Null Ola Bilmez");
            }
            using (AppDbContext dbContext = new AppDbContext())
            {
                Post dbPost = dbContext.Posts.FirstOrDefault(p => p.Id == id);
                if (dbPost == null)
                {
                    throw new NotFoundException("Post Not Found");
                }

                dbPost.Title = $"{title}";
                dbContext.SaveChanges();
            }

        }

        static void DeletePostById(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("Id Null Ola Bilmez");

            }
            using (AppDbContext dbContext = new AppDbContext())
            {
                Post dbPost = dbContext.Posts.FirstOrDefault(p => p.Id == id);
                if (dbPost == null)
                {
                    throw new NotFoundException("Post Not Found");

                }

                dbContext.Posts.Remove(dbPost);
                dbContext.SaveChanges();
                Console.WriteLine($"{id}-li Post silindi!");
            }

        }
    }
}
