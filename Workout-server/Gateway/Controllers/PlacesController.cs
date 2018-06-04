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
    public class PlacesController : Controller
    {
        // GET: Places
        public async Task<IActionResult> Index()
        //public async ActionResult Index()
        //public IEnumerable<Training> Index()
        {
            var httpClient = new HttpClient();
            var jsonData = await httpClient.GetStringAsync("http://localhost:50001/api/Places");
            //List<Training> list = JsonConvert.DeserializeObject<List<Training>>(jsonData);
            var data = JsonConvert.DeserializeObject<IEnumerable<Place>>(jsonData);
            return View(data);
        }

        // GET: Places/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Places/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Places/Create
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

        // GET: Places/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Places/Edit/5
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

        // GET: Places/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Places/Delete/5
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