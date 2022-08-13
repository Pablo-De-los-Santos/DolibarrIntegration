using DolibarrIntegration.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DolibarrIntegration.Controllers
{
    public class ContactsController : Controller
    {
        private static HttpClient client = new HttpClient();

        public async Task<IActionResult> Index()
        {
            List<Contact> contacts = new List<Contact>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{GlobalConstants.GetContacts}&DOLAPIKEY={GlobalConstants.Token}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    contacts = JsonConvert.DeserializeObject<List<Contact>>(apiResponse);
                }
            }

            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");
                await httpClient.PostAsync($"{GlobalConstants.GetContacts}&DOLAPIKEY={GlobalConstants.Token}", content);
                return RedirectToAction("Index");
            }
        }
    }
}