using System.Net.Http;

namespace BookMark.Client.Utility {
	public class HttpService {
		private HttpService() {}
		private static readonly HttpService _srv = new HttpService();
		private static readonly HttpClient _cli = new HttpClient();
		public static HttpClient Client {
			get { return _cli; }
		}
		public static HttpService Service {
			get { return _srv; }
		}
	}
}