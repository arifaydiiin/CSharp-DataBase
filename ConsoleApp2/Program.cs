using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productmanager = new ProductManager(new InMemoryProductDal());
            
            foreach (var item in productmanager.GetAll(p => p.ProductName =="Tabak"))
            {
                Console.WriteLine(item.ProductName);
            }
       
        }
    }
}
