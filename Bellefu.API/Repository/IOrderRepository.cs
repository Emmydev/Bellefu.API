using Bellefu.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bellefu.API.Repository
{
    public interface IOrderRepository
    {
        bool DeleteOrder(int Id);

        IEnumerable<OrderObj> GetAllOrder();

        OrderObj GetOrderById(int Id);

        OrderObj GetOrderByCustomerId(int Id);
        OrderObj GetOrderByCustomerName(string name);
        OrderObj GetOrderByMenuId(int Id);
        OrderObj GetOrderByMenuName(string name);
        bool UpdateOrder(OrderObj entity);
    }
}
