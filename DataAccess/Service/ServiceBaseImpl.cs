using DataAccess.Repository;

namespace DataAccess.Service
{
    public class ServiceBaseImpl<T> where T : class
    {
        private readonly RepositoryBaseImpl<T> _repositoryBase;

        public ServiceBaseImpl()
        {
            _repositoryBase = new RepositoryBaseImpl<T>();
        }

        public virtual void Add(T entity)
        {
            _repositoryBase.Add(entity);
        }

        public virtual void Delete(int id)
        {
            _repositoryBase.Delete(id);
        }
        public virtual List<T> GetAll()
        {
            return _repositoryBase.GetAll().ToList();
        }
        public virtual T GetById(int id)
        {
            return _repositoryBase.GetById(id);
        }
        public virtual void Update(T entity)
        {
            _repositoryBase.Update(entity);
        }
    }
}
