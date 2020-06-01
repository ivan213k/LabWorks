using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LR_4_Variant_1
{
    delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);
    class StudentCollection
    {
        private List<Student> _students = new List<Student>();

        public string CollectionName { get; set; } = "Студенти";

        public bool Remove(int j)
        {
            if (j<0||j>_students.Count-1)
            {
                return false;
            }
            StudentCountChanged?.Invoke(_students[j],new StudentListHandlerEventArgs(CollectionName,"Елемент видалено",_students[j]));
            _students.RemoveAt(j);
            return true;
        }

        public Student this[int i]
        {
            get { return _students[i];}
            set
            {
                _students[i] = value;
                StudentReferenceChanged?.Invoke(value,new StudentListHandlerEventArgs(CollectionName,"Елемент змінено",value));
            }
        }

        public event StudentListHandler StudentCountChanged;

        public event StudentListHandler StudentReferenceChanged;
        public void AddDefaults(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var student = new Student(new Person($"John {i}", "Nir", new DateTime(2000, 05, 15)),
                    Education.SecondEducation, 220);
                _students.Add(student);
                StudentCountChanged?.Invoke(student,new StudentListHandlerEventArgs(CollectionName,"Додано елемент",student));
            }
        }

        public void AddStudents(params Student[] students)
        {
            foreach (var student in students)
            {
                _students.Add(student);
                StudentCountChanged?.Invoke(student,new StudentListHandlerEventArgs(CollectionName,"Додано новий елемент",student));
            }
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
