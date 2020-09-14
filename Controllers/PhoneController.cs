using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobileShop.Data;
using MobileShop.Models;
using Shop.Models;
using ShopRepasitories.Interfaces;

namespace MobileShop.Controllers
{
    public class PhoneController : Controller
    {
        private readonly IPhoneRepasitory _repasitory;
        private readonly IBrandRepasitory _repasitoryBrand;

        public PhoneController(IPhoneRepasitory repasitory, IBrandRepasitory repasitoryBrand)
        {
            _repasitory = repasitory;
            _repasitoryBrand = repasitoryBrand;

        }

        // GET: Phone
        public async Task<IActionResult> Index(int pagenumber=1,int pagesize=5)
        {
           
            List<Phone> phones = await _repasitory.GetAll();
            foreach (var item in phones)
            {
                item.PhoneBrand =await _repasitoryBrand.Get(item.BrandID);
            }
            if(phones.Count % pagesize==0)
             ViewData["PageCount"] = phones.Count / pagesize; 
            else
                ViewData["PageCount"] = phones.Count / pagesize+1;
            return View(phones.Skip((pagenumber-1)*pagesize).Take(pagesize));
        }

        // GET: Phone/Details/5
        public async Task<IActionResult> Details(int id) 
        {
            var phone = await _repasitory.Get(id);
            phone.PhoneBrand = await _repasitoryBrand.Get(phone.BrandID);
            return View(phone);
        }

        // GET: Phone/Create
      
        public async Task<IActionResult> Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewData["Brands"] =await _repasitoryBrand.GetAll();
                return View();
            }
            return RedirectToAction("Login", "Account");
        }

        // POST: Phone/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public  IActionResult Create( Phone phone)
        {
            if (ModelState.IsValid)
            {
                int result = -1;
                result = _repasitory.Create(phone);
          
                return RedirectToAction("Index");   
            }
            return View();
                
        }

        // GET: Phone/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Phone phone =await _repasitory.Get(id);
            ViewData["Brands"] = await _repasitoryBrand.GetAll();
            return View(phone);
        }
        //POST:PHONE/EDIT/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult  Edit(Phone phone)
        {
            if (ModelState.IsValid)
            {
                _repasitory.Update(phone);
                return RedirectToAction("Index");
            }
            return View();
        }
         
        // GET: Phone/Delete/5
        public IActionResult Delete(int id)
        {

            _repasitory.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Order(int i)
        {
            List<Phone> phones = null;
            switch (i)
            {
                case 1:
                    phones = _repasitory.LowToHigh();
                    break;
                case 2:
                    phones = _repasitory.HighToLow();
                    break;
            }
            return View(nameof(Index), phones);
        }
         public IActionResult LowHigh()
        {
           List<Phone> phones = _repasitory.LowToHigh();
           // return RedirectToPage("Phone/Index", phones);
            return View(nameof(Index), phones);
        }
        public IActionResult HighLow()
        {
            List<Phone> phones = _repasitory.HighToLow();
           // return RedirectToAction("Index", phones);
            return View(nameof(Index), phones);
        }
      
    }
}
