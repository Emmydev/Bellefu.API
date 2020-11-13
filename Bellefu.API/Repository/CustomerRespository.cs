using Bellefu.API.Data;
using Bellefu.API.DbObjects;
using Bellefu.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bellefu.API.Repository
{
    public class CustomerRespository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRespository(DataContext context)
        {
            _context = context;
        }

        public bool DeleteCustomer(int Id)
        {
            try
            {
                var customer = _context.Customers.Find(Id);
                if (customer != null)
                {
                    customer.Deleted = true;
                }
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public bool DeleteMultiCustomer(int[] Id)
        {


            try
            {
                foreach (int i in Id)
                {
                    //var customer = _context.Customers.Find(Id);
                    //var customer = _context.Customers.Where(x => x.CustomerId == i)
                    //var customer = _context.Customers.Where(x => x.CustomerId.Equals(Id)).FirstOrDefault();
                    var customer = _context.Customers.Find(i);
                    if (customer != null)
                    {
                        customer.Deleted = true;
                    }
                }
                 
                return _context.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;

            //try
            //{
            //    //var customer = _context.Customers.Find(Id);
            //    var customer = _context.Customers.Where(x => x.CustomerId.Equals(Id)).FirstOrDefault();
            //    if (customer != null)
            //    {
            //        customer.Deleted = true;
            //    }
            //    return _context.SaveChanges() > 0;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public IEnumerable<CustomerObj> GetAllCustomers()
        {
            try
            {
                var customerList = (from a in _context.Customers
                                    where a.Deleted == false
                                    select new CustomerObj
                                    {
                                        CustomerId = a.CustomerId,
                                        FullName = a.FullName,
                                        Address = a.Address,
                                        Email = a.Email,
                                        PhoneContact = a.PhoneContact,
                                    }).ToList();

                return customerList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CustomerObj GetCustomerById(int Id)
        {
            try
            {
                var customer = (from a in _context.Customers
                                where a.Deleted == false && a.CustomerId == Id
                                select new CustomerObj
                                {
                                    CustomerId = a.CustomerId,
                                    FullName = a.FullName,
                                    Address = a.Address,
                                    Email = a.Email,
                                    PhoneContact = a.PhoneContact,
                                }).FirstOrDefault();

                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateCustomer(CustomerObj entity)
        {
            try
            {
                if (entity == null) return false;

                if (entity.CustomerId > 0)
                {
                    var itemExist = _context.Customers.FirstOrDefault(x => x.CustomerId == entity.CustomerId);
                    if (itemExist != null)
                    {
                        itemExist.FullName = entity.FullName;
                        itemExist.Address = entity.Address;
                        itemExist.Email = entity.Email;
                        itemExist.PhoneContact = entity.PhoneContact;
                        itemExist.Active = true;
                        itemExist.Deleted = false;
                        itemExist.UpdatedBy = entity.CreatedBy;
                        itemExist.UpdatedOn = DateTime.Now;
                    }
                }
                else
                {
                    var item = new Customers
                    {
                        FullName = entity.FullName,
                        Address = entity.Address,
                        Email = entity.Email,
                        PhoneContact = entity.PhoneContact,
                        Active = true,
                        Deleted = false,
                        CreatedBy = entity.CreatedBy,
                        CreatedOn = DateTime.Now,
                    };
                    _context.Customers.Add(item);
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
