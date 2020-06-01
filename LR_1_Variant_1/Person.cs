using System;
namespace LR_1_Variant_1
{
    class Person
    {
        private string _name;

        private string _surName;

        private DateTime _birthDate;

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

        public override string ToString()
        {
            return $"{SurName} {Name} Рiк народження: {BirthYear}";
        }

        public virtual string ToShortString()
        {
            return $"{Name} {SurName}";
        }
    }
}
