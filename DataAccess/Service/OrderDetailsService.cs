using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Service
{
    public class OrderDetailsService : ServiceBaseImpl<OrderDetail>
    {
        private readonly RepositoryBaseImpl<OrderDetail> _repositoryBase;
        public OrderDetailsService()
        {
            _repositoryBase = new RepositoryBaseImpl<OrderDetail>();
        }

        public override List<OrderDetail> GetAll()
        {
            return _repositoryBase.GetAll().Include(o => o.FlowerBouquet).ToList();
        }
    }
}
