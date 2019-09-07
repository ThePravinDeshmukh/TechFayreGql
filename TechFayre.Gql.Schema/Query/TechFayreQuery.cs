using GraphQL.Types;
using TechFayre.Gql.Models;
using TechFayre.Gql.Models.Entities;
using TechFayre.Gql.Schemas.Type;

namespace TechFayre.Gql.Schemas
{
    public class TechFayreQuery : ObjectGraphType
    {
        public TechFayreQuery(BlogRepository blogRepository)
        {
            Field<ListGraphType<BlogType>>("blogs", resolve: context => blogRepository.GetAllBlogs());

            Field<ListGraphType<BlogType>>("blog", resolve: context => blogRepository.GetBlogById(0));

            Field<ListGraphType<CommentType>>("comments", resolve: context => blogRepository.GetAllComments());
        }
    }
}