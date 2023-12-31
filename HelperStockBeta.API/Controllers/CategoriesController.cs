﻿using HelperStockBeta.Application.DTOs;
using HelperStockBeta.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HelperStockBeta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();
            if (categories == null)
            {
                return NotFound("Categoria not found");
            }

            return Ok(categories);
        }

        [HttpGet("{id:int}", Name ="GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id) 
        {
            var category = await _categoryService.GetById(id);

            if (category == null)
            {
                return NotFound("Category not found");
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if(categoryDto == null)
            {
                return BadRequest("Invalid Body Data");
            }

            await _categoryService.Add(categoryDto);

            return new CreatedAtRouteResult("GetCategory" , new { id = categoryDto.Id }, categoryDto);
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if(id != categoryDto.Id)
            {
                return BadRequest("Id not verificated");
            }

            if(categoryDto == null)
            {
                return BadRequest("DTO inspec fail");
            }

            await _categoryService.Update(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = _categoryService.GetById(id);
            if(category == null)
            {
                return NotFound("The category delete not found");
            }

            await _categoryService.Remove(id);
            return Ok(category);
        }
    }
}
