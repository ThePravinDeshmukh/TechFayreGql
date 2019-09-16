using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;
using System;
using TechFayre.Gql.Models;
using TechFayre.Gql.Models.Entities;
using TechFayre.Gql.Schemas.Type;

namespace TechFayre.Gql.Schemas
{
    public class TechFayreSubscriptions : ObjectGraphType
    {
        RequestRepository _requestRepo;
        public TechFayreSubscriptions(RequestRepository requestRepo)
        {
            _requestRepo = requestRepo;
            AddField(new EventStreamFieldType
            {
                Name = "requests",
                Type = typeof(RequestType),
                Resolver = new FuncFieldResolver<Request>(ResolveMessage),
                Subscriber = new EventStreamResolver<Request>(Subscribe)
            });
        }

        private Request ResolveMessage(ResolveFieldContext context)
        {
            var message = context.Source as Request;

            return message;
        }

        private IObservable<Request> Subscribe(ResolveEventStreamContext context)
        {
            return _requestRepo.Requests();
        }

    }
}