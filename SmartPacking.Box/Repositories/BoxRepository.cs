using Microsoft.EntityFrameworkCore;
using SmartPacking.Box.Data;
using SmartPacking.Box.Model;
using SmartPacking.Box.Repository.Interfaces;


namespace SmartPacking.Box.Repository
{
    public class BoxRepository : IBoxRepository
    {
        public BoxRepository(BoxContext smartPackingContext)
        {
            _context = smartPackingContext;
        }

        private readonly BoxContext _context;
        public async Task<List<BoxModel>> GetAllBoxsAsync()
        {
            return await _context.Boxs.ToListAsync();
        }
    }
}
