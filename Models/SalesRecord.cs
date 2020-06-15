using System;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; } /// ligacao de seller de um para um

        public SalesRecord() //contrutor sem argumentos
        {

        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller) //contrutor com argumentos
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }

}
