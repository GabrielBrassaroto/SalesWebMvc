using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime birthDate { get; set; }
        public double baseSalary { get; set; }
        public Departament Departament { get; set; } // ligacao do departamento pro saller 
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();//// de um para muitos do sales pro sallesrecord que que respresenta um vendedor 
        
        public Seller()//contrutor vazio
        {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            this.birthDate = birthDate;
            this.baseSalary = baseSalary;
            Departament = departament;
        }
   
        public void AddSaler(SalesRecord sr) ///adciona uma venda para um vendedor
        {
            Sales.Add(sr); /// sales é vendedor sr a venda e  sr repsenta o salesrecord
        }

        public void RemoveSaler(SalesRecord sr) /// remove uma venda do vendedor
        {
            Sales.Remove(sr); ///sales é vendedor e o sr é a venda e  sr repsenta o salesrecord
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            /// pega a data inicial e final e soma com amount o sr repsenta o salesrecord
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);

        }
    
    }
}
