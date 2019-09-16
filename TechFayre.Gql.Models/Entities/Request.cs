using System;
using System.Collections.Generic;
using System.Text;

namespace TechFayre.Gql.Models.Entities
{
    public class Request
    {
        public string Query { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
