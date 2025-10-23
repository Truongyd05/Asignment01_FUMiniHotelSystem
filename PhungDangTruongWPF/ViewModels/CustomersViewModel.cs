using System.Collections.ObjectModel;
using System.Windows.Input;
using BLL;
using Models;
using PhungDangTruongWPF.Commands;

namespace PhungDangTruongWPF.ViewModels
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly CustomerService _customerService;
        private ObservableCollection<Customer> _customers;
        private Customer? _selectedCustomer;
        private string _searchText = string.Empty;
        private string _statusText = string.Empty;

        public CustomersViewModel()
        {
            _customerService = new CustomerService();
            _customers = new ObservableCollection<Customer>();
            
            LoadCustomersCommand = new RelayCommand(LoadCustomers);
            AddCustomerCommand = new RelayCommand(AddCustomer);
            EditCustomerCommand = new RelayCommand<Customer>(EditCustomer);
            DeleteCustomerCommand = new RelayCommand<Customer>(DeleteCustomer);
            RefreshCommand = new RelayCommand(LoadCustomers);
            SearchCommand = new RelayCommand(SearchCustomers);
            
            LoadCustomers();
        }

        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set => SetProperty(ref _customers, value);
        }

        public Customer? SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetProperty(ref _selectedCustomer, value);
        }

        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        public string StatusText
        {
            get => _statusText;
            set => SetProperty(ref _statusText, value);
        }

        public ICommand LoadCustomersCommand { get; }
        public ICommand AddCustomerCommand { get; }
        public ICommand EditCustomerCommand { get; }
        public ICommand DeleteCustomerCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand SearchCommand { get; }

        private void LoadCustomers()
        {
            try
            {
                var customers = _customerService.GetAll().ToList();
                Customers = new ObservableCollection<Customer>(customers);
                StatusText = $"Total customers: {customers.Count}";
            }
            catch (Exception ex)
            {
                StatusText = $"Error loading customers: {ex.Message}";
            }
        }

        private void AddCustomer()
        {
            // This will be handled by the view to open CustomerEditWindow
            OnAddCustomerRequested?.Invoke();
        }

        private void EditCustomer(Customer? customer)
        {
            if (customer != null)
            {
                OnEditCustomerRequested?.Invoke(customer);
            }
        }

        private async void DeleteCustomer(Customer? customer)
        {
            if (customer == null) return;

            var result = System.Windows.MessageBox.Show(
                $"Are you sure you want to delete customer {customer.CustomerFullName}?",
                "Confirm Delete",
                System.Windows.MessageBoxButton.YesNo,
                System.Windows.MessageBoxImage.Question);

            if (result == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    bool success = await _customerService.DeleteAsync(customer.CustomerID);
                    if (success)
                    {
                        LoadCustomers();
                        StatusText = "Customer deleted successfully.";
                    }
                    else
                    {
                        StatusText = "Failed to delete customer.";
                    }
                }
                catch (Exception ex)
                {
                    StatusText = $"Error deleting customer: {ex.Message}";
                }
            }
        }

        private void SearchCustomers()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SearchText))
                {
                    LoadCustomers();
                }
                else
                {
                    var filteredCustomers = _customerService.Search(SearchText).ToList();
                    Customers = new ObservableCollection<Customer>(filteredCustomers);
                    StatusText = $"Found {filteredCustomers.Count} customers";
                }
            }
            catch (Exception ex)
            {
                StatusText = $"Error searching customers: {ex.Message}";
            }
        }

        // Events for view to handle
        public event Action? OnAddCustomerRequested;
        public event Action<Customer>? OnEditCustomerRequested;
    }
}
