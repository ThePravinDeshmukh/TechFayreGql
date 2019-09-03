using RestSharp;
using System;
using System.Collections.Generic;
using TechFayre.Gql.Models.Entities;

namespace TechFayre.Gql.Models
{
    public class PostRepository
    {
        RestClient client = new RestClient("http://localhost:3003");

        public List<Post> GetAllPosts()
        {
            var request = new RestRequest("posts", Method.GET);

            IRestResponse<List<Post>> response2 = client.Execute<List<Post>>(request);

            return response2.Data;
        }

        public Post GetPostById(int Id)
        {
            var request = new RestRequest("posts/{id}", Method.GET);
            request.AddUrlSegment("id", Id);

            IRestResponse<Post> response2 = client.Execute<Post>(request);

            return response2.Data;
        }

        public Post CreatePost(Post post)
        {
            var request = new RestRequest("posts", Method.POST);
            request.AddJsonBody(post);

            IRestResponse<Post> response2 = client.Execute<Post>(request);

            return response2.Data;
        }
    }
}
