﻿using MarketplaceProject.DAL.Interfaces;
using MarketplaceProject.Domain.Entities;

namespace MarketplaceProject.DAL.Repositories
{
    public class ProductRepository : IBaseRepository<Product>
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Product entity)
        {
            _db.Product.Add(entity);
            _db.SaveChanges();

            return true;
        }
        public IQueryable<Product> Select()
        {
            return _db.Product;
        }

        public bool Delete(Product entity)
        {
            _db.Product.Remove(entity);
            _db.SaveChangesAsync();

            return true;
        }

        public Product Update(Product entity)
        {
            _db.Product.Update(entity);
            _db.SaveChanges();

            return entity;
        }
        
    }
}
