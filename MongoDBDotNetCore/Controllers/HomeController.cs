using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Data.Repository;
using MongoDBDotNetCore.Model;
using MongoDBDotNetCore.Models;

namespace MongoDBDotNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMongoRepository<BlogPost> postsRepository;

        public HomeController(IMongoRepository<BlogPost> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        public IActionResult Index()
        {
            var posts = postsRepository.AsQueryable().ToList();
            return View(posts);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(string title, string content)
        {
            BlogPost newPost = new BlogPost()
            {
                Title = title,
                Content = content
            };

            await postsRepository.InsertOneAsync(newPost);
            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
