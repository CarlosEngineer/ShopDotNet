using Microsoft.EntityFrameworkCore;
using ShoppingNet.API.Context;
using ShoppingNet.API.Models;

namespace ShoppingNet.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            _context.SaveChanges();

            return product;
        }

        public async Task<Product> Delete(int id)
        {
            var product = await GetById(id);
            if (product == null)
            {
                throw new Exception();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _context.Products.Where(c => c.Id == id).FirstOrDefaultAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
