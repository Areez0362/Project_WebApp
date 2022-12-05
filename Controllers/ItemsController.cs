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
                  List<Items> items = await response.Content.ReadAsAsync<List<Items>>();
                  return View(items);
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

        public IActionResult Edit(string ItemID, string name, int Quantity, int Price)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Items item)
        {
            using var client = new HttpClient();
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
            if (item.ItemID != null)
            {
                var uri = Path.Combine("UpdateItem", item.ItemID);
                var response = await client.PutAsync(uri, data);
                response.EnsureSuccessStatusCode();
            }
            return RedirectToAction("Index");
        }
      
        public async Task<IActionResult> Delete(string ItemID)
        {
            
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7099/api/Items/");

            var uri = Path.Combine("DeleteItem", ItemID);
            
            var response = await client.DeleteAsync(uri);
            Console.WriteLine(uri);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index");
        }

       [HttpGet]
        public async Task<IActionResult> GetItemByID(string ItemID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7099/api/Items/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                if (ItemID != null)
                {
                    var uri = Path.Combine("GetItemById", ItemID);
                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        Items item = await response.Content.ReadAsAsync<Items>();
                        return View(item);
                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
            }
            return View(null);
           // return RedirectToAction("Index");
        }


    }


}
