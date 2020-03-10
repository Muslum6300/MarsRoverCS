using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverCS.Business.Helper
{
    public static class Utility
    {
        public static bool GetEnumValue<T>(char value) where T : struct
        {
            if (typeof(T).IsEnum)
            {
                var validValue = false;
                foreach (T enumValue in (T[])Enum.GetValues(typeof(T)))
                {
                    if (Convert.ToChar(enumValue).Equals(value))
                    {
                        validValue = true;
                        break;
                    }
                }
                return validValue;
            }
            return false;
        }
    }
}
