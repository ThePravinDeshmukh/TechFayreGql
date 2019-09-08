using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using TechFayre.Gql.Models.Entities;

namespace TechFayre.Gql.Schemas.InputType
{
    public class CommentInputType : InputObjectGraphType<Comment>
    {
        public CommentInputType()
        {
            Field(x => x.BlogId, nullable: false);
            Field(x => x.Name, nullable: false);
            Field(x => x.Body, nullable: false);
        }
    }
}
