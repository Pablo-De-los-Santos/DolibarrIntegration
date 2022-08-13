using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DolibarrIntegration.Data;
using DolibarrIntegration.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace DolibarrIntegration.Controllers
{
    public class ProductsController : Controller
    {
        private static HttpClient client = new HttpClient();

        public async Task<IActionResult> Index()
        {
            List<Product> products = new List<Product>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{GlobalConstants.GetProducts}&DOLAPIKEY={GlobalConstants.Token}"))
                {
                    if (response.IsSuccessStatusCode != false)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        products = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                    }

                }
            }

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
                
                HttpResponseMessage responde= await httpClient.PostAsync($"{GlobalConstants.GetProducts}&DOLAPIKEY={GlobalConstants.Token}", content);
                return RedirectToAction("Index");
            }
        }
    }
}
