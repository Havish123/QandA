using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QandA_MVC.Helper;
using QandA_MVC.Models;

namespace QandA_MVC.Controllers
{
    public class StudentController : Controller
    {
        QandA_API _api=new QandA_API();
        
        public async Task<IActionResult> Index()
        {
            List<QuestionData> questions = new List<QuestionData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/questions");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                questions=JsonConvert.DeserializeObject<List<QuestionData>>(results);
            }
            return View(questions);
        }

        public async Task<IActionResult> Details(int id)
        {
            QuestionData questions = new QuestionData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/questions/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                questions = JsonConvert.DeserializeObject<QuestionData>(results);
            }
            return View(questions);

        }
    }
}
