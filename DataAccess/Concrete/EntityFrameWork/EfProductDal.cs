using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product product)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var addedentity = context.Entry(product);
                addedentity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deleted = context.Entry(product);
                deleted.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Product> Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter).ToList();
            }
        }

        public List<Product> Get(Func<Product, bool> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Func<Product, bool> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
          
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updated = context.Entry(product);
                updated.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
