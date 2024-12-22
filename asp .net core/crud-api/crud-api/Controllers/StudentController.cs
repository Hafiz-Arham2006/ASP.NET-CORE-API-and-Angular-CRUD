using crud_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private ApiCrudContext _context;
        public StudentController(ApiCrudContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetData()
        {
           var data=await _context.Students.ToListAsync()
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<Student>> AddData([FromForm]Student std)
        {
            await _context.Students.AddAsync(std);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
            public async Task<ActionResult<Student>> DeleteData(int id) {
            var data =await _context.Students.FindAsync(id);
                    _context.Students.Remove(data);
            _context.SaveChanges();
            return Ok();
                }
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateData([FromForm]Student std, int id)
        {
              _context.Entry(std).State=EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> EditData(int id)
        {
           var data= await _context.Students.FindAsync(id);
           return Ok(data);
        }
    }
}
