using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class RepositoryBaseImpl<T> where T : class
    {
        private readonly FuflowerBouquetManagementContext _context;
        public RepositoryBaseImpl()
        {
            _context = new FuflowerBouquetManagementContext();
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            T entity = GetById(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual IQueryable<T> GetAll()
        {
            // khong nen dong ket noi o day vì IQueryable ma mat kêt nôi thi không tolist duoc
            return _context.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
