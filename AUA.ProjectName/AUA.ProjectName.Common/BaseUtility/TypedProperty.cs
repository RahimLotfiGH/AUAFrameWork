using System;
using System.ComponentModel;

namespace AUA.ProjectName.Common.BaseUtility
{
    public static class GenericConverter
    {
        public static T ChangeType<T>(object value)
        {
            if (value == null) return default;

            return (T)ChangeType(typeof(T), value);
        }

        public static object ChangeType(Type t, object value)
        {
           
            var tc = TypeDescriptor.GetConverter(t);
            return tc.ConvertFrom(value);
        }

        public static void RegisterTypeConverter<T, TC>() where TC : TypeConverter
        {

            TypeDescriptor.AddAttributes(typeof(T), new TypeConverterAttribute(typeof(TC)));
        }
    }
}
