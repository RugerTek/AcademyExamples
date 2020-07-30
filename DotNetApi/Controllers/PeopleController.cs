using System.Linq;
using System.Threading.Tasks;
using DotNetApi.Contracts;
using DotNetApi.Data;
using DotNetApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DotNetApi.Controllers
{
    [ApiController, Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        private readonly PeopleContext _context;

        public PeopleController(ILogger<PeopleController> logger, PeopleContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageIndex = 0, int pageSize = 20)
        {
            var people = await _context.Person
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var count = _context.Person.Count();
            var response = new PaginatedResponse<Person>
            {
                Items = people,
                Count = count
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePersonRequest request)
        {
            var person = new Person
            {
                Name = request.Name,
                Age = request.Age
            };

            _context.Add(person);
            await _context.SaveChangesAsync();

            return StatusCode(201, person);
        }
    }
}