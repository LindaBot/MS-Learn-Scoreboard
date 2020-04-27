using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MS_Learn_Scoreboard.Data;
using MS_Learn_Scoreboard.Models;

namespace MS_Learn_Scoreboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly MS_Learn_ScoreboardContext _context;

        public StudentsController(MS_Learn_ScoreboardContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        {
            return await _context.Student.OrderByDescending(s => s.Score).ToListAsync();
        }

        // GET: api/Students/top/{topNum}
        [HttpGet("top/{topNum}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetTopStudent(int topNum)
        {
            return await _context.Student.OrderByDescending(s => s.Score).Take(topNum).ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // POST: api/Students
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(NewStudent student)
        {
            if (StudentExists(student.Username)) 
            {
                return BadRequest("Student already exists in the database");
            }

            try
            {
                Student newStudent = new Student
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    School = student.School,
                    Username = student.Username,
                    Email = student.Email,
                    CreateDate = DateTime.Now,
                    Score = MicrosoftLearnUtil.GetXP(student.Username)
                };

                _context.Student.Add(newStudent);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetStudent", new { id = newStudent.Id }, newStudent);
            }
            catch (WebException) 
            {
                return BadRequest("Unable to find user, please check the username");
            }

            
        }

        [HttpGet("updateAll")]
        public async void UpdateStudent()
        {
            List<Student> students = await _context.Student.ToListAsync();
            foreach (Student student in students) 
            {
                student.Score = MicrosoftLearnUtil.GetXP(student.Username);
            }
            await _context.SaveChangesAsync();
        }

        private bool StudentExists(string studentUsername)
        {
            return _context.Student.Any(e => e.Username == studentUsername);
        }
    }
}
