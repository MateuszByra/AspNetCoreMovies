using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Movies.Infrastructure.Commands;
using System.Net.Http;
using System.Net;

namespace Movies.Web.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Base call api method.
        /// </summary>
        /// <param name="func">Api action</param>
        /// <param name="successAction"></param>
        /// <returns></returns>
        private async Task callApiAsync(Func<HttpClient, Task<HttpResponseMessage>> func, Action<HttpResponseMessage> successAction)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await func(client);
                if (response.IsSuccessStatusCode)
                {
                    successAction(response);
                }
            }
        }

        protected async Task<T> GetApiDataAsync<T>(string url) where T : class, new()
        {
            var result = new T();

            await callApiAsync(
                    async (client) => await client.GetAsync(url),
                    async (responseMsg) => result = await responseMsg.Content.ReadAsAsync<T>()
                    );
            return result;
        }
        protected async Task<T> GetApiDataAsync<T>(string url, Guid id) where T : class, new()
        {
            var result = new T();

            await callApiAsync(
                    async (client) => await client.GetAsync($"{url}?id={id}"),
                    async (responseMsg) => result = await responseMsg.Content.ReadAsAsync<T>()
                    );
            return result;
        }

        protected async Task<HttpStatusCode> PostApiAsync<Tmodel>(string url, Tmodel model) where Tmodel : class
        {
            HttpStatusCode code = HttpStatusCode.NotFound; //default
            await callApiAsync(
                    async (client) => await client.PostAsJsonAsync<Tmodel>(url, model),
                    (responseMsg) => code = responseMsg.StatusCode
                );
            return code;
        }

        protected async Task<HttpStatusCode> PutApiAsync<Tmodel>(string url, Tmodel model) where Tmodel : class
        {
            HttpStatusCode code = HttpStatusCode.NotFound; //default
            await callApiAsync(
                    async (client) => await client.PutAsJsonAsync(url, model),
                    (responseMsg) => code = responseMsg.StatusCode
                );
            return code;
        }

        protected async Task<HttpStatusCode> DeleteApiAsync(string url, Guid id)
        {
            HttpStatusCode code = HttpStatusCode.NotFound; //default
            await callApiAsync(
                    async (client) => await client.DeleteAsync(url+id),
                    (responseMsg) => code = responseMsg.StatusCode
                );
            return code;
        }

    }
}