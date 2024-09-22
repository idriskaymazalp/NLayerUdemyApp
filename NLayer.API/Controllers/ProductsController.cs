using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.core.Services;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using System.Collections.Generic;

namespace NLayer.API.Controllers
{
    
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _servise;

        public ProductsController(IMapper mapper, IProductService productService = null)
        {
            _mapper = mapper;
            _servise = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            //Check 1
            return CreateActionResult(CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, await _servise.GetProductsWithCategory()));
        }



        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _servise.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200,productsDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _servise.GetByIdAsync(id);
            var productsDtos = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _servise.AddAsync(_mapper.Map<Product>(productDto));
            var productsDtos = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _servise.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _servise.GetByIdAsync(id);
            await _servise.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
