using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee_Management.Data;
using Employee_Management.Model;

namespace Employee_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMgmtsController : ControllerBase
    {
        private readonly Employee_ManagementContext _context;

        public EmployeeMgmtsController(Employee_ManagementContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeMgmts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeMgmt>>> GetEmployeeMgmt()
        {
          if (_context.EmployeeMgmt == null)
          {
              return NotFound();
          }
            return await _context.EmployeeMgmt.ToListAsync();
        }

        // GET: api/EmployeeMgmts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeMgmt>> GetEmployeeMgmt(int id)
        {
          if (_context.EmployeeMgmt == null)
          {
              return NotFound();
          }
            var employeeMgmt = await _context.EmployeeMgmt.FindAsync(id);

            if (employeeMgmt == null)
            {
                return NotFound();
            }

            return employeeMgmt;
        }

        // PUT: api/EmployeeMgmts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeMgmt(int id, EmployeeMgmt employeeMgmt)
        {
            if (id != employeeMgmt.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(employeeMgmt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeMgmtExists(id))
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

        // POST: api/EmployeeMgmts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeMgmt>> PostEmployeeMgmt(EmployeeMgmt employeeMgmt)
        {
          if (_context.EmployeeMgmt == null)
          {
              return Problem("Entity set 'Employee_ManagementContext.EmployeeMgmt'  is null.");
          }
            _context.EmployeeMgmt.Add(employeeMgmt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeMgmt", new { id = employeeMgmt.EmpId }, employeeMgmt);
        }

        // DELETE: api/EmployeeMgmts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeMgmt(int id)
        {
            if (_context.EmployeeMgmt == null)
            {
                return NotFound();
            }
            var employeeMgmt = await _context.EmployeeMgmt.FindAsync(id);
            if (employeeMgmt == null)
            {
                return NotFound();
            }

            _context.EmployeeMgmt.Remove(employeeMgmt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeMgmtExists(int id)
        {
            return (_context.EmployeeMgmt?.Any(e => e.EmpId == id)).GetValueOrDefault();
        }
    }
}
