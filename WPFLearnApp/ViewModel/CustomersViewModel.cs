using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPFLearnApp.Data;
using WPFLearnApp.Model;

namespace WPFLearnApp.ViewModel;
public class CustomersViewModel : INotifyPropertyChanged
{
    private readonly ICustomerDataProvider _customerDataProvider;
    private Customer? _selectedCustomer;

    public CustomersViewModel(ICustomerDataProvider customerDataProvider)
    {
        _customerDataProvider = customerDataProvider;
    }
    public ObservableCollection<Customer> Customers { get; } = new();

    public Customer? SelectedCustomer
    {
        get => _selectedCustomer;
        set
        {
            _selectedCustomer = value;
            RaisePropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public async Task LoadAsync()
    {
        if (Customers.Any())
        {
            return;
        }

        var customers = await _customerDataProvider.GetAllAsync();
        if (customers is not null)
        {
            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
        }
    }

    internal void Add()
    {
        var customer = new Customer { FirstName = "New" };
        Customers.Add(customer);
        SelectedCustomer = customer;
    }

    private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
