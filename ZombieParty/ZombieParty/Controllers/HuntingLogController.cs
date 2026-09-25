using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;
using ZombieParty.Models.Data;

namespace ZombieParty.Controllers
{
    public class HuntingLogController : Controller
    {
        private ZombiePartyDbContext _baseD {  get; set; }
        
        public HuntingLogController(ZombiePartyDbContext baseD)
        {
            _baseD = baseD;
        }

        public ActionResult Index()
        {
            List<HuntingLog> liste = _baseD.HuntingLogs.ToList();
            return View(liste);
        }

        public IActionResult Upsert(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return View(new HuntingLog());
            }
            else
                return View(_baseD.HuntingLogs.FirstOrDefault(i => i.Id == Id));
        }

        [HttpPost]
        public IActionResult Upsert(HuntingLog huntingLog)
        {
            if (ModelState.IsValid)
            {
                if (huntingLog.Id == 0)
                {
                    // Ajouter à la BD
                    _baseD.HuntingLogs.Add(huntingLog);
                    TempData["Success"] = $"{huntingLog.Title} Hunting log added";
                }
                else
                {
                    _baseD.HuntingLogs.Update(huntingLog);
                    TempData["Success"] = $"{huntingLog.Title} Hunting log upddated";
                }
                _baseD.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(huntingLog);
        }
    }
}
