using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class UsersRepository : IRepository
    {
        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
            _okResponse = new ResponseModel() { id = 0, Message = "ok" };
        }

        public async Task<BaseModel> AddAsync(BaseModel model) => await TryAddAsync(model as User);

        public async Task<IEnumerable<BaseModel>> GetAllAsync() => await _context.Users.ToListAsync();

        public async Task<BaseModel> DeleteAsync(int id) => await TryDeleteAsync(id);

        public async Task<BaseModel> GetAsync(int id) => await TryGetAsync(id);

        public async Task<BaseModel> EditAsync(BaseModel model) => await TryEditAsync(model as User);

        private async Task<BaseModel> TryEditAsync(User user)
        {
            try
            {
                var findedUser = await _context.Users.Where(elem => elem.id == user.id).FirstOrDefaultAsync();
                if (findedUser == null) return new ResponseModel() { id = -1, Message = $"Object not finded" };

                findedUser.firstname = user.firstname;
                findedUser.birthday = user.birthday;
                findedUser.have_childrens = user.have_childrens;
                findedUser.middlename = user.middlename;
                findedUser.gender = user.gender;
                findedUser.surname = user.surname;

                await _context.SaveChangesAsync();

                return _okResponse;
            }
            catch (Exception ex)
            {
                return new ResponseModel() { id = -1, Message = ex.Message };
            }
        }

        private async Task<BaseModel> TryAddAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                _okResponse.id = user.id;
                return _okResponse;
            }
            catch (Exception ex)
            {
                return new ResponseModel() { Message = ex.Message, id = -1 };
            }
        }

        private async Task<BaseModel> TryDeleteAsync(int id)
        {
            try
            {
                var user = await _context.Users.Where(user => user.id == id).FirstOrDefaultAsync();
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return _okResponse;
            }
            catch (Exception ex)
            {
                return new ResponseModel() { Message = ex.Message, id = -1 };
            }
        }

        private async Task<BaseModel> TryGetAsync(int id)
        {
            try
            {
                return await _context.Users.Where(user => user.id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return new ResponseModel() { id = -1, Message = ex.Message };
            }
        }

        private ApplicationDbContext _context;
        private readonly ResponseModel _okResponse;
    }
}
