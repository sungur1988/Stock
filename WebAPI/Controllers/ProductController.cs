using AutoMapper;
using Business.Abstract;
using Core.Extensions;
using Core.Utilities.Results;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        IMapper _mapper;
        public ProductsController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AddProduct(ProductAddDto productAddDto)
        {
            var productToAdd = _mapper.Map<Product>(productAddDto);
            productToAdd.CreatedDate = DateTime.Now;
            productToAdd.CreatedUserId = Convert.ToInt32(User.FindNameIdentifierClaim());
            var result = _productService.Add(productToAdd);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpPut]
        public IActionResult UpdateProduct(ProductUpdateDto productUpdateDto)
        {
            var check = _productService.GetProductById(productUpdateDto.Id);
            if (!check.Success)
            {
                return BadRequest(check.Message);
            }
            var productToAdd = check.Data;
            productToAdd.ProductName = productUpdateDto.ProductName;
            var result = _productService.Update(productToAdd);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
        [HttpGet]
        public IActionResult GetList(int? categoryId)
        {
            int userId = Convert.ToInt32(User.FindNameIdentifierClaim());
            IDataResult<IEnumerable<Product>> data;
            if (categoryId==null)
            {
                data = _productService.GetList(userId);
            }
            else
            {
                data = _productService.GetListByCategoryId(userId,categoryId.Value);
            }
            if (!data.Success)
            {
                return BadRequest(data.Message);
            }
            return Ok(data.Data);
        }
        [HttpDelete]
        public IActionResult Delete(int productId)
        {
            var check = _productService.GetProductById(productId);
            int userId = Convert.ToInt32(User.FindNameIdentifierClaim());
            if (!check.Success)
            {
                return BadRequest(check.Message);
            }
            var result = _productService.Delete(check.Data, userId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
    }
}
