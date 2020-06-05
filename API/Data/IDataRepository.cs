using System.Collections.Generic;
using System.Threading.Tasks;
using API.Helpers;
using API.Models;

namespace API.Data
{
    public interface IDataRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        
        Task<PagedList<User>> GetUsers(UserParams userParams);
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}