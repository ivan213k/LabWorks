using System;


namespace LR_4_Variant_1
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
            return $"{SubjectName}  Оцiнка - {Mark}\tДата iспиту - {DateOfExam.ToShortDateString()}";
        }

        public override bool Equals(object obj)
        {
            var exam = obj as Exam;
            return exam.Mark == Mark &&
                   exam.SubjectName == SubjectName &&
                   exam.DateOfExam.Equals(DateOfExam);

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SubjectName, Mark, DateOfExam);
        }

        public static bool operator ==(Exam left, Exam right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Exam left, Exam right)
        {
            return !Equals(left, right);
        }
    }
}
