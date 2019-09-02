using GraphQL.Types;
using TechFayre.Gql.Models;
using TechFayre.Gql.Models.Entities;
using TechFayre.Gql.Schemas.Type;

namespace TechFayre.Gql.Schemas
{
    public class TechFayreQuery : ObjectGraphType
    {
        public TechFayreQuery(PostRepository postsRepository)
        {
            Field<ListGraphType<PostType>>("posts", resolve: context => postsRepository.GetAllPosts());

            Field<ListGraphType<PostType>>("post", resolve: context => postsRepository.GetPostById(0));
        }
    }
}