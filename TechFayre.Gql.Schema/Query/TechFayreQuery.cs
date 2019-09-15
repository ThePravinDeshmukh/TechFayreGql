using GraphQL.Types;
using TechFayre.Gql.Models;
using TechFayre.Gql.Models.Entities;
using TechFayre.Gql.Schemas.Type;

namespace TechFayre.Gql.Schemas
{
    public class TechFayreQuery : ObjectGraphType
    {
        public TechFayreQuery(IBlogRepository blogRepository)
        {
            //Field<ListGraphType<BlogType>>("blogs", resolve: context => blogRepository.GetAllBlogs(0,null,null));

            Field<ListGraphType<BlogType>>("blogs",
              arguments: new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "id" },
                new QueryArgument<StringGraphType> { Name = "title", Description = "Title of the blog" },
                new QueryArgument<StringGraphType> { Name = "author", Description = "Author name of the blog" }
              ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var title = context.GetArgument<string>("title");
                    var author = context.GetArgument<string>("author");

                    return blogRepository.GetAllBlogs(id, title, author);
                });

            Field<BlogType>(
              "blog",
              arguments: new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "id" }
              ),
              resolve: context =>
              {
                  var id = context.GetArgument<int>("id");

                  return blogRepository.GetBlogById(id);
              }
            );

            Field<ListGraphType<CommentType>>(
              "comments",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "blogId", Description="Id of the blog you want to view comments from" }
              ),
              resolve: context =>
              {
                  var blogId = context.GetArgument<int>("blogId");

                  return blogRepository.GetAllCommentsByBlogId(blogId);
              }
            );
            
        }
    }
}