using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Client.Models
{
    class UsersService
    {
        public UsersService(HttpService service)
        {
            _service = service;
        }

        public Exception LastException { get; set; }

        public async Task<IEnumerable<User>> GetUsersAsync() => await TryGetUsersAsync();

        public async Task<Response> DeleteUserAsync(int id) => await TryDeleteUserAsync(id);

        public async Task<Response> EditUserAsync(User user) => await TryEditUserAsync(user);

        public async Task<Response> AddUserAsync(User user) => await TryAddUserAsync(user);

        private async Task<Response> TryEditUserAsync(User user)
        {
            try
            {
                byte[] buffer = await _service.GetAsync(Properties.Resources.editUserUrl + 
                                                        $"id={user.Id}" +
                                                        $"&surname={user.Surname}" +
                                                        $"&firstname={user.Firstname}" +
                                                        $"&middlename={user.Middlename}" +
                                                        $"&birthday={user.Birthday}" +
                                                        $"&gender={user.Gender}" +
                                                        $"&have_childrens={user.HaveChildrens}");
                return JsonConvert.DeserializeObject<Response>(Encoding.UTF8.GetString(buffer));
            }
            catch (Exception ex)
            {
                LastException = ex;
            }
            return null;
        }

        private async Task<Response> TryAddUserAsync(User user)
        {
            try
            {
                byte[] buffer = await _service.GetAsync(Properties.Resources.addUserUrl +
                                                        $"surname={user.Surname}" +
                                                        $"&firstname={user.Firstname}" +
                                                        $"&middlename={user.Middlename}" +
                                                        $"&birthday={user.Birthday}" +
                                                        $"&gender={user.Gender}" +
                                                        $"&have_childrens={user.HaveChildrens}");
                return JsonConvert.DeserializeObject<Response>(Encoding.UTF8.GetString(buffer));
            }
            catch (Exception ex)
            {
                LastException = ex;
            }
            return null;
        }

        private async Task<Response> TryDeleteUserAsync(int id)
        {
            try
            {
                return JsonConvert.DeserializeObject<Response>(
                    Encoding.UTF8.GetString(await _service.GetAsync(Properties.Resources.deleteUserUrl + id.ToString())));
            }
            catch (Exception ex)
            {
                LastException = ex;
            }

            return null;
        }

        private async Task<IEnumerable<User>> TryGetUsersAsync()
        {
            try
            {
                byte[] buffer = await _service.GetAsync(Properties.Resources.allUsersUrl);
                return JsonConvert.DeserializeObject<IEnumerable<User>>(Encoding.UTF8.GetString(buffer));
            }
            catch (System.Exception ex)
            {
                LastException = ex;
            }

            return null;
        }

        private readonly HttpService _service;
    }
}
