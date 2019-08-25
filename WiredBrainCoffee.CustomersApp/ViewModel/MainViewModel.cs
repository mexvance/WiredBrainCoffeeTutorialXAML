using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml;
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
                    OnPropertyChanged(nameof(IsCustomerSelected));
                }
            }
        }

        public bool IsCustomerSelected => SelectedCustomer != null;

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

        public void AddCustomer(object sender, RoutedEventArgs e)
        {
            var customer = new Customer { FirstName = "New" };
            Customers.Add(customer);
            SelectedCustomer = customer;
        }

        public void DeleteCustomer(object sender, RoutedEventArgs e)
        {
            var customer = SelectedCustomer as Customer;
            if (customer != null)
            {
                Customers.Remove(customer);
                SelectedCustomer = null;
            }
        }
    }
}
