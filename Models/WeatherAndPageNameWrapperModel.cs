namespace SimpleWeatherApp.Models
{
	public class WeatherAndPageNameWrapperModel
	{
		public List<CityWeather> CityWeatherList { get; set; }
		public string PageName { get; set; }	
	}
}
