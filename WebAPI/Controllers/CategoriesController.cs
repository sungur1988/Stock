using AutoMapper;
using Business.Abstract;
using Core.Extensions;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;
        IMapper _mapper;
        public CategoriesController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryAddDto categoryAddDto)
        {
            var categoryToAdd = _mapper.Map<Category>(categoryAddDto);
            categoryToAdd.CreatedDate = DateTime.Now;
            categoryToAdd.CreatedUserId = Convert.ToInt32(User.FindNameIdentifierClaim());
            var result = _categoryService.Add(categoryToAdd);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
        [HttpPut]
        public IActionResult UpdateCategory(CategoryUpdateDto categoryUpdateDto)
        {
            var check = _categoryService.GetCategoryById(categoryUpdateDto.Id);
            if (!check.Success)
            {
                return BadRequest(check.Message);
            }
            var categoryToAdd = check.Data;
            categoryToAdd.CategoryName = categoryUpdateDto.CategoryName;
            var result = _categoryService.Update(categoryToAdd);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);

        }
        [HttpDelete]
        public IActionResult DeleteCategory(int categoryId)
        {
            var check = _categoryService.GetCategoryById(categoryId);
            int userId = Convert.ToInt32(User.FindNameIdentifierClaim());
            if (!check.Success)
            {
                return BadRequest(check.Message);
            }
            var result = _categoryService.Delete(check.Data,userId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            int userId = Convert.ToInt32(User.FindNameIdentifierClaim());
            var result = _categoryService.GetList(userId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
    }  
}
