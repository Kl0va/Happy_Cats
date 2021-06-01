using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy_Cats_Test.Data;
using Happy_Cats_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Principal;

namespace Happy_Cats_Test.Controllers
{
    public class CatsController : Controller
    {
        private AppDBContent db;

        public CatsController(AppDBContent context)
        { 
            db = context;
        }

        public async Task<IActionResult> Cats()
        { 
          return View(await db.Cats.ToListAsync());
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddCat()
        {
            return View(User.Identity.Name);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCat(Cats model)
        {
            Cats cats = await db.Cats.FirstOrDefaultAsync(u => u.Name_Cat == model.Name_Cat);
            if (cats == null)
            {
                db.Cats.Add(new Cats { Name_Cat = model.Name_Cat, History = model.History, Description_Cat = model.Description_Cat, Email_User = User.Identity.Name });
                await db.SaveChangesAsync();
            }
            else
            {
                ModelState.AddModelError("", "Неверные данные");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddCatWithAuth()
        {
            return View(User.Identity.Name);
        }

        public IActionResult ChangeCat()
        {
            return View();
        }

        public async Task<IActionResult> DeleteCat(int id)
        {
            var cats = await db.Cats.FindAsync(id);
            if(cats != null)
            {
                db.Cats.Remove(cats);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Cats","Cats");
        }

        public async Task<IActionResult> MyCats()
        {
                return View(await db.Cats.ToListAsync());
        }
    }
}