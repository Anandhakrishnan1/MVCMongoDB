using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MVCMongoDB.Models;
using System;
using System.Configuration;
using System.Linq;

namespace MVCMongoDB.Controllers
{
    public class ContentsController : Controller
    {
        private IMongoDatabase mongoDatabase;
        public IMongoDatabase GetMongoDatabase()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            return mongoClient.GetDatabase("ContentManagementSystem");
        }
        [HttpGet]
        public IActionResult Index()
        {
            //Get the database connection  
            mongoDatabase = GetMongoDatabase();
            //fetch the details from CustomerDB and pass into view  
            var result = mongoDatabase.GetCollection<Content>("Contents").Find(a=>true).ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Content content)
        {
            if (ModelState.IsValid)
            {
                mongoDatabase = GetMongoDatabase();
                var collection = mongoDatabase.GetCollection<Content>("Contents");
                collection.InsertOneAsync(content);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
           
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            //Get the database connection  
            mongoDatabase = GetMongoDatabase();
            //fetch the details from CustomerDB and pass into view  
            Content content = mongoDatabase.GetCollection<Content>("Contents").Find<Content>(k => k.Id == id).FirstOrDefault();
            if (content == null)
            {
                return NotFound();
            }
            else
            {
                return View(content);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //Get the database connection  
            mongoDatabase = GetMongoDatabase();
            //fetch the details from CustomerDB and pass into view  
            Content content = mongoDatabase.GetCollection<Content>("Contents").Find<Content>(k => k.Id == id).FirstOrDefault();
            if (content == null)
            {
                return NotFound();
            }
            else
            {
                return View(content);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Deletes(int id)
        {
            if (ModelState.IsValid)
            {
                mongoDatabase = GetMongoDatabase();
                var collection = mongoDatabase.GetCollection<Content>("Contents");
                var DeleteRecored = collection.DeleteOneAsync(
                               Builders<Content>.Filter.Eq("Id", id));
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Get the database connection  
            mongoDatabase = GetMongoDatabase();
            //fetch the details from CustomerDB based on id and pass into view  
            var content = mongoDatabase.GetCollection<Content>("Contents").Find<Content>(k => k.Id == id).FirstOrDefault();
            if (content == null)
            {
                return NotFound();
            }
            else
            {
                return View(content);
            }
        }

        [HttpPost]
        public IActionResult Edit(Content content)
        {
            if (ModelState.IsValid)
            {
                mongoDatabase = GetMongoDatabase();
                var collection = mongoDatabase.GetCollection<Content>("Contents");

                var update = collection.FindOneAndUpdateAsync(Builders<Content>.Filter.Eq("Id", content.Id), 
                    Builders<Content>.Update.Set("PageName", content.PageName).Set("Content_EN", content.Content_EN).Set("Content_AR", content.Content_AR));

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
