using MongoDB.Bson;
using System;

namespace MongoDB.Data.Documents
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
