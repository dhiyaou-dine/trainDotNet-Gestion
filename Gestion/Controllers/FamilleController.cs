using Gestion.Models;
using Gestion.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Gestion.Controllers
{
    public class FamilleController : Controller
    {
        public IRepositorie<Famille> Repository { get; }
        public FamilleController(IRepositorie<Famille> repository)
        {
            Repository = repository;
        }

        public IActionResult Index()
        {
            var famille = Repository.lister();
            return View(famille);
        }
        public IActionResult Details(int id)
        {
            var famille = Repository.listerSelonId(id);
            return View(famille);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Famille famille)
        {
            try
            {
                Repository.ajouter(famille);
                return RedirectToAction("Index");
            }
            catch { return View(); }
        }
        public ActionResult Edit(int id)
        {
            var famille = Repository.listerSelonId(id);
            return View(famille);
        }
        [HttpPost]
        public ActionResult Edit(int id, Famille famille)
        {
            try
            {
                Repository.modifier(id, famille);
                return RedirectToAction("Index");
            }
            catch { return View();}
        }
        public ActionResult Delete(int id)
        {
            var famille = Repository.listerSelonId(id);
            return View(famille);
        }
        [HttpPost]
        public ActionResult Delete(int id, Famille famille)
        {
            try
            {
                Repository.supprimer(id);
                return RedirectToAction("Index");
            }
            catch { return View(); }
        }
    }
}
