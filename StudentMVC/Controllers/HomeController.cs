using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentMVC.Helper;
using StudentMVC.Models;
using System.Diagnostics;

namespace StudentMVC.Controllers
{
    public class HomeController : Controller
    {
        StudentAPI _api=new StudentAPI();

        public async Task<IActionResult> Index()
        {
            List<StudentData> students = new List<StudentData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/student");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<StudentData>>(results);
            }
            return View(students);
        }
       
        public async Task<IActionResult> Detail(int id)
        {
            StudentData studentData = new StudentData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/student/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results=res.Content.ReadAsStringAsync().Result;
                studentData= JsonConvert.DeserializeObject<StudentData>(results);
            }
            return View(studentData);
        }

        public IActionResult Create(StudentData studentData)
        {
            HttpClient client = _api.Initial();

            var postTask = client.PostAsJsonAsync<StudentData>("api/student", studentData);
            postTask.Wait();
            var result=postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            StudentData studentData=new StudentData();
            HttpClient client= _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/student/{id}");
            if (res.IsSuccessStatusCode)
            {

                var results = res.Content.ReadAsStringAsync().Result;
                studentData = JsonConvert.DeserializeObject<StudentData>(results);
            }
            return View(studentData);

        }

        [HttpPost]
        public IActionResult Edit(StudentData studentData)
        {
            HttpClient client = _api.Initial();

            var postTask = client.PutAsJsonAsync<StudentData>($"api/student/{studentData.Id}", studentData);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = new StudentData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/student/{id}");
            return RedirectToAction("Index");

        }

    }
}