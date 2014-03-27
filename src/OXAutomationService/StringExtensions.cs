using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OXAutomation
{
    public static class StringExtensions
    {
        public static bool TryParseMsg(this string s, out uint value)
        {
            var field = typeof(Messages).GetFields(BindingFlags.Static | BindingFlags.Public).FirstOrDefault(o => string.Equals(o.Name, s, StringComparison.OrdinalIgnoreCase));

            if (field != null)
            {
                value = (uint)field.GetValue(null);
                return true;
            }
            else if (TryParseUInt(s, out value))
            {
                return true;
            }
            return false;
        }

        public static bool TryParseInt(this string s, out int value)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                value = 0;
                return true;
            }
            else if (!int.TryParse(s, out value) && !int.TryParse(s.TrimStart(new [] { '0', 'x', 'X' } ), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out value))
            {
                return false;
            }

            return true;
        }

        public static bool TryParseUInt(this string s, out uint value)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                value = 0;
                return true;
            }
            else if (!uint.TryParse(s, out value) && !uint.TryParse(s.TrimStart(new[] { '0', 'x', 'X' }), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out value))
            {
                return false;
            }

            return true;
        }

        public static bool TryParseLong(this string s, out long value)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                value = 0L;
                return true;
            }
            else if (!long.TryParse(s, out value) && !long.TryParse(s.TrimStart(new[] { '0', 'x', 'X' }), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out value))
            {
                return false;
            }

            return true;
        }
    }
}
