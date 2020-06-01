
using System;

namespace LR_2_Variant_1
{
    class Test : IDateAndCopy
    {
        public string SubjectName { get; set; }

        public bool IsCredited { get; set; }
        public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Test(string subjectName, bool isCredited)
        {
            SubjectName = subjectName;
            IsCredited = isCredited;
        }

        public Test()
        {
            SubjectName = "Subject";
            IsCredited = true;
        }

        public override string ToString()
        {
            var credited = IsCredited ? "Зараховано" : "НЕ зараховано";
            return $"{SubjectName} - {credited}";
        }

        public object DeepCopy()
        {
            return  new Test(SubjectName,IsCredited);
        }
    }
}
