using Microsoft.EntityFrameworkCore;
using SmartPacking.Data;
using SmartPacking.Model;
using SmartPacking.Repository.Interfaces;

namespace SmartPacking.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SmartPackingContext _context;

        public OrderRepository(SmartPackingContext smartPackingContext)
        {
            _context = smartPackingContext;
        }

        public async Task<List<OrderModel>> AddOrdersAsync(List<OrderModel> orders)
        {
            await _context.Orders.AddRangeAsync(orders);
            await _context.SaveChangesAsync();

            return orders;
        }

        public async Task<List<OrderModel>> SearchAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<OrderModel> SearchForIdAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
