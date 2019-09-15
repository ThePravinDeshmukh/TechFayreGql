using RestSharp;
using System;
using System.Collections.Generic;
using TechFayre.Gql.Models.Entities;

namespace TechFayre.Gql.Models
{

    public interface IBlogRepository
    {
        Blog CreateBlog(BlogBase blog);

        Comment CreateComment(Comment comment);

        List<Blog> GetAllBlogs(int id, string title, string author);

        List<Comment> GetAllCommentsByBlogId(int blogId);

        Blog GetBlogById(int Id);
    }

    public class BlogRepository : IBlogRepository
    {
        RestClient client = new RestClient("http://localhost:3003");

        public List<Blog> GetAllBlogs(int id, string title, string author)
        {
            // http://localhost:3003/blogs/?_embed=comments
            var request = new RestRequest("blogs", Method.GET);

            if (id != 0)
                request.AddParameter("id", id);
            if (!string.IsNullOrEmpty(title))
                request.AddParameter("Title", title);
            if (!string.IsNullOrEmpty(author))
                request.AddParameter("Author", author);

            IRestResponse<List<Blog>> response2 = client.Execute<List<Blog>>(request);

            return response2.Data;
        }

        public Blog GetBlogById(int Id)
        {
            var request = new RestRequest("blogs/{id}/", Method.GET);
            request.AddUrlSegment("id", Id);

            IRestResponse<Blog> response2 = client.Execute<Blog>(request);

            return response2.Data;
        }

        public Blog CreateBlog(BlogBase blog)
        {
            var request = new RestRequest("blogs", Method.POST);

            request.AddJsonBody(blog);

            IRestResponse<Blog> response = client.Execute<Blog>(request);

            return response.Data;
        }

        public Comment CreateComment(Comment comment)
        {

            var request = new RestRequest($"blogs/{comment.BlogId}/comments", Method.POST);
            request.AddJsonBody(comment.ToParent());

            IRestResponse<Comment> response = client.Execute<Comment>(request);

            return response.Data;
        }

        public List<Comment> GetAllCommentsByBlogId(int blogId)
        {
            // http://localhost:3003/blogs/?_embed=comments
            var request = new RestRequest("comments/", Method.GET);

            request.AddParameter("blogId", blogId);

            IRestResponse<List<Comment>> response2 = client.Execute<List<Comment>>(request);

            return response2.Data;
        }
    }
}
