using ElasticSearchFootballerExample.Models;
using ElasticSearchFootballerExample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchFootballerExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;

        private IFootballerService _footballerService;

        public PlayerController(ILogger<PlayerController> logger, IFootballerService footballerService)

        {
            _footballerService = footballerService;
            _logger = logger;
        }

        [HttpPost()]
        public async Task<IActionResult> AddFootballer(Footballer footballer)
        {
            await _footballerService.SaveSingleAsync(footballer);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, Footballer footballer)
        {
            var existing = await _footballerService.GetProductById(id);

            if (existing != null)
            {
                await _footballerService.SaveSingleAsync(existing);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var existing = await _footballerService.GetProductById(id);

            if (existing != null)
            {
                await _footballerService.DeleteAsync(existing);
                return Ok();
            }

            return NotFound();
        }
    }
}
