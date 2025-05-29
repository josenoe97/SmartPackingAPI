using Microsoft.EntityFrameworkCore;
using SmartPacking.Data;
using SmartPacking.Model;
using SmartPacking.Repository.Interfaces;

namespace SmartPacking.Repository
{
    public class BoxRepository : IBoxRepository
    {
        public BoxRepository(SmartPackingContext smartPackingContext)
        {
            _context = smartPackingContext;
        }

        private readonly SmartPackingContext _context;
        public async Task<List<BoxModel>> GetAllBoxsAsync()
        {
            return await _context.Boxs.ToListAsync();
        }
    }
}
