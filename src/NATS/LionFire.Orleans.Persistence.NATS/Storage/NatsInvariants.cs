// TODO TRIAGE - not needed?:
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
    /// A holder for well known, vendor specific connector class invariant names.
    /// </summary>
    internal static class NatsInvariants
    {
        /// <summary>
        /// A list of the supported invariants.
        /// </summary>
        /// <remarks>The invariant names here do not match the namespaces as is often the convention.
        /// Current exception is MySQL Connector library that uses the same invariant as MySQL compared
        /// to the official Oracle distribution.</remarks>
        public static ICollection<string> Invariants { get; } = new Collection<string>(new List<string>(new[]
        {
            InvariantNameMySql,
            InvariantNameOracleDatabase,
            InvariantNamePostgreSql,
            InvariantNameSqlLite,
            InvariantNameSqlServer,
            InvariantNameSqlServerDotnetCore,
            InvariantNameMySqlConnector
        }));

        /// <summary>
        /// Microsoft SQL Server invariant name string.
        /// </summary>
        public const string InvariantNameSqlServer = "System.Data.SqlClient";

        /// <summary>
        /// Oracle Database server invariant name string.
        /// </summary>
        public const string InvariantNameOracleDatabase = "Oracle.DataAccess.Client";

        /// <summary>
        /// SQLite invariant name string.
        /// </summary>
        public const string InvariantNameSqlLite = "System.Data.SQLite";

        /// <summary>
        /// MySql invariant name string.
        /// </summary>
        public const string InvariantNameMySql = "MySql.Data.MySqlClient";

        /// <summary>
        /// PostgreSQL invariant name string.
        /// </summary>
        public const string InvariantNamePostgreSql = "Npgsql";

        /// <summary>
        /// Dotnet core Microsoft SQL Server invariant name string.
        /// </summary>
        public const string InvariantNameSqlServerDotnetCore = "Microsoft.Data.SqlClient";

        /// <summary>
        /// An open source implementation of the MySQL connector library.
        /// </summary>
        public const string InvariantNameMySqlConnector = "MySql.Data.MySqlConnector";
    }
}
