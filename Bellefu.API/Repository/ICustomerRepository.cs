using Bellefu.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bellefu.API.Repository
{
    public interface ICustomerRepository
    {
        bool DeleteCustomer(int Id);

        bool DeleteMultiCustomer(int[] Id);
        IEnumerable<CustomerObj> GetAllCustomers();
        CustomerObj GetCustomerById(int Id);
        bool UpdateCustomer(CustomerObj entity);
    }
}
