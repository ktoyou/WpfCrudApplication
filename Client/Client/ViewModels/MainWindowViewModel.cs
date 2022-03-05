using Client.Models;
using Client.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            _usersService = new UsersService(new HttpService());
            SelectedUser = new User();
            Task.Run(LoadUsersAsync);
        }

        public ICommand DeleteUserCommand { get => new DeleteUserCommand(Users); }

        public ICommand AddUserCommand { get => new AddUserCommand(); }

        public ICommand EditUserCommand { get => new EditUserCommand(); }

        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value == null ? new User() : value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        private async Task LoadUsersAsync()
        {
            var users = await _usersService.GetUsersAsync();
            if (users == null) MessageBox.Show($"{_usersService.LastException.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else Users = new ObservableCollection<User>(users);
        }

        private UsersService _usersService;
        private User _selectedUser;
        private ObservableCollection<User> _users;
    }
}
