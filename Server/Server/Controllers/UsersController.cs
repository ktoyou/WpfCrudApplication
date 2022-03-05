using Microsoft.AspNetCore.Mvc;
using Server.Models;
using System;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class UsersController : Controller
    {
        public UsersController(UsersRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> Index() => Json(await repository.GetAllAsync());

        public async Task<IActionResult> Delete(int id) => Json(await repository.DeleteAsync(id));

        public async Task<IActionResult> Create(string surname, string firstname, string middlename, DateTime birthday, string gender, bool have_childrens)
        {
            return Json(await repository.AddAsync(new User()
            {
                surname = surname,
                firstname = firstname,
                birthday = birthday,
                have_childrens = have_childrens,
                middlename = middlename,
                gender = gender
            }));
        }

        public async Task<IActionResult> Edit(int id, string surname, string firstname, string middlename, DateTime birthday, string gender, bool have_childrens)
        {
            return Json(await repository.EditAsync(new User()
            {
                id = id,
                firstname = firstname,
                birthday = birthday,
                have_childrens = have_childrens,
                middlename = middlename,
                gender = gender,
                surname = surname
            }));
        }

        private readonly UsersRepository repository;
    }
}
