using System.Collections.ObjectModel;
using System.Windows.Input;
using BLL;
using Models;
using PhungDangTruongWPF.Commands;

namespace PhungDangTruongWPF.ViewModels
{
    public class RoomsViewModel : ViewModelBase
    {
        private readonly RoomService _roomService;
        private ObservableCollection<RoomInformation> _rooms;
        private ObservableCollection<RoomType> _roomTypes;
        private RoomInformation? _selectedRoom;
        private string _searchText = string.Empty;
        private string _statusText = string.Empty;

        public RoomsViewModel()
        {
            _roomService = new RoomService();
            _rooms = new ObservableCollection<RoomInformation>();
            _roomTypes = new ObservableCollection<RoomType>();
            
            LoadRoomsCommand = new RelayCommand(LoadRooms);
            AddRoomCommand = new RelayCommand(AddRoom);
            EditRoomCommand = new RelayCommand<RoomInformation>(EditRoom);
            DeleteRoomCommand = new RelayCommand<RoomInformation>(DeleteRoom);
            RefreshCommand = new RelayCommand(LoadRooms);
            SearchCommand = new RelayCommand(SearchRooms);
            
            LoadRooms();
            LoadRoomTypes();
        }

        public ObservableCollection<RoomInformation> Rooms
        {
            get => _rooms;
            set => SetProperty(ref _rooms, value);
        }

        public ObservableCollection<RoomType> RoomTypes
        {
            get => _roomTypes;
            set => SetProperty(ref _roomTypes, value);
        }

        public RoomInformation? SelectedRoom
        {
            get => _selectedRoom;
            set => SetProperty(ref _selectedRoom, value);
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

        public ICommand LoadRoomsCommand { get; }
        public ICommand AddRoomCommand { get; }
        public ICommand EditRoomCommand { get; }
        public ICommand DeleteRoomCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand SearchCommand { get; }

        private void LoadRooms()
        {
            try
            {
                var rooms = _roomService.GetAll().ToList();
                Rooms = new ObservableCollection<RoomInformation>(rooms);
                StatusText = $"Total rooms: {rooms.Count}";
            }
            catch (Exception ex)
            {
                StatusText = $"Error loading rooms: {ex.Message}";
            }
        }

        private void LoadRoomTypes()
        {
            try
            {
                var roomTypes = _roomService.GetAllRoomTypes().ToList();
                RoomTypes = new ObservableCollection<RoomType>(roomTypes);
            }
            catch (Exception ex)
            {
                StatusText = $"Error loading room types: {ex.Message}";
            }
        }

        private void AddRoom()
        {
            OnAddRoomRequested?.Invoke();
        }

        private void EditRoom(RoomInformation? room)
        {
            if (room != null)
            {
                OnEditRoomRequested?.Invoke(room);
            }
        }

        private async void DeleteRoom(RoomInformation? room)
        {
            if (room == null) return;

            var result = System.Windows.MessageBox.Show(
                $"Are you sure you want to delete room {room.RoomNumber}?",
                "Confirm Delete",
                System.Windows.MessageBoxButton.YesNo,
                System.Windows.MessageBoxImage.Question);

            if (result == System.Windows.MessageBoxResult.Yes)
            {
                try
                {
                    bool success = await _roomService.DeleteAsync(room.RoomID);
                    if (success)
                    {
                        LoadRooms();
                        StatusText = "Room deleted successfully.";
                    }
                    else
                    {
                        StatusText = "Failed to delete room.";
                    }
                }
                catch (Exception ex)
                {
                    StatusText = $"Error deleting room: {ex.Message}";
                }
            }
        }

        private void SearchRooms()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SearchText))
                {
                    LoadRooms();
                }
                else
                {
                    var filteredRooms = _roomService.Search(SearchText).ToList();
                    Rooms = new ObservableCollection<RoomInformation>(filteredRooms);
                    StatusText = $"Found {filteredRooms.Count} rooms";
                }
            }
            catch (Exception ex)
            {
                StatusText = $"Error searching rooms: {ex.Message}";
            }
        }

        // Events for view to handle
        public event Action? OnAddRoomRequested;
        public event Action<RoomInformation>? OnEditRoomRequested;
    }
}
