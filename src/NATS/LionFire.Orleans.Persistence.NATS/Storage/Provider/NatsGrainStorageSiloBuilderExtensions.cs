using System;
using LionFire.Orleans_.Configuration;
using Microsoft.Extensions.Options;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Providers;

namespace LionFire.Orleans_.Hosting
{
    public static class NatsGrainStorageSiloBuilderExtensions
    {
        /// <summary>
        /// Configure silo to use NATS grain storage as the default grain storage. Instructions on configuring your database are available at <see href="http://aka.ms/orleans-sql-scripts"/>.
        /// </summary>
        /// <remarks>
        /// Instructions on configuring your database are available at <see href="http://aka.ms/orleans-sql-scripts"/>.
        /// </remarks>
        public static ISiloBuilder AddNatsGrainStorageAsDefault(this ISiloBuilder builder, Action<NatsGrainStorageOptions> configureOptions)
        {
            return builder.AddNatsGrainStorage(ProviderConstants.DEFAULT_STORAGE_PROVIDER_NAME, configureOptions);
        }

        /// <summary>
        /// Configure silo to use  NATS grain storage for grain storage. Instructions on configuring your database are available at <see href="http://aka.ms/orleans-sql-scripts"/>.
        /// </summary>
        /// <remarks>
        /// Instructions on configuring your database are available at <see href="http://aka.ms/orleans-sql-scripts"/>.
        /// </remarks>
        public static ISiloBuilder AddNatsGrainStorage(this ISiloBuilder builder, string name, Action<NatsGrainStorageOptions> configureOptions)
        {
            return builder.ConfigureServices(services => services.AddNatsGrainStorage(name, configureOptions));
        }

        /// <summary>
        /// Configure silo to use  NATS grain storage as the default grain storage. Instructions on configuring your database are available at <see href="http://aka.ms/orleans-sql-scripts"/>.
        /// </summary>
        /// <remarks>
        /// Instructions on configuring your database are available at <see href="http://aka.ms/orleans-sql-scripts"/>.
        /// </remarks>
        public static ISiloBuilder AddNatsGrainStorageAsDefault(this ISiloBuilder builder, Action<OptionsBuilder<NatsGrainStorageOptions>> configureOptions = null)
        {
            return builder.AddNatsGrainStorage(ProviderConstants.DEFAULT_STORAGE_PROVIDER_NAME, configureOptions);
        }

        /// <summary>
        /// Configure silo to use NATS grain storage for grain storage. Instructions on configuring your database are available at <see href="http://aka.ms/orleans-sql-scripts"/>.
        /// </summary>
        /// <remarks>
        /// Instructions on configuring your database are available at <see href="http://aka.ms/orleans-sql-scripts"/>.
        /// </remarks>
        public static ISiloBuilder AddNatsGrainStorage(this ISiloBuilder builder, string name, Action<OptionsBuilder<NatsGrainStorageOptions>> configureOptions = null)
        {
            return builder.ConfigureServices(services => services.AddNatsGrainStorage(name, configureOptions));
        }
    }
}
