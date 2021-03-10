using DeybiGuevara.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeybiGuevara.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var albums = GetAlbums().Result;
            return View(albums);
        }

        public async Task<List<Album>> GetAlbums()
        {
            List<Album> albumsL = new List<Album>();

            try
            {
                var responseBody = String.Empty;

                using (var Client = new HttpClient())
                {

                    //string UriAddres = ConfigurationManager.AppSettings.Get("URLServicioUsuarios");
                    //Client.BaseAddress = new Uri(UriAddres);

                    Task<HttpResponseMessage> response1 = Client.GetAsync(new Uri($"https://jsonplaceholder.typicode.com/albums"));
                    response1.Result.EnsureSuccessStatusCode();
                    responseBody = await response1.Result.Content.ReadAsStringAsync();
                    albumsL = JsonConvert.DeserializeObject<List<Album>>(responseBody);

                }

            }
            catch (Exception ex)
            {

            }
            return albumsL;
        }
        public async Task<List<Photo>> GetPhotos(int idAlbum)
        {
            List<Photo> photoL = new List<Photo>();

            try
            {
                var responseBody = String.Empty;

                using (var Client = new HttpClient())
                {

                    //string UriAddres = ConfigurationManager.AppSettings.Get("URLServicioUsuarios");
                    //Client.BaseAddress = new Uri(UriAddres);

                    Task<HttpResponseMessage> response1 = Client.GetAsync(new Uri($"https://jsonplaceholder.typicode.com/photos?albumId={idAlbum}"));
                    response1.Result.EnsureSuccessStatusCode();
                    responseBody = await response1.Result.Content.ReadAsStringAsync();
                    photoL = JsonConvert.DeserializeObject<List<Photo>>(responseBody);

                }

            }
            catch (Exception ex)
            {

            }
            return photoL;
        }
        public async Task<List<Comment>> GetComments(int commentId)
        {
            List<Comment> commentsL = new List<Comment>();

            try
            {
                var responseBody = String.Empty;

                using (var Client = new HttpClient())
                {

                    //string UriAddres = ConfigurationManager.AppSettings.Get("URLServicioUsuarios");
                    //Client.BaseAddress = new Uri(UriAddres);

                    Task<HttpResponseMessage> response1 = Client.GetAsync(new Uri($"https://jsonplaceholder.typicode.com/comments?postId={commentId}"));
                    response1.Result.EnsureSuccessStatusCode();
                    responseBody = await response1.Result.Content.ReadAsStringAsync();
                    commentsL = JsonConvert.DeserializeObject<List<Comment>>(responseBody);

                }

            }
            catch (Exception ex)
            {

            }
            return commentsL;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
