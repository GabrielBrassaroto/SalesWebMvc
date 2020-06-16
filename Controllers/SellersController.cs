using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService; // importa o servico
        private readonly DepartamentService _departamentService;


        public SellersController(SellerService sellerService, DepartamentService departamentService)// o contrutor para acessar o servico
        {
            _sellerService = sellerService;
            _departamentService = departamentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();/// faz a pesquisa
            return View(list);/// retorna a lista para view 
        }

        public IActionResult Create()
        {
            var departaments = _departamentService.FindAll(); //retorna todos os departamentos do banco
            var viewModel = new SellerFormViewModel { Departaments = departaments}; /// colecao la do modelview 
            return View(viewModel); // retorna a view com os departamentos populados
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction("Index");
        }
    }
}