using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Service
{
    public class OrderService : ServiceBaseImpl<Order>
    {
        private readonly RepositoryBaseImpl<Order> _repositoryBase;
        public OrderService()
        {
            _repositoryBase = new RepositoryBaseImpl<Order>();
        }

        public override List<Order> GetAll()
        {
            return _repositoryBase.GetAll().Include(o => o.Customer).ToList();
        }
    }
}
