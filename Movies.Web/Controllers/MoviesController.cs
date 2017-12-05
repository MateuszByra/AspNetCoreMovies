using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movies.Infrastructure.DTO;
using Movies.Web.Models;

namespace Movies.Web.Controllers
{
    public class MoviesController : BaseController
    {
        //TODO: konstrutor przymujacy settings url do api czy cos takiego.

        public async Task<IActionResult> Index()
        {
            //TODO urls from settings file
            var movies = await GetApiDataAsync<List<MovieDTO>>("http://localhost:57218/api/Movies");
            return View(movies);
        }

        public IActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieViewModel model)
        {
            if (await PostApiAsync<MovieViewModel>("http://localhost:57218/api/Movies", model) == System.Net.HttpStatusCode.Created)
            {
                return RedirectToAction("Index");
            }
            return View("CreateMovie", model);
        }
    }
}