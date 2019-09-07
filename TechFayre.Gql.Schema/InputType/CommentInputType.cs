using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechFayre.Gql.Schemas.InputType
{
    public class CommentInputType : InputObjectGraphType
    {
        public CommentInputType()
        {
            Field<StringGraphType>("name");
            Field<StringGraphType>("body");
        }
    }
}
