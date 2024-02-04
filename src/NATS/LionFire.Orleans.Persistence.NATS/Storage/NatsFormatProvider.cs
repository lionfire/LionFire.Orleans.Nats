using System;
using System.Globalization;

#if CLUSTERING_NATS
namespace LionFire.Orleans_.Clustering.NATS.Storage
#elif PERSISTENCE_NATS
namespace LionFire.Orleans_.Persistence.NATS.Storage
#elif REMINDERS_NATS
namespace LionFire.Orleans_.Reminders.NATS.Storage
#elif TESTER_SQLUTILS
namespace LionFire.Orleans_.Tests.SqlUtils
#else
// No default namespace intentionally to cause compile errors if something is not defined
#endif
{
    /// <summary>
    /// Formats .NET types appropriately for database consumption in non-parameterized queries.
    /// </summary>
    internal class NatsFormatProvider : IFormatProvider
    {
        private readonly NatsFormatter formatter = new NatsFormatter();

        /// <summary>
        /// Returns an instance of the formatter
        /// </summary>
        /// <param name="formatType">Requested format type</param>
        /// <returns></returns>
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? formatter : null;
        }


        private class NatsFormatter : ICustomFormatter
        {
            public string Format(string format, object arg, IFormatProvider formatProvider)
            {
                //This null check applies also to Nullable<T> when T does not have value defined.
                if (arg == null)
                {
                    return "NULL";
                }

                if (arg is string)
                {
                    return "N'" + ((string)arg).Replace("'", "''", StringComparison.Ordinal) + "'";
                }

                if (arg is DateTime)
                {
                    return "'" + ((DateTime)arg).ToString("O") + "'";
                }

                if (arg is DateTimeOffset)
                {
                    return "'" + ((DateTimeOffset)arg).ToString("O") + "'";
                }

                if (arg is IFormattable)
                {
                    return ((IFormattable)arg).ToString(format, CultureInfo.InvariantCulture);
                }

                return arg.ToString();
            }
        }
    }
}
