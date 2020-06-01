using System;

namespace LR_2_Variant_1
{
    interface IDateAndCopy
    {
        object DeepCopy();

        DateTime Date { get; set; }
    }
}
