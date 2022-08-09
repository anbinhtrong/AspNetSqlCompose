using DockerizeMultiProject.Infrastructure.Models;

namespace DockerizeMultiProject.Infrastructure
{
    public interface IStudentRepository
    {
        StudentModel Get(int studentId);
        List<StudentModel> GetAll();
    }
}