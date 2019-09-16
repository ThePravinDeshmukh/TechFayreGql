using GraphQL.Instrumentation;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using TechFayre.Gql.Models.Entities;

namespace TechFayre.Gql.Schemas.Type
{
    public class RequestType:ObjectGraphType<Request>
    {
        public RequestType()
        {

            Field(x => x.Query);
            Field(x => x.ReceivedAt);
        }
    }
}
