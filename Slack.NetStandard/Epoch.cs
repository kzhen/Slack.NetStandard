﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Slack.NetStandard
{
    public static class Epoch
    {
        public static DateTime From(long timestamp)
        {
            return Base.AddSeconds(timestamp);
        }

        public static long For(DateTime datetime)
        {
            return (long)datetime.Subtract(Base).TotalSeconds;
        }

        public static bool Within(long epoch, TimeSpan duration)
        {
            return Current - epoch <= duration.TotalSeconds;
        }

        public static long Current => (long)DateTime.UtcNow.Subtract(Base).TotalSeconds;
        private static readonly DateTime Base = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
    }
}
