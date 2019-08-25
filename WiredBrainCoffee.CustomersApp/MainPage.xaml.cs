using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using WiredBrainCoffee.CustomersApp.DataProvider;
using Windows.ApplicationModel;
using System.Linq;
using WiredBrainCoffee.CustomersApp.Model;
using WiredBrainCoffee.CustomersApp.ViewModel;

namespace WiredBrainCoffee.CustomersApp
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; }

        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel(new CustomerDataProvider());
            this.Loaded += MainPage_Loaded;
            App.Current.Suspending += App_Suspending;
            RequestedTheme = App.Current.RequestedTheme == ApplicationTheme.Dark
                ? ElementTheme.Dark : ElementTheme.Light;
        }

        private async void App_Suspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await ViewModel.SaveAsync();
            deferral.Complete();
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadAsync();
        }

        private void ButtonMove_Click(object sender, RoutedEventArgs e)
        {
            //int column = (int)customerListGrid.GetValue(Grid.ColumnProperty); This one gets an object

            int column = Grid.GetColumn(customerListGrid);

            int newColumn = column == 0 ? 2 : 0;
            customerListGrid.SetValue(Grid.ColumnProperty, newColumn);

            moveSymbolIcon.Symbol = newColumn == 0 ? Symbol.Forward : Symbol.Back;
        }

        private void ButtonToggleTheme_Click(object sender, RoutedEventArgs e)
        {
            this.RequestedTheme = RequestedTheme == ElementTheme.Dark ? ElementTheme.Light : ElementTheme.Dark;
        }
    }
}
