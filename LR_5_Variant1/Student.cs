using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace LR_5_Variant1
{
    [Serializable]
    class Student : Person
    {
        private Education _education;

        private int _groupId;

        private List<Test> _credits = new List<Test>();

        private List<Exam> _exams = new List<Exam>();

        public Student(Person person, Education education, int groupId)
        {
            _name = person.Name;
            _surName = person.SurName;
            _birthDate = person.BirthDate;
            _education = education;
            _groupId = groupId;
        }

        public Student()
        {

        }

        public Person Person
        {
            get { return this as Person; }
            set
            {
                _name = value.Name;
                _surName = value.SurName;
                _birthDate = value.BirthDate;
            }
        }
        public Education EducationForm { get => _education; set { _education = value; } }

        public int GroupId
        {
            get => _groupId;
            set
            {
                if (value <= 100 || value > 699)
                {
                    throw new ArgumentException("Value should be less than 699 and more than 100");

                }
                _groupId = value;
            }
        }

        public List<Exam> Exams { get => _exams; set { _exams = value; } }

        public List<Test> Credits
        {
            get => _credits;
            set { _credits = value; }
        }

        public double AvverageMark
        {
            get
            {
                if (Exams == null || Exams.Count == 0)
                {
                    return 0;
                }

                double sum = 0;
                foreach (Exam exam in Exams)
                {
                    sum += exam.Mark;
                }

                return sum / Exams.Count;
            }
        }

        public DateTime Date { get; set; }

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
        public void AddCredit(params Test[] credits)
        {
            foreach (var test in credits)
            {
                Credits.Add(test);
            }
        }
        

        public override string ToString()
        {
            StringBuilder text = new StringBuilder($"{_name} {_surName} - {BirthDate.ToShortDateString()} \t Група {_groupId} {_education.ToString()}");
            text.Append("\nIспити: ");
            foreach (Exam exam in _exams)
            {
                text.Append($"\n {exam}");
            }
            text.Append("\nЗалiки: ");
            foreach (Test credit in _credits)
            {
                text.Append(credit + "\t");
            }

            text.Append($"\nСереднiй бал: {AvverageMark}\n");
            return text.ToString();
        }

        public string ToShortString()
        {
            string text = $"{_name} \t Група {_groupId} {_education.ToString()} \tСередній бал {AvverageMark}";

            return text;
        }

        public override bool Equals(object obj)
        {
            var student = obj as Student;
            return _name.Equals(student.Name) &&
                   _surName.Equals(student.SurName) &&
                   _birthDate.Equals(student.BirthDate) &&
                   AvverageMark.Equals(student.AvverageMark) &&
                   EducationForm == student.EducationForm &&
                   GroupId == student.GroupId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_name, _surName, _birthDate, (int)_education, _groupId);
        }
        public static bool operator ==(Student left, Student right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Student left, Student right)
        {
            return !Equals(left, right);
        }

        public Student DeepCopy()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;

                return (Student)formatter.Deserialize(ms);
            }
        }
        public bool Save(string fileName)
        {
            try
            {
                using (FileStream fs = File.Open(fileName, FileMode.OpenOrCreate))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(fs, this);
                    return (formatter.Deserialize(fs) as Student) != null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }
        public static bool Save(string fileName, Student student)
        {
            try
            {
                using (FileStream fs = File.Open(fileName, FileMode.OpenOrCreate))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(fs, student);
                    return (formatter.Deserialize(fs) as Student) != null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        public bool Load(string fileName)
        {
            try
            {
                using (FileStream fs = File.Open(fileName, FileMode.Open))
                {
                    var formatter = new BinaryFormatter();
                    var deserializedStudent = (Student)formatter.Deserialize(fs);
                    SurName = deserializedStudent.SurName;
                    Name = deserializedStudent.Name;
                    BirthDate = deserializedStudent.BirthDate;
                    EducationForm = deserializedStudent.EducationForm;
                    GroupId = deserializedStudent.GroupId;
                    Person = deserializedStudent.Person;
                    Exams = deserializedStudent.Exams;
                    Credits = deserializedStudent.Credits;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
           
        }
        public static bool Load(string fileName, Student student)
        {
            try
            {
                using (FileStream fs = File.Open(fileName, FileMode.Open))
                {
                    var formatter = new BinaryFormatter();
                    var deserializedStudent = (Student)formatter.Deserialize(fs);
                    student = deserializedStudent;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        public bool AddExamFromConsole()
        {
            Console.WriteLine("Введiть назву предмету, оцiнку та дату iспиту одним рядком, роздiлюючи їх комою");
            Console.WriteLine("Наприклад: Math,5,10.10.2020");
            string input = Console.ReadLine();
            try
            {
                var strs = input.Split(",");
                int mark = int.Parse(strs[1]);
                DateTime date = DateTime.Parse(strs[2]);
                AddExams(new Exam(strs[0],mark,date));
                Console.WriteLine("Предмет додано успiшно");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Не вдалось зчитати iнформацiю, спробуйте ще раз");
                return false;
            }
        }
    }
}

