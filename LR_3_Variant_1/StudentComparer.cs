using System.Collections.Generic;
namespace LR_3_Variant_1
{
    class StudentComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x.AvverageMark > y.AvverageMark)
                return 1;
            else if (x.AvverageMark < y.AvverageMark)
                return -1;
            else
                return 0;
        }
    }
}
