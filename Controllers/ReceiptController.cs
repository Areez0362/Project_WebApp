using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Project_WebApp.Models;
using System.Net.Http.Headers;

namespace Project_WebApp.Controllers
{
    public class ReceiptController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetReceipt(string ReceiptID)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7099/api/Receipt/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                if (ReceiptID != null)
                {
                    var uri = Path.Combine("GetReceipt", ReceiptID);
                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        List<Receipt> receipt = await response.Content.ReadAsAsync<List<Receipt>>();
                        return View(receipt);
                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
            }
            return View(null);
        }



        [HttpGet]
        public async Task<IActionResult> GetDailyEarnings(string Date)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7099/api/Receipt/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                if (Date != null)
                {
                    var uri = Path.Combine("GetDailyEarnings", Date);
                    
                    Console.WriteLine(uri);
                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        int earning = await response.Content.ReadAsAsync<int>();
                        ViewBag.Daily = earning;
                        Console.WriteLine(earning);
                        return View("Earnings");

                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
            }
          return RedirectToAction("Index","Home");
        }


        [HttpGet]
        public async Task<IActionResult> GetWeeklyEarnings(int Date)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7099/api/Receipt/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                if (Date != 0)
                {
                    var uri = Path.Combine("GetWeeklyEarnings", Convert.ToString(Date));

                    Console.WriteLine(uri);
                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        int earning = await response.Content.ReadAsAsync<int>();
                        ViewBag.Weekly = earning;
                        Console.WriteLine(earning);
                        return View("Earnings");

                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> GetMonthlyEarnings(int Date)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7099/api/Receipt/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                if (Date != 0)
                {
                    var uri = Path.Combine("GetMonthlyEarnings", Convert.ToString(Date));

                    Console.WriteLine(uri);
                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        int earning = await response.Content.ReadAsAsync<int>();
                        ViewBag.Monthly = earning;
                        Console.WriteLine(earning);
                        return View("Earnings");

                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> GetYearlyEarnings(int Date)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7099/api/Receipt/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                if (Date != 0)
                {
                    var uri = Path.Combine("GetYearlyEarnings", Convert.ToString(Date));

                    Console.WriteLine(uri);
                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        int earning = await response.Content.ReadAsAsync<int>();
                        ViewBag.Yearly = earning;
                        Console.WriteLine(earning);
                        return View("Earnings");

                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }


    }
}
