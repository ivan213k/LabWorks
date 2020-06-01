using System;

namespace LR_4_Variant_1
{
    class StudentListHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; }

        public string ChangesTypeInfo { get; set; }

        public Student Student { get; set; }

        public StudentListHandlerEventArgs(string collectionName, string changesTypeInfo, Student student)
        {
            CollectionName = collectionName;
            ChangesTypeInfo = changesTypeInfo;
            Student = student;
        }

        public override string ToString()
        {
            return $"{CollectionName} {ChangesTypeInfo} - {Student}";
        }
    }
}
