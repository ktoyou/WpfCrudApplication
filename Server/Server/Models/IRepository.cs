using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public interface IRepository
    {
        Task<IEnumerable<BaseModel>> GetAllAsync();

        Task<BaseModel> GetAsync(int id);

        Task<BaseModel> AddAsync(BaseModel model);

        Task<BaseModel> EditAsync(BaseModel model);

        Task<BaseModel> DeleteAsync(int id);
    }
}
