using System;
using System.Collections.Generic;
using System.Text;

namespace LR_4_Variant_1
{
    class Test
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
    }
}
