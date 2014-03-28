using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OXAutomation
{
    public class TimeOfDay
    {
        private readonly TimeSpan _value;

        public TimeOfDay(TimeSpan value)
        {
            _value = value;
        }

        public DateTime Next(TimeSpan period)
        {
            DateTime next = DateTime.Today + _value, now = DateTime.Now;
            var timeout = (next - now).TotalMilliseconds;
            double offset = 0.0;

            if (TimeSpan.Zero.Equals(period))
            {
                next = next.AddDays(1);
            }
            else if (next < now)
            {
                offset = Math.Round((now - next).TotalSeconds / period.TotalSeconds);
            }
            else
            {
                offset = Math.Round((now - next).TotalSeconds / period.TotalSeconds);
            }

            next = next.AddSeconds(offset * period.TotalSeconds);
            
            return next;
        }

        public TimeSpan Value
        {
            get { return _value; }
        }

        public override string ToString()
        {
            return _value.ToString(@"hh\:mm\:ss");
        }

        public static TimeOfDay Parse(string value)
        {
            var tokens = value.Trim().Split(':');

            var values = new int[Math.Min(3, tokens.Length)];

            for (var i = 0; i < values.Length; i++)
            {
                int.TryParse(tokens[i], out values[i]);
            }

            var _timeOfDay = new TimeSpan();

            if (values.Length > 0)
            {
                _timeOfDay = TimeSpan.FromHours(values[0] % 24);
            }

            if (values.Length > 1)
            {
                _timeOfDay = _timeOfDay + TimeSpan.FromMinutes(values[1] % 60);
            }

            if (values.Length > 2)
            {
                _timeOfDay = _timeOfDay + TimeSpan.FromSeconds(values[2] % 60);
            }

            return new TimeOfDay(_timeOfDay);
        }

        public static implicit operator TimeOfDay(string value)
        {
            return Parse(value);
        }

        public static implicit operator TimeSpan(TimeOfDay time)
        {
            return time._value;
        }

        public static implicit operator DateTime(TimeOfDay time)
        {
            return DateTime.Today + time._value;
        }
    }
}
