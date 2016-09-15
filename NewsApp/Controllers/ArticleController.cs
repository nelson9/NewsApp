using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data.Repositories;
using NewsApp.Models;

namespace NewsApp.Controllers
{
    public class ArticleController : ApiController
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IHttpActionResult Get()
        {
            try
            {
                var matchResults = _articleRepository.GetAll();
                return Ok(matchResults);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var matchResults = _articleRepository.Get(id);
                return Ok(matchResults);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]Article article)
        {
            if (article == null)
            {
                return BadRequest();
            }

            try
            {
                _articleRepository.Add(article);
                _articleRepository.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = article.Id }, article);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


        public IHttpActionResult Put([FromBody]Article article)
        {
            if (article == null)
            {
                return BadRequest();
            }

            try
            {
                if (_articleRepository.Get(article.Id) != null) return NotFound();
                _articleRepository.Update(article);
                _articleRepository.SaveChanges();
                return Ok(article);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


        public IHttpActionResult Delete(int id)
        {
            var article = _articleRepository.Get(id);
            if (article == null) return NotFound();
            try
            {
                _articleRepository.Remove(article);
                _articleRepository.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
