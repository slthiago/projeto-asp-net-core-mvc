using System;
using System.Collections.Generic;
using System.Linq;


namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        //conecta a classe Seller à Department (muitos pra 1)
        public Department Department { get; set; }
        //conecta a classe Seller à Sales (1 pra muitos)
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        //construtor vazio
        public Seller()
        {
        }
        //construtor com argumentos
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
        }
        
        //método para adicionar venda
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        //método para remover venda
        public void RemoveSale(SalesRecord sr)
        {
            Sales.Remove(sr);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);

        }


    }
}
