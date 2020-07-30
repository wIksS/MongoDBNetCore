using MongoDB.Data.Attributes;
using MongoDB.Data.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBDotNetCore.Model
{
    [BsonCollectionAttribute("posts")]
    public class BlogPost : Document
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
