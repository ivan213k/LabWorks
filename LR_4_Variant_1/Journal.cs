using System;
using System.Collections.Generic;
using System.Text;

namespace LR_4_Variant_1
{
    class Journal
    {
        private List<JournalEntry> journalEntries = new List<JournalEntry>();

       
        public void StudentCollection_StudentReferenceChanged(object source, StudentListHandlerEventArgs args)
        {
            journalEntries.Add(new JournalEntry(args.CollectionName,args.ChangesTypeInfo,args.Student.ToShortString()));
        }

        public void StudentCollection_StudentCountChanged(object source, StudentListHandlerEventArgs args)
        {
            journalEntries.Add(new JournalEntry(args.CollectionName, args.ChangesTypeInfo, args.Student.ToShortString()));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var entry in journalEntries)
            {
                sb.Append(entry.ToString() + "\n");
            }

            return sb.ToString();
        }
    }
}
