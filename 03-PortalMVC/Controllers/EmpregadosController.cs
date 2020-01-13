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
    public class EmpregadosController : Controller
    {
        Helper _api = new Helper();

        // GET: Empregados
        public async Task<ActionResult> Index()
        {
            List<Empregado> empregado = new List<Empregado>();
            HttpClient client = _api.Inicial();
            HttpResponseMessage response = await client.GetAsync("api/empregados");
            if (response.IsSuccessStatusCode)
            {
                var resultado = response.Content.ReadAsStringAsync().Result;

                empregado = JsonConvert.DeserializeObject<List<Empregado>>(resultado);

               
            }

            return View(empregado);
        }

        // GET: Empregados/Details/5
        public async Task<ActionResult> Details(int Id)
        {
            var empregado = new Empregado();
            HttpClient client = _api.Inicial();
            HttpResponseMessage response = await client.GetAsync($"api/empregados/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var resultado = response.Content.ReadAsStringAsync().Result;

                empregado = JsonConvert.DeserializeObject<Empregado>(resultado);

            }
            return View(empregado);
        }

        // GET: Empregados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empregados/Create
        [HttpPost]
        public IActionResult Create(Empregado empregado)
        {
            HttpClient client = _api.Inicial();

            //HTTP POST
            var post = client.PostAsJsonAsync<Empregado>("api/empregados", empregado);
            post.Wait();

            return RedirectToAction("Index");

        }

        //GET: Empregados/Edit/5
        public async Task<ActionResult> Edit (int Id)
        {

            Empregado empregado = new Empregado();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:63760/api/Empregados/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    empregado = JsonConvert.DeserializeObject<Empregado>(apiResponse);
                }
            }
            return View(empregado);
        }

        [HttpPost]
        public ActionResult Edit([FromForm]Empregado empregado, int Id)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63760/api/Empregados/" + Id);

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Empregado>(client.BaseAddress, empregado);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(empregado);
        }


        public async Task<IActionResult> Delete(int Id)
        {
            var empregado = new Empregado();
            HttpClient client = _api.Inicial();
            HttpResponseMessage response = await client.DeleteAsync($"api/empregados/{Id}");

            return RedirectToAction("Index");

        }
    }
}
