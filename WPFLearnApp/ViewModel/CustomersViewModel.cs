using System.Collections.ObjectModel;
using WPFLearnApp.Command;
using WPFLearnApp.Data;
using WPFLearnApp.Model;
using WPFLearnApp.Command;

namespace WPFLearnApp.ViewModel;
public class CustomersViewModel : ViewModelBase
{
    private readonly ICustomerDataProvider _customerDataProvider;
    private CustomerItemViewModel? _selectedCustomer;
    private NavigationSide _navigationSide;

    public CustomersViewModel(ICustomerDataProvider customerDataProvider)
    {
        _customerDataProvider = customerDataProvider;
        AddCommand = new DelegateCommand(Add);
        MoveNavigationCommand = new DelegateCommand(MoveNavigation);
    }
    public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

    public CustomerItemViewModel? SelectedCustomer
    {
        get => _selectedCustomer;
        set
        {
            _selectedCustomer = value;
            RaisePropertyChanged();
        }
    }

    public NavigationSide NavigationSide
    {
        get => _navigationSide;
        private set
        {
            _navigationSide = value;
            RaisePropertyChanged();
        }
    }

    public DelegateCommand AddCommand { get; }
    public DelegateCommand MoveNavigationCommand { get; }

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
                Customers.Add(new CustomerItemViewModel(customer));
            }
        }
    }

    private void Add(object? parameter)
    {
        var customer = new Customer { FirstName = "New" };
        var viewModel = new CustomerItemViewModel(customer);
        Customers.Add(viewModel);
        SelectedCustomer = viewModel;
    }

    private void MoveNavigation(object? parameter)
    {
        NavigationSide = NavigationSide == NavigationSide.Left
            ? NavigationSide.Right
            : NavigationSide.Left;
    }
}

public enum NavigationSide
{
    Left,
    Right
}
