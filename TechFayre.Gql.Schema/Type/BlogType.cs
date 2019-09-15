using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechFayre.Gql.Models;
using TechFayre.Gql.Models.Entities;

namespace TechFayre.Gql.Schemas.Type
{
    public class BlogType: ObjectGraphType<Blog>
    {

        public BlogType(IBlogRepository blogRepository)
        {
            Field(o => o.Id, type: typeof(IdGraphType));
            Field(o => o.Title);
            Field(o => o.Author);

            //Field<ListGraphType<CommentType>>(nameof(Blog.Comments));

            //Field(o => o.Comments, false, typeof(CommentType)).Resolve(ResolveComments);

            Field<ListGraphType<CommentType>>("Comments", resolve: context =>
            {
                return blogRepository.GetAllCommentsByBlogId(context.Source.Id);
            });


            //Field<ListGraphType<CommentType>>(
            //  "comments",
            //  arguments: new QueryArguments(
            //    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "blogId", Description = "Id of the blog you want to view comments from" }
            //  ),
            //  resolve: context =>
            //  {
            //      var blogId = context.GetArgument<int>("blogId");

            //      return blogRepository.GetAllCommentsByBlogId(blogId);
            //  }
            //);
        }

        private List<Comment> ResolveComments(ResolveFieldContext<Blog> context)
        {

            return context.Source.Comments;

            //var blogId = context.Source.Id;

            //return blogRepository.GetAllCommentsByBlogId(blogId);
        }
    }
}
