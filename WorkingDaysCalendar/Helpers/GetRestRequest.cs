using RestSharp;

namespace WorkingDaysCalendar.Helpers
{
	public class GetRestRequest
	{
		public async Task<char[]> ExecuteAsync()
		{
			var options = new RestClientOptions("https://isdayoff.ru");
			var client = new RestClient(options);
			var request = new RestRequest("/api/getdata?year=2023&pre=1", Method.Get);
			RestResponse response = await client.ExecuteAsync(request);

			return response.Content.ToCharArray();
		}
	}
}
