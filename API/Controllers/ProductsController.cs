using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly IProductReopsitory _repo;
        public ProductsController(IProductReopsitory repo)
        {
            _repo=repo;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            var product=await _repo.GetProductAsync();

            return Ok(product);

        }

        

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id) => await _repo.GetProductByIdAsync(id);

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrandAsync() =>  Ok(await _repo.GetProductBrandAsync());

        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypesAsync() =>  Ok(await _repo.GetProductTypeAsync());
        
    }
}