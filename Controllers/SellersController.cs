using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;

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
            var viewModel = new SellerFormViewModel { Departaments = departaments }; /// colecao la do modelview 
            return View(viewModel); // retorna a view com os departamentos populados
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id) ///o id pode ser vazio
        {
            if (id == null) ///id for vazio retorna notfound
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);///pesquisa o objeto com id.value pq ele pode ser null pq do ?
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)///o id pode ser vazio
        {
            if (id == null)///id for vazio retorna notfound
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);///pesquisa o objeto com id.value pq ele pode ser null pq do ?
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Edit(int? id) //metodo get para retorna somente a view
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            List<Departament> departaments = _departamentService.FindAll(); /// cria a lista e prenche os departamentos la tela 
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departaments = departaments };///prencher os campos com o dados existentes ja
            return View(viewModel);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if(id != seller.Id)
            {
                return BadRequest();
            }
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction("Index");
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }

    }
}