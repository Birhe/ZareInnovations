using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZareInnovations.Data;

namespace ZareInnovations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentDepartmentsController : ControllerBase
    {
        private readonly ZareContext _context;

        public StudentDepartmentsController(ZareContext context)
        {
            _context = context;
        }

        // GET: api/StudentDepartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDepartment>>> GetStudentDepartments()
        {
            return await _context.StudentDepartments.Include(s => s.Student).ToListAsync();
        }

        // GET: api/StudentDepartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDepartment>> GetStudentDepartment(int id)
        {
            var studentDepartment = await _context.StudentDepartments.FindAsync(id);

            if (studentDepartment == null)
            {
                return NotFound();
            }

            return studentDepartment;
        }

        // PUT: api/StudentDepartments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentDepartment(int id, StudentDepartment studentDepartment)
        {
            if (id != studentDepartment.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentDepartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentDepartmentExists(id))
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

        // POST: api/StudentDepartments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentDepartment>> PostStudentDepartment(StudentDepartment studentDepartment)
        {
            _context.StudentDepartments.Add(studentDepartment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentDepartment", new { id = studentDepartment.Id }, studentDepartment);
        }

        // DELETE: api/StudentDepartments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentDepartment(int id)
        {
            var studentDepartment = await _context.StudentDepartments.FindAsync(id);
            if (studentDepartment == null)
            {
                return NotFound();
            }

            _context.StudentDepartments.Remove(studentDepartment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentDepartmentExists(int id)
        {
            return _context.StudentDepartments.Any(e => e.Id == id);
        }
    }
}
