using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LR_1_Variant_1
{
    class Student
    {
        private Person _person;

        private Education _education;

        private int _groupId;

        private List<Exam> _exams = new List<Exam>();

        public Student(Person person, Education education, int groupId)
        {
            _person = person;
            _education = education; 
            _groupId = groupId;
        }

        public Student()
        {

        }

        public Person Person { get => _person; set { _person = value; } }

        public Education EducationForm { get => _education; set { _education = value; } }

        public int GroupId { get => _groupId; set { _groupId = value; } }

        public List<Exam> Exams { get => _exams; set { _exams = value; } }

        public double AvverageMark
        {
            get
            {
                if (Exams == null || Exams.Count == 0)
                {
                    return 0;
                }
                return Exams.Select(m => m.Mark).Average();
            }
        }
        public bool this[Education education]
        {
            get
            {
                return this._education == education;
            }
        }

        public void AddExams(params Exam[] exams)
        {
            foreach (var exam in exams)
            {
                Exams.Add(exam);
            }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder($"{_person.Name} \t Група {_groupId} {_education.ToString()}");
            foreach (var exam in _exams)
            {
                text.Append($"\n {exam.SubjectName}");
            }
            return text.ToString();
        }

        public string ToShortString()
        {
            string text = $"{_person.Name} \t Група {_groupId} {_education.ToString()} \tСередній бал {AvverageMark}";

            return text;
        }
    }
}
