using Bellefu.API.Data;
using Bellefu.API.DbObjects;
using Bellefu.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bellefu.API.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        public bool DeleteOrder(int Id)
        {
            try
            {
                var order = _context.Order.Find(Id);
                if (order != null)
                {
                    order.Deleted = true;
                }
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<OrderObj> GetAllOrder()
        {
            try
            {
                var orderList = (from a in _context.Order
                                 join b in _context.Customers on a.CustomerId equals b.CustomerId
                                 join c in  _context.Menu on a.MenuId equals c.MenuId
                                    where a.Deleted == false
                                    select new OrderObj
                                    {
                                        CustomerId = b.CustomerId,
                                        CustomerName = b.FullName,
                                        MenuId = c.MenuId,
                                        MenuName = c.Name,
                                        OrderId = a.OrderId,
                                        PhoneContact = b.PhoneContact,
                                        DeliveryStatus = a.DeliveryStatus,
                                        RequestDate = DateTime.Now,
                                        Quantity = a.Quantity,
                                        ActualCost = a.ActualCost,
                                        DeliveryStatusName = (a.DeliveryStatus == 1) ? "Successful": 
                                        (a.DeliveryStatus == 2) ? "Pending" : 
                                        (a.DeliveryStatus == 3)? "Cancelled": null,

                                    }).ToList();

                return orderList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderObj GetOrderById(int Id)
        {
            try
            {
                var order = (from a in _context.Order
                             join b in _context.Customers on a.CustomerId equals b.CustomerId
                             join c in _context.Menu on a.MenuId equals c.MenuId
                             where a.Deleted == false && a.OrderId == Id
                                select new OrderObj
                                {
                                    CustomerId = b.CustomerId,
                                    CustomerName = b.FullName,
                                    MenuId = c.MenuId,
                                    MenuName = c.Name,
                                    OrderId = a.OrderId,
                                    PhoneContact = b.PhoneContact,
                                    DeliveryStatus = a.DeliveryStatus,
                                    RequestDate = DateTime.Now,
                                    Quantity = a.Quantity,
                                    ActualCost = a.ActualCost,
                                    DeliveryStatusName = (a.DeliveryStatus == 1) ? "Successful" :
                                        (a.DeliveryStatus == 2) ? "Pending" :
                                        (a.DeliveryStatus == 3) ? "Cancelled" : null,
                                }).FirstOrDefault();

                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderObj GetOrderByCustomerId(int Id)
        {
            try
            {
                var order = (from a in _context.Order
                             join b in _context.Customers on a.CustomerId equals b.CustomerId
                             join c in _context.Menu on a.MenuId equals c.MenuId
                             where a.Deleted == false && a.CustomerId == Id
                             select new OrderObj
                             {
                                 CustomerId = b.CustomerId,
                                 CustomerName = b.FullName,
                                 MenuId = c.MenuId,
                                 MenuName = c.Name,
                                 OrderId = a.OrderId,
                                 PhoneContact = b.PhoneContact,
                                 DeliveryStatus = a.DeliveryStatus,
                                 RequestDate = DateTime.Now,
                                 Quantity = a.Quantity,
                                 ActualCost = a.ActualCost,
                                 DeliveryStatusName = (a.DeliveryStatus == 1) ? "Successful" :
                                     (a.DeliveryStatus == 2) ? "Pending" :
                                     (a.DeliveryStatus == 3) ? "Cancelled" : null,
                             }).FirstOrDefault();

                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public OrderObj GetOrderByMenuId(int Id)
        {
            try
            {
                var order = (from a in _context.Order
                             join b in _context.Customers on a.CustomerId equals b.CustomerId
                             join c in _context.Menu on a.MenuId equals c.MenuId
                             where a.Deleted == false && a.MenuId == Id
                             select new OrderObj
                             {
                                 CustomerId = b.CustomerId,
                                 CustomerName = b.FullName,
                                 MenuId = c.MenuId,
                                 MenuName = c.Name,
                                 OrderId = a.OrderId,
                                 PhoneContact = b.PhoneContact,
                                 DeliveryStatus = a.DeliveryStatus,
                                 RequestDate = DateTime.Now,
                                 Quantity = a.Quantity,
                                 ActualCost = a.ActualCost,
                                 DeliveryStatusName = (a.DeliveryStatus == 1) ? "Successful" :
                                     (a.DeliveryStatus == 2) ? "Pending" :
                                     (a.DeliveryStatus == 3) ? "Cancelled" : null,
                             }).FirstOrDefault();

                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public OrderObj GetOrderByCustomerName(string name)
        {
            try
            {
                var order = (from a in _context.Order
                             join b in _context.Customers on a.CustomerId equals b.CustomerId
                             join c in _context.Menu on a.MenuId equals c.MenuId
                             where a.Deleted == false && b.FullName == name
                             select new OrderObj
                             {
                                 CustomerId = b.CustomerId,
                                 CustomerName = b.FullName,
                                 MenuId = c.MenuId,
                                 MenuName = c.Name,
                                 OrderId = a.OrderId,
                                 PhoneContact = b.PhoneContact,
                                 DeliveryStatus = a.DeliveryStatus,
                                 RequestDate = DateTime.Now,
                                 Quantity = a.Quantity,
                                 ActualCost = a.ActualCost,
                                 DeliveryStatusName = (a.DeliveryStatus == 1) ? "Successful" :
                                     (a.DeliveryStatus == 2) ? "Pending" :
                                     (a.DeliveryStatus == 3) ? "Cancelled" : null,
                             }).FirstOrDefault();

                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderObj GetOrderByMenuName(string name)
        {
            try
            {
                var order = (from a in _context.Order
                             join b in _context.Customers on a.CustomerId equals b.CustomerId
                             join c in _context.Menu on a.MenuId equals c.MenuId
                             where a.Deleted == false && c.Name == name
                             select new OrderObj
                             {
                                 CustomerId = b.CustomerId,
                                 CustomerName = b.FullName,
                                 MenuId = c.MenuId,
                                 MenuName = c.Name,
                                 OrderId = a.OrderId,
                                 PhoneContact = b.PhoneContact,
                                 DeliveryStatus = a.DeliveryStatus,
                                 RequestDate = DateTime.Now,
                                 Quantity = a.Quantity,
                                 ActualCost = a.ActualCost,
                                 DeliveryStatusName = (a.DeliveryStatus == 1) ? "Successful" :
                                     (a.DeliveryStatus == 2) ? "Pending" :
                                     (a.DeliveryStatus == 3) ? "Cancelled" : null,
                             }).FirstOrDefault();

                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateOrder(OrderObj entity)
        {
            try
            {
                if (entity == null) return false;

                if (entity.OrderId > 0)
                {
                    var itemExist = _context.Order.FirstOrDefault(x => x.OrderId == entity.OrderId);
                    if (itemExist != null)
                    {
                        itemExist.CustomerId = entity.CustomerId;
                        itemExist.MenuId = entity.MenuId;
                        itemExist.RequestDate = entity.RequestDate;
                        itemExist.Quantity = entity.Quantity;
                        itemExist.ActualCost = entity.ActualCost;
                        itemExist.DeliveryStatus = entity.DeliveryStatus;
                        itemExist.Active = true;
                        itemExist.Deleted = false;
                        itemExist.UpdatedBy = entity.UpdatedBy;
                        itemExist.UpdatedOn = DateTime.Now;
                    }
                }
                else
                {
                    var item = new Order
                    {
                        CustomerId = entity.CustomerId,
                        MenuId = entity.MenuId,
                        RequestDate = DateTime.Now,
                        Quantity = entity.Quantity,
                        ActualCost = entity.ActualCost,
                        DeliveryStatus = entity.DeliveryStatus,
                        Active = true,
                        Deleted = false,
                        CreatedBy = entity.CreatedBy,
                        CreatedOn = DateTime.Now,
                    };
                    _context.Order.Add(item);
                }

                var response = _context.SaveChanges() > 0;

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
