using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using TechFayre.Gql.Models.Entities;

namespace TechFayre.Gql.Schemas.Type
{
    public class PostType: ObjectGraphType<Post>
    {
        public PostType()
        {
            Field(o => o.Id);
            Field(o => o.Title);
            Field(o => o.Author);
            //Field(o => o.Comments, false, typeof(MessageFromType)).Resolve(ResolveFrom);
        }

        //private MessageFrom ResolveFrom(ResolveFieldContext<Message> context)
        //{
        //    var message = context.Source;
        //    return message.From;
        //}
    }
}
