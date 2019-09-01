using GraphQL.Types;
using System;

namespace TechFayre.Gql.Schemas
{
    public class TechFayreSchema : Schema
    {
        public TechFayreSchema()
        {
            Query = new TechFayreQuery();
            Mutation = new TechFayreMutation();
            Subscription = new TechFayreSubscriptions();
        }
    }
}
