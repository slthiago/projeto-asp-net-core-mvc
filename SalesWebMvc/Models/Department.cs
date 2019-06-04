using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //conecta a classe Department à Seller (1 pra muitos)
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();
        //construtor vazio
        public Department()
        {
        }
        //construtor com argumentos
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
