using System.Collections.Generic;
using System;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>(); /// ligacao do departamento com seller 

        public Departament() // contrutor vazio
        {

        }

        public Departament(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller); /// sellers é lista que vem no icolletion e vou adcionar um vendedor
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            /// pega o total sales do seller e data final e inicial e soma 
            return Sellers.Sum(seller => seller.TotalSales(initial, final));

        }
    }
}
