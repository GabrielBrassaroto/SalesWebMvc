using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartamentsController : Controller /// sub classe que herda
    {

        public IActionResult Index()
        {
            List<Departament> list = new List<Departament>();///cria objeto lista 
            list.Add(new Departament { Id = 1, Name = "Gabriel Brasasroto" });/// adiciona na lista 
            list.Add(new Departament { Id = 2, Name = "Artes Senicas " });
            return View(list);/// retona a list na view 
        }
    }
}
