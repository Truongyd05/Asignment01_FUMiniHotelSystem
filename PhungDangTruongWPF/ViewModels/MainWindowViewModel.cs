using System.Windows.Input;
using PhungDangTruongWPF.Commands;

namespace PhungDangTruongWPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            CustomerButtonCommand = new RelayCommand(OpenCustomersWindow);
            RoomButtonCommand = new RelayCommand(OpenRoomsWindow);
            BookingButtonCommand = new RelayCommand(OpenBookingsWindow);
            ReportButtonCommand = new RelayCommand(OpenReportWindow);
            LogoutButtonCommand = new RelayCommand(Logout);
        }

        public ICommand CustomerButtonCommand { get; }
        public ICommand RoomButtonCommand { get; }
        public ICommand BookingButtonCommand { get; }
        public ICommand ReportButtonCommand { get; }
        public ICommand LogoutButtonCommand { get; }

        private void OpenCustomersWindow()
        {
            OnOpenCustomersWindow?.Invoke();
        }

        private void OpenRoomsWindow()
        {
            OnOpenRoomsWindow?.Invoke();
        }

        private void OpenBookingsWindow()
        {
            OnOpenBookingsWindow?.Invoke();
        }

        private void OpenReportWindow()
        {
            OnOpenReportWindow?.Invoke();
        }

        private void Logout()
        {
            OnLogout?.Invoke();
        }

        // Events for view to handle
        public event Action? OnOpenCustomersWindow;
        public event Action? OnOpenRoomsWindow;
        public event Action? OnOpenBookingsWindow;
        public event Action? OnOpenReportWindow;
        public event Action? OnLogout;
    }
}
