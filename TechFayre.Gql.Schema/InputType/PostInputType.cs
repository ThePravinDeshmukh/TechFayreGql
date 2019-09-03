using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechFayre.Gql.Schemas.InputType
{
    public class PostInputType : InputObjectGraphType
    {
        public PostInputType()
        {
            Field<StringGraphType>("id");
            Field<StringGraphType>("title");
            Field<StringGraphType>("author");
        }
    }
}
