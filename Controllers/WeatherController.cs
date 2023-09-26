using Microsoft.AspNetCore.Mvc;
using SimpleWeatherApp.Models;
using System.Collections.Generic;
using System.Text;

namespace SimpleWeatherApp.Controllers
{
	public class WeatherController : Controller
	{
		private List<CityWeather> _weathers = new ()
		{
			new CityWeather("LDN", "London", DateTime.Parse("2030-01-01 8:00"), 33) { BackgroundImageLink = "https://cms.finnair.com/resource/blob/653524/68a843d4659786d6b381603c8e394e42/london-main-data.jpg?impolicy=crop&width=3555&height=2666&x=223&y=0"},
			new CityWeather("NYC", "New York", DateTime.Parse("2030-01-01 3:00"), 60) { BackgroundImageLink = "https://static.scientificamerican.com/sciam/cache/file/114430ED-82F3-4002-B2CB4C4F86F257FD_source.jpg"},
			new CityWeather("PAR", "Paris", DateTime.Parse("2030-01-01 9:00"), 82) { BackgroundImageLink = "https://theplanetd.com/images/Where-to-Stay-in-Paris-Neighborhoods.jpg"},
			new CityWeather("PAR", "Kyiv", DateTime.Parse("2030-01-01 9:00"), 61) { BackgroundImageLink = "https://media-cldnry.s-nbcnews.com/image/upload/rockcms/2022-02/220212-kyiv-monument-mjf-1343-e8b657.jpg"},
			new CityWeather("PAR", "Cairo", DateTime.Parse("2030-01-01 9:00"), 76) { BackgroundImageLink = "https://i0.wp.com/www.touristisrael.com/wp-content/uploads/2020/01/WOMAllenby_PodRendering-1-1-1-1-1.jpg?fit=1050%2C700&ssl=1"},
			new CityWeather("PAR", "Jakarta", DateTime.Parse("2030-01-01 13:00"), 95) { BackgroundImageLink = "https://360info.org/wp-content/uploads/2023/06/a1079ce35c9ab76b88956da64317d93e683990e5c17041de157f8e0f92395a33-1024x683.webp"},
			new CityWeather("PAR", "New Delhi", DateTime.Parse("2030-01-01 12:00"), 89) { BackgroundImageLink = "https://www.nationsonline.org/gallery/India/Lotus-Temple-New-Delhi.jpg"},
			new CityWeather("PAR", "Oslo", DateTime.Parse("2030-01-01 08:00"), 52) { BackgroundImageLink = "https://wheresclare.co.uk/wp-content/uploads/2022/08/Oslo-27.jpg"},
		};

		[Route("/")]
		public IActionResult CityWeather()
		{
			string pageName = "Weather App";

			var resultView = new WeatherAndPageNameWrapperModel() { CityWeatherList = _weathers, PageName = pageName };

			return View(resultView);
		}

		[Route("/about")]
		public IActionResult About()
		{
			return View();
		}

		[Route("/details/{city?}")]
		public IActionResult Details(string? city)
		{
			var result = _weathers.Where(x => x.CityName == city);

			if (result.Count() == 0)
			{
				return Content("Invalid city name.");
			}

			return View(viewName: "CityWeatherDetails", result.First());
		}
	}
}
