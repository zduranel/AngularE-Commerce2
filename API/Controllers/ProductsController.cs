﻿using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

using System.Threading.Tasks;


namespace API.Controllers
{
    //https:localhost:5001/api/Products/GetProducts
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        //private readonly StoreContext _context;
        //private readonly IProductRepository _productRepository;

        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;

        public ProductsController(IGenericRepository<Product> productRepository,
            IGenericRepository<ProductBrand> productBrandRepository,
            IGenericRepository<ProductType> productTypeRepository)
            
        {
            // _context = context;
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
        }


        [HttpGet] //http verbs -> GET POST DELETE PUT vs..
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var spec = new ProductsWithProductTypeAndBrandsSpecification();
            var data = await _productRepository.ListAsync(spec);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productRepository.GetByIdAsync(id);

        }


        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands(int id)
        {
            return Ok(await _productBrandRepository.ListAllAsync());

        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes(int id)
        {
            return Ok(await _productTypeRepository.ListAllAsync());

        }









    }
}
