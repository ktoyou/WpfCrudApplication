using Client.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Client.ViewModels.Commands
{
    class EditUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter)
        {
            User user = (parameter as MainWindowViewModel).SelectedUser;
            Validator validator = new Validator();
            
            List<string> errors = validator.ValidateUser(user);
            if(errors.Count == 0)
            {
                UsersService service = new UsersService(new HttpService());
                Response response = await service.EditUserAsync((parameter as MainWindowViewModel).SelectedUser);
                if (response != null)
                {
                    if (response.Message != "ok") MessageBox.Show(response.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show(service.LastException.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            } else
            {
                string message = null;
                errors.ForEach(error => message += error + "\n");
                MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
