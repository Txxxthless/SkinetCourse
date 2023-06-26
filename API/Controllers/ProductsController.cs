using API.Controllers;
using API.DTOs;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;

        public ProductsController(
            IGenericRepository<Product> productsRepository,
            IGenericRepository<ProductBrand> productBrandRepository,
            IGenericRepository<ProductType> productTypeRepository,
            IMapper mapper
        )
        {
            _productBrandRepository = productBrandRepository;
            _productsRepository = productsRepository;
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        [Cached(600)]
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDTO>>> GetProducts(
            [FromQuery] ProductSpecParams productParams
        )
        {
            var specification = new ProductsWithTypesAndBrandsSpecifiaction(productParams);
            var countSpecifaction = new ProductWithFiltersForCountSpecification(productParams);
            var totalItems = await _productsRepository.CountAsync(countSpecifaction);
            var products = await _productsRepository.ListAsync(specification);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(
                products
            );

            return Ok(
                new Pagination<ProductToReturnDTO>(
                    productParams.PageIndex,
                    productParams.PageSize,
                    totalItems,
                    data
                )
            );
        }

        [Cached(600)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var specification = new ProductsWithTypesAndBrandsSpecifiaction(id);
            var product = await _productsRepository.GetEntityWithSpecification(specification);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Product, ProductToReturnDTO>(product));
        }

        [Cached(600)]
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var productBrands = await _productBrandRepository.ListAllAsync();
            return Ok(productBrands);
        }

        [Cached(600)]
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var productBrands = await _productTypeRepository.ListAllAsync();
            return Ok(productBrands);
        }
    }
}
