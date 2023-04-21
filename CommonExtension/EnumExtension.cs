using System;
using System.Collections.Generic;

namespace CommonExtension
{
    public static class EnumExtension
    {
        public static List<EnumValue> GetValues<T>()
        {
            var values = new List<EnumValue>();
            foreach(var itemType in Enum.GetValues(typeof(T)))
            {
                values.Add(new EnumValue
                {
                    Name = Enum.GetName(typeof(T), itemType),
                    Value = (int)itemType
                });
            }
            return values;
        }
    }
}
