using GraphQL;
using GraphQL.Types;
using System;
using TechFayre.Gql.Models;

namespace TechFayre.Gql.Schemas
{
    public class TechFayreSchema : Schema
    {
        public TechFayreSchema(IBlogRepository blogRepository, IDependencyResolver resolver)
            : base(resolver)
        {
            Query = new TechFayreQuery(blogRepository);
            Mutation = new TechFayreMutation(blogRepository);
            //Subscription = new TechFayreSubscriptions();
        }
    }
}
