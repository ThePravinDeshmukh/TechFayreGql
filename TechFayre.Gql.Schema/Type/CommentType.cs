using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using TechFayre.Gql.Models.Entities;

namespace TechFayre.Gql.Schemas.Type
{
    public class CommentType : ObjectGraphType<Comment>
    {
        public CommentType()
        {
            Field(o => o.Id);
            Field(o => o.Name);
            Field(o => o.Body);
            Field(o => o.BlogId);
        }
        
    }
}
