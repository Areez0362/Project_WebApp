using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_WebApp.Models;
using System.Net.Http.Headers;
using System.Text;

namespace Project_WebApp.Controllers
{
    public class ItemsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7099/api/Items/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                HttpResponseMessage response = await client.GetAsync("AllItems");
                if (response.IsSuccessStatusCode)
                {
                  List<Items> department = await response.Content.ReadAsAsync<List<Items>>();
                  return View(department);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            return View();
        }

        public IActionResult create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> create(Items item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7099/api/Items/");


                var json = new
                {
                    item.ItemID,
                    item.Name,
                    item.Price,
                    item.Quantity
                };
                var jsonItem = JsonConvert.SerializeObject(json);
                var data = new StringContent(jsonItem, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("AddItem", data);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");   
            }
        }

    }


}
