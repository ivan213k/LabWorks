
namespace LR_4_Variant_1
{
    class JournalEntry
    {
        public string CollectionName { get; set; }

        public string ChangedTypeInfo { get; set; }

        public string DataInfo { get; set; }

        public JournalEntry(string collectionName, string changedTypeInfo, string dataInfo)
        {
            CollectionName = collectionName;
            ChangedTypeInfo = changedTypeInfo;
            DataInfo = dataInfo;
        }

        public override string ToString()
        {
            return $"{CollectionName}->{ChangedTypeInfo}->{DataInfo}";
        }
    }
}
