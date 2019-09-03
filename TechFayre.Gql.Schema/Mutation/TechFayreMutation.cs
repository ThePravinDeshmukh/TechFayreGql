using GraphQL.Types;
using TechFayre.Gql.Models;
using TechFayre.Gql.Models.Entities;
using TechFayre.Gql.Schemas.InputType;
using TechFayre.Gql.Schemas.Type;

namespace TechFayre.Gql.Schemas
{
    public class TechFayreMutation : ObjectGraphType
    {
        public TechFayreMutation(PostRepository postRepository)
        {
            Field<PostType>("CreatePost",
    arguments: new QueryArguments(
        new QueryArgument<PostInputType> { Name = "post" }
    ),
    resolve: context =>
    {
        var post = context.GetArgument<Post>("post");
        var postOut = postRepository.CreatePost(post);
        return postOut;
    });
        }
    }
}