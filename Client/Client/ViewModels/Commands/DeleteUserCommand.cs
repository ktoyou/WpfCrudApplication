using Client.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Client.ViewModels.Commands
{
    class DeleteUserCommand : ICommand
    {
        public DeleteUserCommand(ObservableCollection<User> users)
        {
            _users = users;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter)
        {
            User user = parameter as User;
            UsersService service = new UsersService(new HttpService());
            Response response = await service.DeleteUserAsync(user.Id);
            if(response != null)
            {
                if (response.Message == "ok")
                {
                    _users.Remove(user);
                }
                else MessageBox.Show(response.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show(service.LastException.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private ObservableCollection<User> _users;
    }
}
