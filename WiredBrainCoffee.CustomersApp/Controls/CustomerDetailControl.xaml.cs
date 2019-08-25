using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using WiredBrainCoffee.CustomersApp.Model;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace WiredBrainCoffee.CustomersApp.Controls
{
    [ContentProperty(Name = nameof(Customer))]
    public sealed partial class CustomerDetailControl : UserControl
    {
        
        private Customer _customer;
        public CustomerDetailControl()
        {
            this.InitializeComponent();
        }



        public Customer Customer
        {
            get { return (Customer)GetValue(CustomerProperty); }
            set { SetValue(CustomerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Customer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomerProperty =
            DependencyProperty.Register("Customer", typeof(Customer), typeof(CustomerDetailControl), new PropertyMetadata(null));
    }
}
