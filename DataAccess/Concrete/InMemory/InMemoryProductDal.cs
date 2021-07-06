using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List <Product> products;

       public InMemoryProductDal()
        {
            products = new List<Product> {
            new Product { CategoryId = 1, ProductId = 1, ProductName = "Bardak", UnitsInStock = 15, UnitPrice = 27 },
            new Product { CategoryId = 1, ProductId = 2, ProductName = "Tabak", UnitsInStock = 500, UnitPrice = 97 },
            new Product { CategoryId = 2, ProductId = 3, ProductName = "Bilgisayar", UnitsInStock = 1500, UnitPrice = 1 },
        };
            
        }

        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Delete(Product product)
        {
            Product tempproduct = products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //var result = from p in products where p.ProductId == product.ProductId select p;
            products.Remove(tempproduct);
        }

        public List<Product> Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Func<Product, bool> filter=null)
        {
            return filter == null ? products : products.Where(filter).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
       
        }
    }
}
