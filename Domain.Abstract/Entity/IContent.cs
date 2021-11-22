using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract.Entity
{
    public interface IContent
    {
        [BsonId]
        public int Id { get; set; }
        public string PageName { get; set; }
        public string Content_EN { get; set; }
        public string Content_AR { get; set; }
    }
}
