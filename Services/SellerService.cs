using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;

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

        public Seller FindById(int id) ///o include do core para puxar nome do departamento tipo inner join sql
        {
            return _context.Seller.Include(obj => obj.Departament).FirstOrDefault(obj => obj.Id == id);/// retorna o primeiro que o linq achar for igual ao do id
        }

        public void Remove(int id)
        {
            var obj =_context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Seller obj)
        {
            if(!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");

            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e )
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
