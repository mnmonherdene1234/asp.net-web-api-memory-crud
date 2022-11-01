using Microsoft.AspNetCore.Mvc;
using EntityFrameworkTest.Models;
using System.Collections.Generic;

namespace EntityFrameworkTest.Controllers;

[ApiController]
[Route("student")]
public class StudentConroller : ControllerBase
{
    private readonly DataContext _context;
    public StudentConroller(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<Student> CreateStudent(Student student)
    {
        if (student == null) return null;

        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
        return student;
    }

    [HttpGet]
    public List<Student> GetStudents()
    {
        return _context.Students.ToList();
    }

    [HttpGet("{id}")]
    public async Task<Object> GetStudent(int id)
    {
        try
        {
            return _context.Students.First(x => x.Id == id);
        }
        catch (System.Exception)
        {
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    public async Task<Object> UpdateStudent(int id, [FromBody] Student student)
    {
        if (id != student.Id) return BadRequest();
        Student foundStudent = await _context.Students.FindAsync(id);
        if (foundStudent == null) return NotFound();

        foundStudent.Name = student.Name;
        foundStudent.Age = student.Age;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return NotFound();
        }

        return foundStudent;
    }

    [HttpDelete("{id}")]
    public async Task<Object> DeleteStudent(int id)
    {
        Student student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return student;
    }
}