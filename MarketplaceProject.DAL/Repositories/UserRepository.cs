using MarketplaceProject.DAL.Interfaces;
using MarketplaceProject.Domain.Entities;

namespace MarketplaceProject.DAL.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(User entity)
        {
            _db.Users.Add(entity);
            _db.SaveChanges();

            return true;
        }
        public IQueryable<User> Select()
        {
            return _db.Users;
        }

        public bool Delete(User entity)
        {
            _db.Users.Remove(entity);
            _db.SaveChangesAsync();

            return true;
        }

        public User Update(User entity)
        {
            _db.Users.Update(entity);
            _db.SaveChanges();

            return entity;
        }
    }
}
