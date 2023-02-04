using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductReopsitory
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductAsync();

        Task<ProductBrand> GetProductBrandByIdAsync(int id);
        Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync();
        

        
        Task<ProductType> GetProductTypeByIdAsync(int id);
        Task<IReadOnlyList<ProductType>> GetProductTypeAsync();
        
    }
}