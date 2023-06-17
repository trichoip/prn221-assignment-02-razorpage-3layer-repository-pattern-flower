using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Service
{
    public class FlowerBouquetService : ServiceBaseImpl<FlowerBouquet>
    {
        private readonly RepositoryBaseImpl<FlowerBouquet> _repositoryBase;
        public FlowerBouquetService()
        {
            _repositoryBase = new RepositoryBaseImpl<FlowerBouquet>();
        }
        public override List<FlowerBouquet> GetAll()
        {
            return _repositoryBase.GetAll().Include(f => f.Category).Include(f => f.Supplier).ToList();
        }
    }
}
