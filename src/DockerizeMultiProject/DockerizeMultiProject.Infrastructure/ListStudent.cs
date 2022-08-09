using DockerizeMultiProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerizeMultiProject.Infrastructure
{
    public class ListStudent
    {
        public static List<Student> Students = new List<Student>
        {
            new Student { Id = 1, Name = "An Binh Trong" },
            new Student { Id = 2, Name = "Vuong Kiet" },
            new Student { Id = 3, Name = "Mai Diem Phuong" },
            new Student { Id = 4, Name = "Luong Tinh Ky" },
        };
    }
}
