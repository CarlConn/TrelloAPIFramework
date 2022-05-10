using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace TrelloAPIFramework.UnitTests
{
    [TestClass]
    public class Baords
    {
        public string url = "https://api.trello.com/";
        public string endPoint = "1/boards/";
        private readonly string _KEY = "12766fee439ecb47c101c035a0b58af5";
        private readonly string _token = "790457a848b469ae775ebeb744a89f2b218e0ec73d9160021d9c62fef652aac4";
        
        [TestMethod]
        public void CreateBoard()
        {
            var client = new RestClient(url);
            var request = new RestRequest("/{{id}}/boards/", Method.Post);
            request.AddParameter("id", 2);
            request.AddQueryParameter("name", "CarlRider");
            request.AddQueryParameter("key", _KEY);
            request.AddQueryParameter("token", _token);
            var response = await client.GetAsync(request);
        }
    }
}