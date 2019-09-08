using RestSharp;
using System;
using System.Collections.Generic;
using TechFayre.Gql.Models.Entities;

namespace TechFayre.Gql.Models
{
    public class BlogRepository
    {
        RestClient client = new RestClient("http://localhost:3003");

        public List<Blog> GetAllBlogs()
        {
            // http://localhost:3003/blogs/?_embed=comments
            var request = new RestRequest("blogs/?_embed=comments", Method.GET);

            IRestResponse<List<Blog>> response2 = client.Execute<List<Blog>>(request);

            return response2.Data;
        }

        public Blog GetBlogById(int Id)
        {
            var request = new RestRequest("blogs/{id}/?_embed=comments", Method.GET);
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

        public object GetAllComments()
        {
            // http://localhost:3003/blogs/?_embed=comments
            var request = new RestRequest("comments/", Method.GET);

            IRestResponse<List<Comment>> response2 = client.Execute<List<Comment>>(request);

            return response2.Data;
        }
    }
}
