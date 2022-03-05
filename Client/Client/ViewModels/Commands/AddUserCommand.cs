using Client.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Client.ViewModels.Commands
{
    class AddUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter)
        {
            MainWindowViewModel viewModel = parameter as MainWindowViewModel;
            Validator validator = new Validator();
            List<string> errors = validator.ValidateUser(viewModel.SelectedUser);

            if(errors.Count == 0)
            {
                UsersService service = new UsersService(new HttpService());
                Response response = await service.AddUserAsync(viewModel.SelectedUser);

                if (response != null)
                {
                    if (response.Message == "ok")
                    {
                        viewModel.Users.Add(new User()
                        {
                            Birthday = viewModel.SelectedUser.Birthday,
                            Firstname = viewModel.SelectedUser.Firstname,
                            Surname = viewModel.SelectedUser.Surname,
                            Gender = viewModel.SelectedUser.Gender,
                            HaveChildrens = viewModel.SelectedUser.HaveChildrens,
                            Id = response.Id,
                            Middlename = viewModel.SelectedUser.Middlename
                        });
                        viewModel.SelectedUser = new User();
                    }
                    else MessageBox.Show(response.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
