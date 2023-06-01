using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models.DTO_s;
using Backend.Services;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCartDto>> GetShoppingCart(int id)
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCartByIdAsync(id);

            if (shoppingCart == null)
            {
                return NotFound();
            }

            return shoppingCart;
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCartDto>> CreateShoppingCart(ShoppingCartDto shoppingCartDto)
        {
            await _shoppingCartService.CreateShoppingCartAsync(shoppingCartDto);

            return CreatedAtAction(nameof(GetShoppingCart), new { id = shoppingCartDto.Id }, shoppingCartDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShoppingCart(int id, ShoppingCartDto shoppingCartDto)
        {
            if (id != shoppingCartDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _shoppingCartService.UpdateShoppingCartAsync(shoppingCartDto);
            }
            catch (Exception)
            {
                if (!await _shoppingCartService.ShoppingCartExistsAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingCart(int id)
        {
            if (!await _shoppingCartService.ShoppingCartExistsAsync(id))
            {
                return NotFound();
            }

            await _shoppingCartService.DeleteShoppingCartAsync(id);

            return NoContent();
        }

        [HttpGet("{id}/items")]
        public async Task<ActionResult<IEnumerable<ShoppingCartItemDto>>> GetShoppingCartItems(int id)
        {
            var items = await _shoppingCartService.GetShoppingCartItemsAsync(id);

            return Ok(items);
        }

        [HttpPost("{id}/items")]
        public async Task<ActionResult<ShoppingCartItemDto>> CreateShoppingCartItem(int id, ShoppingCartItemDto itemDto)
        {
            if (id != itemDto.ShoppingCartId)
            {
                return BadRequest();
            }

            await _shoppingCartService.CreateShoppingCartItemAsync(itemDto);

            return CreatedAtAction(nameof(GetShoppingCartItem), new { id = itemDto.Id }, itemDto);
        }

        [HttpGet("{id}/items/{itemId}")]
        public async Task<ActionResult<ShoppingCartItemDto>> GetShoppingCartItem(int id, int itemId)
        {
            var item = await _shoppingCartService.GetShoppingCartItemByIdAsync(itemId);

            if (item == null || item.ShoppingCartId != id)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPut("{id}/items/{itemId}")]
        public async Task<IActionResult> UpdateShoppingCartItem(int id, int itemId, ShoppingCartItemDto itemDto)
        {
            if (itemId != itemDto.Id || id != itemDto.ShoppingCartId)
            {
                return BadRequest();
            }

            try
            {
                await _shoppingCartService.UpdateShoppingCartItemAsync(itemDto);
            }
            catch (Exception)
            {
                if (!await _shoppingCartService.ShoppingCartItemExistsAsync(itemId))
                {
                    return NotFound();
                }

            }
        }
    }
}

