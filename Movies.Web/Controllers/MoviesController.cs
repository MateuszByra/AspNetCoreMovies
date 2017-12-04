using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movies.Infrastructure.DTO;
using Movies.Web.Models;

namespace Movies.Web.Controllers
{
    public class MoviesController : Controller //: BaseController
    {
        //private readonly IMovieService _movieService;

        //public MoviesController(ICommandDispatcher commandDispatcher,
        //    IMapper mapper,
        //    IMovieService movieService) : base(commandDispatcher, mapper)
        //{
        //    _movieService = movieService;
        //}

        public async Task<IActionResult> Index()
        {
            IEnumerable<MovieDTO> movies = new List<MovieDTO>();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:57218/api/Movies");
                if (response.IsSuccessStatusCode)
                {
                    movies = await response.Content.ReadAsAsync<IEnumerable<MovieDTO>>();
                }
                return View(movies);
            }

        }

        public IActionResult CreateMovie()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddMovie(MovieViewModel model)
        //{
        //    if (Dispatch<MovieViewModel, CreateMovie>(model))
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View("CreateMovie", model);
        //}
    }
}