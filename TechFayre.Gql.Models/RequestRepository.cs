using System;
using System.Collections.Generic;
using System.Text;
using TechFayre.Gql.Models.Entities;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace TechFayre.Gql.Models
{
    public class RequestRepository
    {
        private readonly ISubject<Request> _requestStream = new ReplaySubject<Request>(1);
        private readonly ISubject<List<Request>> _allRequestStream = new ReplaySubject<List<Request>>(1);

        public RequestRepository()
        {
            AllRequests = new ConcurrentStack<Request>();
        }

        public ConcurrentStack<Request> AllRequests { get; }
        
        public async Task<IObservable<Request>> MessagesAsync()
        {
            //pretend we are doing something async here
            await Task.Delay(100);
            return Requests();
        }

        public List<Request> AddRequestGetAll(Request request)
        {
            AllRequests.Push(request);
            var l = new List<Request>(AllRequests);
            _allRequestStream.OnNext(l);
            return l;
        }

        public Request AddRequest(Request request)
        {
            AllRequests.Push(request);
            _requestStream.OnNext(request);
            return request;
        }

        public IObservable<Request> Requests()
        {
            return _requestStream.AsObservable();
        }

        public IObservable<List<Request>> RequestsGetAll()
        {
            return _allRequestStream.AsObservable();
        }

        public void AddError(Exception exception)
        {
            _requestStream.OnError(exception);
        }

    }
}
