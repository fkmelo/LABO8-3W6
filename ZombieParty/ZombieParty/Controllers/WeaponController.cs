using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;
using ZombieParty.Models.Data;
using ZombieParty.ViewModels;

namespace ZombieParty.Controllers
{
    public class WeaponController : Controller
    {
        private ZombiePartyDbContext _baseDonnees { get; set; }

        public WeaponController(ZombiePartyDbContext baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }

        public IActionResult Index()
        {
            List<Weapon> weapons = _baseDonnees.Weapons.ToList();
            return View(weapons);
        }

        public IActionResult Upsert(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return View(new Weapon());
            }
            else
                return View(_baseDonnees.Weapons.FirstOrDefault(i => i.WeaponId == Id));
        }

        [HttpPost]
        public IActionResult Upsert(Weapon weapon)
        {
            if (ModelState.IsValid)
            {
                if (weapon.WeaponId == 0)
                {
                    // Ajouter à la BD
                    _baseDonnees.Weapons.Add(weapon);
                    TempData["Success"] = $"{weapon.Name} weapon added";
                }
                else
                {
                    _baseDonnees.Weapons.Update(weapon);
                    TempData["Success"] = $"{weapon.Name} weapon upddated";
                }
                _baseDonnees.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(weapon);
        }
    }
}
