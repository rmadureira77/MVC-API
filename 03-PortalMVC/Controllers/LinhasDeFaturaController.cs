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
    public class LinhasDeFaturaController : Controller
    {
        Helper _api = new Helper();

        // GET: LinhasDeFatura
        public async Task<ActionResult> Index()
        {
            List<LinhaDeFatura> linhas = new List<LinhaDeFatura>();
            HttpClient client = _api.Inicial();
            HttpResponseMessage response = await client.GetAsync("api/linhasdefatura");
            if (response.IsSuccessStatusCode)
            {
                var resultado = response.Content.ReadAsStringAsync().Result;

                linhas = JsonConvert.DeserializeObject<List<LinhaDeFatura>>(resultado);

            }

            return View(linhas);
        }

        // GET: LinhasDeFatura/Details/5
        public async Task<ActionResult> Details(int Id)
        {
            var linhas = new LinhaDeFatura();
            HttpClient client = _api.Inicial();
            HttpResponseMessage response = await client.GetAsync($"api/linhasdefatura/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var resultado = response.Content.ReadAsStringAsync().Result;

                linhas = JsonConvert.DeserializeObject<LinhaDeFatura>(resultado);

            }
            return View(linhas);
        }

        // GET: LinhasDeFatura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LinhasDeFatura/Create
        [HttpPost]
        public IActionResult Create(LinhaDeFatura linhas)
        {
            HttpClient client = _api.Inicial();

            //HTTP POST
            var post = client.PostAsJsonAsync<LinhaDeFatura>("api/linhasdefatura", linhas);
            post.Wait();

            return RedirectToAction("Index");

        }

        //GET: LihasDeFatura/Edit/5
        public async Task<ActionResult> Edit(int Id)
        {

            LinhaDeFatura linhas = new LinhaDeFatura();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:63760/api/LinhasDeFatura/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    linhas = JsonConvert.DeserializeObject<LinhaDeFatura>(apiResponse);
                }
            }
            return View(linhas);
        }

        [HttpPost]
        public ActionResult Edit([FromForm]LinhaDeFatura linhas, int Id)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63760/api/LinhasDeFatura/" + Id);

                //HTTP POST
                var putTask = client.PutAsJsonAsync<LinhaDeFatura>(client.BaseAddress, linhas);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(linhas);
        }


        public async Task<IActionResult> Delete(int Id)
        {
            var linhas = new LinhaDeFatura();
            HttpClient client = _api.Inicial();
            HttpResponseMessage response = await client.DeleteAsync($"api/faturas/{Id}");

            return RedirectToAction("Index");

        }

    }
}