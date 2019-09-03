using GraphQL.Types;
using System;
using TechFayre.Gql.Models;

namespace TechFayre.Gql.Schemas
{
    public class TechFayreSchema : Schema
    {
        public TechFayreSchema(PostRepository postRepository)
        {
            Query = new TechFayreQuery(postRepository);
            Mutation = new TechFayreMutation(postRepository);
            //Subscription = new TechFayreSubscriptions();
        }
    }
}
