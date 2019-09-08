using System;
using System.Collections.Generic;
using System.Text;

namespace TechFayre.Gql.Models.Entities
{
    public class Blog : BlogBase
    {

        public int Id { get; set; }
        public List<Comment> Comments { get; set; }
    }
    public class BlogBase
    {

        public string Title { get; set; }
        public string Author { get; set; }
    }
}
