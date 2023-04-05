using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Net;
using Testing.EFCore.SqlDataLayer.EFCore;

namespace Testing.EFCore.MVC.Controllers
{
	public class MovieController : Controller
	{
		InseparableContext inseparable = new InseparableContext();

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult List()
		{
			var movies = inseparable.TMovies;
			return View(movies);
		}
		public IActionResult GetMovies()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> GetMoviesAsync(int id)
		{
			HttpClient client = new HttpClient();
			Uri uri = new Uri("https://movies.yahoo.com.tw/movie_thisweek.html");
			HttpResponseMessage response = await client.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				string html = await response.Content.ReadAsStringAsync();
				string key = "release_movie_name";
				int start = html.IndexOf(key) + key.Length + 2;
				string movieName = html.Substring(start, 8);
			}
			return RedirectToAction("List");
		}
		public IActionResult addMovieData()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddMovieData()
		{
			TMovie movie = new TMovie();
			string strUrl = "https://image.tmdb.org/t/p/w500/wD2kUCX1Bb6oeIb2uz7kbdfLP6k.jpg";
			movie.FMovieName = "testing";

			System.Drawing.Image MyImage = null;


			//建立一個 Web Request
			WebRequest MyWebRequest = WebRequest.Create(strUrl);
			//由 Web Request 取得 Web Response
			WebResponse MyWebResponse = MyWebRequest.GetResponse();
			//由 Web Response 取得 Stream
			Stream MyStream = MyWebResponse.GetResponseStream();
			//由 Stream 取得 Image
			MyImage = System.Drawing.Image.FromStream(MyStream);
			//該關的關一關, 該放的放一放
			MyStream.Close();
			MyStream.Dispose();
			MyWebResponse.Close();
			MyWebResponse = null;
			MyWebRequest = null;

			ImageConverter _imageConverter = new ImageConverter();
			byte[] imgBytesIn = (byte[])_imageConverter.ConvertTo(MyImage, typeof(byte[]));

			movie.FMovieImage = imgBytesIn;

			inseparable.TMovies.Add(movie);
			inseparable.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}
