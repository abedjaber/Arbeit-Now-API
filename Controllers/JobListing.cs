using ConsoleApp1;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace Jobs.Controllers
    {
    public class JobListing : Controller
        {
        public IActionResult Index()
            {
            return View();
            }
        public IActionResult ShowDataButton()
            {
            return View();
            }
        public async Task<IActionResult> GetData()
            {
            var objects = await FetchDataFromApi();
            return Json(objects.data);
            }
        private async Task<Root> FetchDataFromApi()
            {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.arbeitnow.com/api/job-board-api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var response = client.GetStringAsync(client.BaseAddress).Result;
            Root root = JsonConvert.DeserializeObject<Root>(response);
            for (int j = 0; j < root.data.Count; j++)
                {
                root.data[j].created_at_date = ConvertTimestampToDateTime(root.data[j].created_at);
                }
            return root;
            }
        private DateTime ConvertTimestampToDateTime(long timestamp)
            {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamp);
            return dateTimeOffset.LocalDateTime;
            }
        }
    }
