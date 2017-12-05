using Movies.Infrastructure.Commands.Movies;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Tests.EndToEnd.Controllers
{
    [TestFixture]
    public class MoviesControllerTests : ControllerTestsBase
    {
        private readonly string apiUrl = "api/movies";

        [Test]
        public async Task create_movie()
        {
            var command = new CreateMovie()
            {
                DurationMinutes = 123,
                Title = "test movie"
            };

            var payload = GetPayload(command);
            var response = await Client.PostAsync(apiUrl, payload);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(apiUrl, response.Headers.Location.ToString());
        }
    }
}
