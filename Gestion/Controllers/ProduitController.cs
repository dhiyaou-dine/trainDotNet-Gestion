using Gestion.Models.Repositories;
using Gestion.Models;
using Microsoft.AspNetCore.Mvc;
using Gestion.Models.ViewModels;

namespace Gestion.Controllers
{
    public class ProduitController : Controller
    {
        public IRepositorie<Famille> FamilleRepository { get; }
        public IRepositorie<Produits> ProduitRepository { get; }
        public ProduitController(IRepositorie<Produits> produitRepository, IRepositorie<Famille> familleRepository)
        {
            ProduitRepository = produitRepository;
            FamilleRepository = familleRepository;
        }
        public IActionResult Index()
        {
            var produits = ProduitRepository.lister();
            return View(produits);
        }
        public IActionResult Details(int id)
        {
            var produit = ProduitRepository.listerSelonId(id);
            return View(produit);
        }
        public IActionResult Create()
        {
            ProduitFamille viewModel = new ProduitFamille
            {
                FamilleList = FamilleRepository.lister()
            };
            return View(viewModel);
    
        }
        [HttpPost]
        public IActionResult Create(ProduitFamille viewModel)
        {
            try
            {
                var produit = new Produits
                {
                    reference = viewModel.reference,
                    designation = viewModel.designation,
                    description = viewModel.description,
                    disponible = viewModel.disponible,
                    famille = new Famille
                    {
                        id = viewModel.FamilleId,
                        nom = FamilleRepository.listerSelonId(viewModel.FamilleId).nom
                    }
                };
                ProduitRepository.ajouter(produit);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            var produit = ProduitRepository.listerSelonId(id);
            ProduitFamille vewModel = new ProduitFamille
            {
                ProduitId = produit.id,
                reference = produit.reference,
                description = produit.description,
                designation = produit.designation,
                FamilleId = produit.famille.id,
                FamilleList = FamilleRepository.lister()
            };
            return View(vewModel);
        }
        [HttpPost]
        public IActionResult Edit(int id, ProduitFamille viewModel)
        {
            try
            {
                var editeProduit = new Produits
                {
                    id = viewModel.ProduitId,
                    reference = viewModel.reference,
                    description = viewModel.description,
                    designation = viewModel.designation,
                    famille = new Famille
                    {
                        id = viewModel.FamilleId,
                        nom = FamilleRepository.listerSelonId(viewModel.FamilleId).nom
                    }
                };
                ProduitRepository.modifier(id, editeProduit);
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }
    }
}
