using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section_10_1._14
{
    class Student
    {
        public string Name { get; set; }
        public string ClassSection { get; set; }
    }

    // Teacher class
    class Teacher
    {
        public string Name { get; set; }
        public string ClassSection { get; set; }
    }

    // Subject class
    class Subject
    {
        public string Name { get; set; }
        public string SubjectCode { get; set; }
        public Teacher Teacher { get; set; }
    }

    // Data storage singleton
    class SchoolDataStorage
    {
        private static SchoolDataStorage _instance;
        public List<Student> Students { get; }
        public List<Teacher> Teachers { get; }
        public List<Subject> Subjects { get; }

        private SchoolDataStorage()
        {
            Students = new List<Student>();
            Teachers = new List<Teacher>();
            Subjects = new List<Subject>();
        }

        public static SchoolDataStorage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SchoolDataStorage();
                }
                return _instance;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SchoolDataStorage dataStorage = SchoolDataStorage.Instance;

            // Filling up the lists with data
            FillData(dataStorage);

            // Display students in a class
            DisplayStudentsInClass(dataStorage, "10A");

            // Display subjects taught by a teacher
            DisplaySubjectsTaughtByTeacher(dataStorage, "John Doe");

            Console.ReadLine();
        }

        static void FillData(SchoolDataStorage dataStorage)
        {
            dataStorage.Students.Add(new Student { Name = "Alice", ClassSection = "10A" });
            dataStorage.Students.Add(new Student { Name = "Bob", ClassSection = "10B" });

            dataStorage.Teachers.Add(new Teacher { Name = "John Doe", ClassSection = "10A" });

            dataStorage.Subjects.Add(new Subject { Name = "Math", SubjectCode = "MATH101", Teacher = dataStorage.Teachers[0] });
            dataStorage.Subjects.Add(new Subject { Name = "Science", SubjectCode = "SCI101", Teacher = dataStorage.Teachers[0] });
        }

        static void DisplayStudentsInClass(SchoolDataStorage dataStorage, string classSection)
        {
            var studentsInClass = dataStorage.Students.Where(s => s.ClassSection == classSection);
            Console.WriteLine($"Students in class {classSection}:");
            foreach (var student in studentsInClass)
            {
                Console.WriteLine(student.Name);
            }
        }

        static void DisplaySubjectsTaughtByTeacher(SchoolDataStorage dataStorage, string teacherName)
        {
            var teacher = dataStorage.Teachers.FirstOrDefault(t => t.Name == teacherName);
            if (teacher != null)
            {
                var subjectsTaught = dataStorage.Subjects.Where(s => s.Teacher == teacher);
                Console.WriteLine($"{teacherName} teaches the following subjects:");
                foreach (var subject in subjectsTaught)
                {
                    Console.WriteLine(subject.Name);
                }
            }
            else
            {
                Console.WriteLine($"{teacherName} not found.");
            }
        }

    }
}
