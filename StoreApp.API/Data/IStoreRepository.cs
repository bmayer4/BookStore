using System.Collections.Generic;
using System.Threading.Tasks;
using StoreApp.API.Models;

namespace StoreApp.API.Data
{
    public interface IStoreRepository
    {
        void Add<T>(T Entity) where T: class;
        void Delete<T>(T Entity) where T: class;
        Task<bool> SaveAll();
        Task<User> GetUser(int id);
        Task<Order> GetOrder(int id);
        Task<IEnumerable<Order>> GetOrdersForUser(int id);
        Task<Book> GetBook(int id);
        Task<IEnumerable<Book>> GetBooks();
    }
}