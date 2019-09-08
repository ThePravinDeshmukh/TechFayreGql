using System;
using System.Collections.Generic;
using System.Text;

namespace TechFayre.Gql.Models.Entities
{
    public class Comment : CommentBase
    {
        public int Id { get; set; }
        public int BlogId { get; set; }

        public CommentBase ToParent()
        {
            return new CommentBase
            {
                Body = Body,
                Name = Name
            };
        }
    }
    public class CommentBase
    {
        public string Body { get; set; }
        public string Name { get; set; }
    }
}
