using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.DataProvider;
using WiredBrainCoffee.CustomersApp.Model;
using static WiredBrainCoffee.CustomersApp.Base.Customer;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class MainViewModel: Observable
    {

        private ICustomerDataProvider _customerDataProvider;
        public MainViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            Customers = new ObservableCollection<Customer>();
        }

        private Customer _selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    OnPropertyChanged();
                }
            }
        }


        public ObservableCollection<Customer> Customers { get; }

        public async Task LoadAsync()
        {
            Customers.Clear();
            var customers = await _customerDataProvider.LoadCustomersAsync();
            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
        }

        public async Task SaveAsync()
        {
            await _customerDataProvider.SaveCustomerAsync(Customers);
        }
    }
}
