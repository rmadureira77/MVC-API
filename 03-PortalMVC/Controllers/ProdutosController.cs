using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ProdutosController : Controller
    {
        Helper _api = new Helper();
       

       
        // GET: Produtos
        public async Task<ActionResult> Index()
        {
            List<Produto> produto = new List<Produto>();
            HttpClient client = _api.Inicial();
            HttpResponseMessage response = await client.GetAsync("api/produtos");
            if (response.IsSuccessStatusCode)
            {
                var resultado = response.Content.ReadAsStringAsync().Result;

                produto = JsonConvert.DeserializeObject<List<Produto>>(resultado);

            }

            return View(produto);
        }

        // GET: Produtos/Details/5
        public async Task<ActionResult> Details(int Id)
        {
            var produto = new Produto();
            HttpClient client = _api.Inicial();
            HttpResponseMessage response = await client.GetAsync($"api/produtos/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var resultado = response.Content.ReadAsStringAsync().Result;

                produto = JsonConvert.DeserializeObject<Produto>(resultado);

            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            HttpClient client = _api.Inicial();

            //HTTP POST
            var post = client.PostAsJsonAsync<Produto>("api/produtos", produto);
            post.Wait();

            return RedirectToAction("Index");

        }

        //GET: Produtos/Edit/5
        public async Task<ActionResult> Edit(int Id)
        {

            Produto produto = new Produto();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:63760/api/Produtos/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    produto = JsonConvert.DeserializeObject<Produto>(apiResponse);
                }
            }
            return View(produto);
        }

        [HttpPost]
        public ActionResult Edit([FromForm]Produto produto, int Id)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63760/api/Produtos/" + Id);

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Produto>(client.BaseAddress, produto);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(produto);
        }


        public async Task<IActionResult> Delete(int Id)
        {
            // Tentativa por o produto associado ao empregado   
            //    var produto = new Produto();

            //    string userId = User.Identity.
            //    var empregados = _context.Produtos.Any(x => x.Empregado.UserEmpregado == userId);

            //    if (empregados != true)
            //    {
            //        return NotFound("Fica para a próxima.");
            //    }

            //    else
            //    {
            //        HttpClient client = _api.Inicial();
            //        HttpResponseMessage response = await client.DeleteAsync($"api/produtos/{Id}");
            //    }
            //    return RedirectToAction("Index");
            //}

            var produto = new Produto();
            HttpClient client = _api.Inicial();
            HttpResponseMessage response = await client.DeleteAsync($"api/produtos/{Id}");

            return RedirectToAction("Index");

        }

    }
}