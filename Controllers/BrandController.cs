using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using ShopRepasitories.Interfaces;

namespace MobileShop.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandRepasitory _repasitory;
        public BrandController(IBrandRepasitory repasitory)
        {
            _repasitory = repasitory;
        }
        // GET: BrandController
        public async Task<ActionResult> Index()
        {
            return View(await _repasitory.GetAll());
        }

        // GET: BrandController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var brand = await _repasitory.Get(id);
            return View(brand);
        }

        // GET: BrandController/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "Account");
        }

        // POST: BrandController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand brand)
        {
           
                if (ModelState.IsValid)
                {
                    int result = -1;
                    result = _repasitory.Create(brand);
                    return RedirectToAction("Index");
                }

                return View();
        }

        // GET: BrandController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Brand brand = await _repasitory.Get(id);
            return View(brand);
        }

        // POST: BrandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _repasitory.Update(brand);
                return RedirectToAction("Index");
            }
            return View();
        }
            
        

        // GET: BrandController/Delete/5
        public ActionResult Delete(int id)
        {
            _repasitory.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
