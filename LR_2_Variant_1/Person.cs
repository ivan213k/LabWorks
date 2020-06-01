using System;

namespace LR_2_Variant_1
{
    class Person : IDateAndCopy
    {
        protected string _name;

        protected string _surName;

        protected DateTime _birthDate;

        public Person(string name, string surName, DateTime birthDate)
        {
            _name = name;
            _surName = surName;
            BirthDate = birthDate;
        }

        public Person()
        {
            _name = "Name";
            _surName = "SurName";
            BirthDate = new DateTime(2000, 08, 13);
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }

        public string SurName
        {
            get => _surName;
            set
            {
                _surName = value;
            }
        }
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
            }
        }

        public int BirthYear
        {
            get => _birthDate.Year;
            set
            {
                _birthDate.AddYears(-_birthDate.Year).AddYears(value);
            }
        }

        public override bool Equals(object obj)
        {
            var person = obj as Person;
            return person.BirthDate == BirthDate &&
                   person.Name.Equals(Name) &&
                   person.SurName.Equals(SurName);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_name, _surName, _birthDate);
        }

        public static bool operator ==(Person left, Person right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{SurName} {Name} Рiк народження: {BirthYear}";
        }

        public virtual string ToShortString()
        {
            return $"{Name} {SurName}";
        }

        public object DeepCopy()
        {
            return  new Person(Name,SurName,BirthDate);
        }

        public DateTime Date { get; set; }
    }
}
