using System;

namespace LR_1_Variant_1
{
    class Exam
    {
        public string SubjectName { get; set; }

        public int Mark { get; set; }

        public DateTime DateOfExam { get; set; }

        public Exam(string subjectName, int mark, DateTime dateOfExam)
        {
            SubjectName = subjectName;
            Mark = mark;
            DateOfExam = dateOfExam;
        }

        public Exam()
        {
            SubjectName = "Subject";
            Mark = 0;
            DateOfExam = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{SubjectName}  Оцінка - {Mark}\tДата іспиту - {DateOfExam.ToShortDateString()}";
        }
    }
}
