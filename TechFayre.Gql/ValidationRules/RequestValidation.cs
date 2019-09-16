using GraphQL.Language.AST;
using GraphQL.Validation;
using System;
using TechFayre.Gql.Models;

namespace TechFayre.Gql
{
    public class RequestValidation : IValidationRule
    {
        RequestRepository _requestRepository;
        public RequestValidation(RequestRepository requestRepository)
        {
            _requestRepository = requestRepository;

        }
        public INodeVisitor Validate(ValidationContext context)
        {


            return new EnterLeaveListener(_ =>
            {
                _.Match<Operation>(op =>
                {
                    if (op.OperationType != OperationType.Subscription)
                    {

                        _requestRepository.AddRequest(new Models.Entities.Request { Query = context.OriginalQuery, ReceivedAt = DateTime.Now });

                    }
                });
            });

        }
    }
}
