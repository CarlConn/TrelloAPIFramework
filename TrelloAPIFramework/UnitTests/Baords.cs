using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace TrelloAPIFramework.UnitTests
{
    [TestClass]
    public class Baords
    {
        public string url = "https://api.trello.com/";
        public string endPoint = "1/boards/";
        private string boardName = "Practice";
        private readonly string _key = "12766fee439ecb47c101c035a0b58af5";
        private readonly string _token = "790457a848b469ae775ebeb744a89f2b218e0ec73d9160021d9c62fef652aac4";
        
        [TestMethod]
        public async Task CreateBoard()
        {
            var client = new RestClient(url);
            var request = new RestRequest("/1/boards/", Method.Post);
            request.AddQueryParameter("name", "CarlBoard");
            request.AddQueryParameter("key", _key);
            request.AddQueryParameter("token", _token);
            var response = await client.PostAsync(request);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
   
        [TestMethod]
        public async Task BoardCreateList()
        {
            var client = new RestClient(url);
            var request = new RestRequest("1/list/", Method.Post);
            request.AddQueryParameter("name", "Making a Copy");
            request.AddQueryParameter("idBoard", "627c2f812ba2e94591831607");
            request.AddQueryParameter("key", _key);
            request.AddQueryParameter("token", _token);
            var response = await client.PostAsync(request);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [TestMethod]
        public async Task DeleteBoard()
        {
           string uri = "/1/boards/" + "627c2eeea9488616286f4026" + "/";
            
           var client = new RestClient(url);
           var request = new RestRequest(uri, Method.Delete);
           request.AddQueryParameter("name", "CarlBoard");
           request.AddQueryParameter("key", _key);
           request.AddQueryParameter("token", _token);
           var response = await client.DeleteAsync(request);
           response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}