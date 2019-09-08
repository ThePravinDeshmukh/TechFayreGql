using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using TechFayre.Gql.Models.Entities;

namespace TechFayre.Gql.Schemas.Type
{
    public class BlogType: ObjectGraphType<Blog>
    {
        public BlogType()
        {
            Field(o => o.Id, type: typeof(IdGraphType));
            Field(o => o.Title);
            Field(o => o.Author);
            Field<ListGraphType<CommentType>>(nameof(Blog.Comments));

            //Field(o => o.Comments, false, typeof(CommentType)).Resolve(ResolveComment);
        }

        //private Comment ResolveComment(ResolveFieldContext<Comment> context)
        //{
        //    var message = context.Source;
        //    return message.c;
        //}
    }
}
