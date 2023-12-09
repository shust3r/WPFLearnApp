using System.Windows;
using System.Windows.Controls;
using WPFLearnApp.Data;
using WPFLearnApp.ViewModel;

namespace WPFLearnApp.View
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        private CustomersViewModel _viewModel;

        public CustomersView()
        {
            InitializeComponent();
            _viewModel = new CustomersViewModel(new CustomerDataProvider());
            DataContext = _viewModel;
            Loaded += CustomersView_Loaded;
        }

        private async void CustomersView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.MoveNavigation();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Add();
        }
    }
}
