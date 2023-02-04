using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepositiory : IProductReopsitory
    {
        private readonly StoreContext _context;
        public ProductRepositiory(StoreContext context)
        {
            _context=context;
        }
        public async Task<IReadOnlyList<Product>> GetProductAsync()=>await _context.Products.Include(x=>x.ProductType).Include(x=>x.ProductBrand).ToListAsync();

        public async Task<Product> GetProductByIdAsync(int id) => await _context.Products.Include(x=>x.ProductType).Include(x=>x.ProductBrand).FirstOrDefaultAsync(x=>x.Id==id);


        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()=>await _context.ProductBrands.ToListAsync();

        public async Task<ProductBrand> GetProductBrandByIdAsync(int id)=>await _context.ProductBrands.FindAsync(id);


        public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()=>await _context.ProductTypes.ToListAsync();

        public async Task<ProductType> GetProductTypeByIdAsync(int id)=>await _context.ProductTypes.FindAsync(id);
    }
}