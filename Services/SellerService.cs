using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;//criar o objeto de contexto

        public SellerService(SalesWebMvcContext context)///contrutur para pode fazer injecao 
        {
            _context = context;/// passa para o contexto
        }

        public IList<Seller> FindAll()//pesquisa tudo 
        {
            return _context.Seller.ToList(); //// pega todos os registro do banco 
        }

        public void Insert(Seller obj)
        {
            ////obj.Departament = _context.Departament.First(); //pega o primeiro departamento e associa ao vendedor
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
