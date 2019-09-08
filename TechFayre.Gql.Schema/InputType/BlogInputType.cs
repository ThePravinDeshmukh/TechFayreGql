using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechFayre.Gql.Schemas.InputType
{
    public class BlogInputType : InputObjectGraphType
    {
        public BlogInputType()
        {
            Field<StringGraphType>("title");
            Field<StringGraphType>("author");

            //Field<ListGraphType<CommentInputType>>("comments");
        }
    }
}
