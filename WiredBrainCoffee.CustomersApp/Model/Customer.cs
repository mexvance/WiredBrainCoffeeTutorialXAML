using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WiredBrainCoffee.CustomersApp.Base.Customer;
using static WiredBrainCoffee.CustomersApp.Model.Customer;

namespace WiredBrainCoffee.CustomersApp.Model
{
    partial class Customer : Observable
    {
        private string firstName;
        private string lastName;
        private bool isDeveloper;

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }
        public bool IsDeveloper
        {
            get => isDeveloper;
            set
            {
                isDeveloper = value;
                OnPropertyChanged();
            }
        }
    }
}
