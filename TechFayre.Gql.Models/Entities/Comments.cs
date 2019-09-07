using System;
using System.Collections.Generic;
using System.Text;

namespace TechFayre.Gql.Models.Entities
{
    public class Comment : BaseComment
    {
        public int Id { get; set; }
    }
    public class BaseComment
    {
        public string Body { get; set; }
        public string Name { get; set; }
        public int BlogId { get; set; }
    }
}
