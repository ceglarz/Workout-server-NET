using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Gateway.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gateway.Controllers
{
    public class TrainingsController : Controller
    {
        // GET: Trainings
        public async Task<IActionResult> Index()
        //public async ActionResult Index()
        //public IEnumerable<Training> Index()
        {
            var httpClient = new HttpClient();
            var jsonData = await httpClient.GetStringAsync("http://localhost:50002/api/Trainings");
            //List<Training> list = JsonConvert.DeserializeObject<List<Training>>(jsonData);
            var data = JsonConvert.DeserializeObject<IEnumerable<Training>>(jsonData);
            return View(data);
        }

        // GET: Trainings/Details/5
        [Route("Trainings/Details/{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var httpClient = new HttpClient();
            var jsonData = await httpClient.GetStringAsync("http://localhost:50002/api/Trainings/");
            var data = JsonConvert.DeserializeObject<IEnumerable<Training>>(jsonData);

            var training = data.Where(p => p.Id == id).FirstOrDefault(); ;

            return View(training);
        }

        // GET: Trainings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Trainings/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Trainings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Trainings/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Trainings/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}