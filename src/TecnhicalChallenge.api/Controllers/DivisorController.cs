using System.Collections.Generic;
using Dtos;
using Entitys;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisorController : ControllerBase
    {
        private readonly IDivisorService _divisorService;

        public DivisorController(IDivisorService divisorService)
        {
            _divisorService = divisorService;
        }

        [HttpGet]
        public ActionResult<List<int>> Get(int number, bool prime)
        {
            DivisorEntity divisor = new DivisorEntity
            {
                Number = number,
                Prime = prime,
            };

            DivisorDto result = _divisorService.CalcDivisor(divisor);

            if (result.Ok)
            {
                return Ok(result.Divisors);
            }
            
            return BadRequest(result.Error);
        }
    }
}
