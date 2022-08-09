using DockerizeMultiProject.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerizeMultiProject.Infrastructure
{
    public class StudentRepository : IStudentRepository
    {
        public StudentModel Get(int studentId)
        {
            var student = ListStudent.Students.FirstOrDefault(t => t.Id == studentId);
            if(student == null) return null;
            return new StudentModel
            {
                Id = student.Id,
                Name = student.Name,
            };
        }

        public List<StudentModel> GetAll()
        {
            return ListStudent.Students.Select(t => new StudentModel
            {
                Id = t.Id,
                Name = t.Name
            }).ToList();
        }
    }
}
