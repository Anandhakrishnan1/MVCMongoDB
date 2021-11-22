using Configuration;
using Domain.Abstract.Entity;
using Domain.Abstract.Repositories;
using Domain.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ContentRepository : IContentRepository
    {
        IMongoClient mongoClient = new MongoClient("mongodb://localhost:27017");

        //public List<IContent> GetContents()
        //{
        //    var db = mongoClient.GetDatabase("ContentManagementSystem");
        //    var collection = db.GetCollection<Content>("content");
        //    var contents = collection.Find<Content>(a => true);
        //    return contents;
        //}

    }
}
