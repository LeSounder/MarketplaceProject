using MarketplaceProject.DAL.Interfaces;
using MarketplaceProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceProject.DAL.Repositories
{
    public class ProductRepository : IProductRepository
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
        public Product Get(long id)
        {
            return _db.Product.First(x => x.Id == id);
        }
        public IEnumerable<Product> Select()
        {
            return _db.Product.ToList();
        }

        public bool Delete(Product entity)
        {
            _db.Product.Remove(entity);
            _db.SaveChangesAsync();

            return true;
        }

        public Product GetByName(string name)
        {
            return _db.Product.First(x => x.Name == name);
        }

        public Product Update(Product entity)
        {
            _db.Product.Update(entity);
            _db.SaveChanges();

            return entity;
        }
        
    }
}
