using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LR_3_Variant_1
{
    class StudentColection
    {
        private List<Student> _students = new List<Student>();

        public void AddDefaults(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _students.Add(new Student(new Person($"John {i}","Nir",new DateTime(2000,05,15)), Education.SecondEducation,220));
            }
        }

        public void AddStudents(params Student[] students)
        {
            _students.AddRange(students);
        }

        public override string ToString()
        {
            StringBuilder students = new StringBuilder();
            foreach (var student in _students)
            {
                students.Append(student.ToString() + "\n\n");
            }
            return students.ToString();
        }

        public string ToShortString()
        {
            StringBuilder students = new StringBuilder();
            foreach (var student in _students)
            {
                students.Append($"{student.Person}\t Середнiй бал: {student.AvverageMark} " +
                                $"Залiкiв: {student.Credits.Count} Iспитiв: {student.Exams.Count}\n");
            }

            return students.ToString();
        }

        public List<Student> SortBySurname()
        {
            _students.Sort();
            return _students;
        }
        public List<Student> SortByBirthDay()
        {
            _students.Sort(new Person() as IComparer<Person>);
            return _students;
        }
        public List<Student> SortByAvverageMark()
        {
            _students.Sort(new StudentComparer());
            return _students;
        }

        public Double GetMaxAvverageMark
        {
            get
            {
                if (_students.Count == 0)
                {
                    return 0;
                }

                return _students.Max(r => r.AvverageMark);
            }
        }

        public IEnumerable<Student> MasterStudents
        {
            get { return _students.Where(r => r.EducationForm == Education.Master); }
        }

        public List<Student> GetStudentWithAvverageMark(double avverageMark)
        {
            return _students.Where(r => r.AvverageMark == avverageMark).ToList();
        }
    }
}
