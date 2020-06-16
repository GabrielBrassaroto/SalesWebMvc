using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }//tem que ter um vendedor
        public ICollection<Departament> Departaments { get; set; }/// uma lista de colecao generica para retorna os departamentos
    }
}
