using System;

namespace AUA.ProjectName.Common.Extensions
{
    public class Enum<T> where T : struct, IConvertible
    {

        public static bool IsExistValue(int value)
        {
            return Enum.IsDefined(typeof(T), value);
        }

    }
}