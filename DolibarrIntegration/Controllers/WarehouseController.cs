using DolibarrIntegration.Dto;
using DolibarrIntegration.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DolibarrIntegration.Controllers
{
    public class WarehouseController : Controller
    {

        public async Task<IActionResult> Index()
        {

            List<Warehouses> Warehouses = new List<Warehouses> { };
            var __Warehouses = new WarehousesList
            {

                Warehouses = new List<Warehouses> { }
            };



            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri($"{GlobalConstants.Url}warehouses");
            request.Method = HttpMethod.Get;
            request.Headers.Add("DOLAPIKEY", GlobalConstants.Token);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();

            Warehouses = JsonConvert.DeserializeObject<List<Warehouses>>(responseString);
            foreach (var _Warehouses in Warehouses)
            {

                __Warehouses.Warehouses.Add(_Warehouses);


            }

            return View(__Warehouses);
        }


        public async Task<IActionResult> Edit(string Id)
        {
            var Data = Get(Id);

            Warehouses warehouses = await Data;

            return View(warehouses);
        }
        public async Task<IActionResult> SaveUserAsync(Warehouses warehouses)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    StringContent content = new StringContent(JsonConvert.SerializeObject(warehouses), Encoding.UTF8, "application/json");

                    var response = client.PutAsync($"{GlobalConstants.Url}warehouses/{warehouses.Id}?DOLAPIKEY={GlobalConstants.Token}", content);

                    return RedirectToAction("Index");

                }
            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<IActionResult> Create() {


            return View();
        }

     
        public async Task<IActionResult> CreateWare(Warehouses warehouses)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    StringContent content = new StringContent(JsonConvert.SerializeObject(warehouses), Encoding.UTF8, "application/json");

                    var response = client.PostAsync($"{GlobalConstants.Url}warehouses?DOLAPIKEY={GlobalConstants.Token}", content);

                    return RedirectToAction("Index");

                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<Warehouses> Get(string Id = null)
        {
            Warehouses _Warehouses = new Warehouses();

            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri($"{GlobalConstants.Url}warehouses/{Id}");
            request.Method = HttpMethod.Get;
            request.Headers.Add("DOLAPIKEY", GlobalConstants.Token);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();

            _Warehouses = JsonConvert.DeserializeObject<Warehouses>(responseString);

            return _Warehouses;

        }
    }
}
