using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsApp.Models;

namespace NewsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        public HomeController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            try
            {
                _articleRepository.Add(new Article
                {
                    Title = "tiele",
                    Body = "body",
                    Likes = 1,
                    PublishDate = DateTime.Now,
                    Comments = new List<Comment>
                    {
                        new Comment
                        {
                            Text = "hello",
                        },
                        new Comment
                        {
                            Text = "sdf"
                        }
                    }
                });
                _articleRepository.SaveChanges();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
            var articles = _articleRepository.GetAll();

            return View(articles);
        }
    }
}
