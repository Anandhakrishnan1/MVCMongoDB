using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMongoDB.Models
{
    public class Content
    {
        [BsonId]
        public ObjectId id { get; set; }
        [BsonElement]
        public int Id { get; set; }
        [BsonElement]
        public string PageName { get; set; }
        [BsonElement]
        public string Content_EN { get; set; }
        [BsonElement]
        public string Content_AR { get; set; }
    }
}
