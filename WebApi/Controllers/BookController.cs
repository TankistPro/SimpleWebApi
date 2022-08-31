using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Context;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        public readonly DataBaseContext _context;
        public BookController(DataBaseContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<List<Book>> Get()
        {
            return await _context.Books.ToListAsync();
        }
    }
}
