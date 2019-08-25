using System.Collections.Generic;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.DataProvider
{
    public interface ICustomerDataProvider
    {
        Task<IEnumerable<Customer>> LoadCustomersAsync();
        Task SaveCustomerAsync(IEnumerable<Customer> customers);
    }
}