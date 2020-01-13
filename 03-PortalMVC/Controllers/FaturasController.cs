using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using _01_DAL;
using _03_PortalMVC.HTTPClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _03_PortalMVC.Controllers
{
    [Authorize]
    public class FaturasController : Controller
    {
        Helper _api = new Helper();

        // GET: Faturas
        public async Task<ActionResult> Index()
        {
            
            HttpClient client = _api.Inicial();
            HttpResponseMessage response = await client.GetAsync("api/faturas");
            if (response.IsSuccessStatusCode)
            {
                string resultado = await response.Content.ReadAsStringAsync();

                var faturas = JsonConvert.DeserializeObject<IEnumerable<Fatura>>(resultado);


                return View(faturas);

            }
            else
            {
                return Content("ERRO!!!: " + response.StatusCode);
            }

        }

        // GET: Faturas/Details/5  
        public async Task<ActionResult> Details(int Id)
        {
            var fatura = new Fatura();
            HttpClient client = _api.Inicial();
            HttpResponseMessage response = await client.GetAsync($"api/faturas/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var resultado = response.Content.ReadAsStringAsync().Result;

                fatura = JsonConvert.DeserializeObject<Fatura>(resultado);

            }
            return View(fatura);
        }

        // GET: Faturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faturas/Create
        [HttpPost]
        public IActionResult Create(Fatura fatura)
        {
            HttpClient client = _api.Inicial();

            //HTTP POST
            var post = client.PostAsJsonAsync<Fatura>("api/faturas", fatura);
            post.Wait();

            return RedirectToAction("Index");

        }

        //GET: Faturas/Edit/5
        public async Task<ActionResult> Edit(int Id)
        {

            Fatura fatura = new Fatura();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:63760/api/Faturas/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    fatura = JsonConvert.DeserializeObject<Fatura>(apiResponse);
                }
            }
            return View(fatura);
        }

        [HttpPost]
        public ActionResult Edit([FromForm]Fatura fatura, int Id)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63760/api/Faturas/" + Id);

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Fatura>(client.BaseAddress, fatura);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(fatura);
        }


        public async Task<IActionResult> Delete(int Id)
        {
            var faturas = new Fatura();
            HttpClient client = _api.Inicial();
            HttpResponseMessage response = await client.DeleteAsync($"api/faturas/{Id}");

            return RedirectToAction("Index");

        }

    }
}