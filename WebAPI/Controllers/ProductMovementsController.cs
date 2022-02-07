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
    public class ProductMovementsController : ControllerBase
    {
        IProductMovementService _productMovementService;
        IMapper _mapper;
        public ProductMovementsController(IProductMovementService productMovementService,IMapper mapper)
        {
            _productMovementService = productMovementService;
            _mapper = mapper;
        }

        [HttpPost("addstock")]
        public IActionResult AddStock(ProductMovementAddDto productMovementAddDto)
        {
            var movementToAdd = _mapper.Map<ProductMovement>(productMovementAddDto);
            movementToAdd.CreatedDate = DateTime.Now;
            movementToAdd.CreatedUserId = Convert.ToInt32(User.FindNameIdentifierClaim());
            movementToAdd.MovementTypeId = "+";
            var result = _productMovementService.Add(movementToAdd);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
        [HttpPost("deletestock")]
        public IActionResult DeleteStock(ProductMovementAddDto productMovementAddDto)
        {
            var movementToAdd = _mapper.Map<ProductMovement>(productMovementAddDto);
            movementToAdd.CreatedDate = DateTime.Now;
            movementToAdd.CreatedUserId = Convert.ToInt32(User.FindNameIdentifierClaim());
            movementToAdd.MovementTypeId = "-";
            var result = _productMovementService.Add(movementToAdd);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
        [HttpGet("stocks")]
        public IActionResult GetStockTotals()
        {
            var result = _productMovementService.GetStockTotals();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
        [HttpGet("getlist")]
        public IActionResult GetList(int? productId)
        {
            IDataResult<IEnumerable<ProductMovement>> result;
            var userId = Convert.ToInt32(User.FindNameIdentifierClaim());
            if (productId ==null)
            {
                result = _productMovementService.GetList(userId);
            }
            else
            {
                result = _productMovementService.GetListByProductId(userId, productId.Value);
            }

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
    }
}
