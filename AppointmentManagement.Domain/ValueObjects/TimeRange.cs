using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain.ValueObjects;

    public class TimeRange
    {
        public TimeSpan Start { get; }
        public TimeSpan End { get; }

        public TimeRange(TimeSpan start, TimeSpan end)
        {
            if (start >= end)
                throw new ArgumentException("Start time must be before end time.");

            Start = start;
            End = end;
        }

        public bool Overlaps(TimeRange other)
        {
            return Start < other.End && End > other.Start;
        }

        public bool Contains(TimeRange other)
        {
            return Start <= other.Start && End >= other.End;
        }
    }

