using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreApp.API.Models;

namespace StoreApp.API.Data
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext _context;

        public StoreRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T: class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T: class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<Book> GetBook(int id)
        {
            return await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _context.Orders.Include(o => o.User).Include(o => o.OrderItems).ThenInclude(o => o.Book).FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<IEnumerable<Order>> GetOrdersForUser(int id)
        {
            return await _context.Orders.Where(o => o.UserId != null).Include(o => o.User).Include(o => o.OrderItems).ThenInclude(o => o.Book).Where(o => o.UserId == id).ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}