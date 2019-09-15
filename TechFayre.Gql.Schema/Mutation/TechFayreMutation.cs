using GraphQL.Types;
using TechFayre.Gql.Models;
using TechFayre.Gql.Models.Entities;
using TechFayre.Gql.Schemas.InputType;
using TechFayre.Gql.Schemas.Type;

namespace TechFayre.Gql.Schemas
{
    public class TechFayreMutation : ObjectGraphType
    {
        public TechFayreMutation(IBlogRepository blogRepository)
        {
            BlogMutation(blogRepository);

            CommentMutation(blogRepository);
        }

        private void BlogMutation(IBlogRepository blogRepository)
        {
            Field<BlogType>("CreateBlog",
            arguments: new QueryArguments(
                new QueryArgument<BlogInputType> { Name = "blog" }
            ),
            resolve: context =>
            {
                var blog = context.GetArgument<BlogBase>("blog");
                var blogOut = blogRepository.CreateBlog(blog);

                return blogOut;
            });
        }

        private void CommentMutation(IBlogRepository blogRepository)
        {
            Field<CommentType>("CreateComment",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<CommentInputType>> { Name = "comment" }
            ),
            resolve: context =>
            {
                var comment = context.GetArgument<Comment>("comment");
                var commentOut = blogRepository.CreateComment(comment);

                return commentOut;
            });

        }
    }
}