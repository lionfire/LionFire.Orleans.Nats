using System;
using LionFire.Orleans_.Configuration;
using LionFire.Orleans_.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Providers;
using Orleans.Runtime;
using Orleans.Runtime.Hosting;
using Orleans.Storage;

namespace LionFire.Orleans_.Hosting
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extensions.
    /// </summary>
    public static class NatsGrainStorageServiceCollectionExtensions
    {
        /// <summary>
        /// Configure silo to use  NATS grain storage as the default grain storage. Instructions on configuring your database are available at <see href="http://aka.ms/orleans-sql-scripts"/>.
        /// </summary>
        /// <remarks>
        /// Instructions on configuring your database are available at <see href="http://aka.ms/orleans-sql-scripts"/>.
        /// </remarks>
        public static IServiceCollection AddNatsGrainStorage(this IServiceCollection services, Action<NatsGrainStorageOptions> configureOptions)
        {
            return services.AddNatsGrainStorage(ProviderConstants.DEFAULT_STORAGE_PROVIDER_NAME, ob => ob.Configure(configureOptions));
        }

        /// <summary>
        /// Configure silo to use NATS grain storage for grain storage. Instructions on configuring your database are available at <see href="http://aka.ms/orleans-sql-scripts"/>.
        /// </summary>
        /// <remarks>
        /// Instructions on configuring your database are available at <see href="http://aka.ms/orleans-sql-scripts"/>.
        /// </remarks>
        public static IServiceCollection AddNatsGrainStorage(this IServiceCollection services, string name, Action<NatsGrainStorageOptions> configureOptions)
        {
            return services.AddNatsGrainStorage(name, ob => ob.Configure(configureOptions));
        }

        /// <summary>
        /// Configure silo to use NATS grain storage as the default grain storage. Instructions on configuring your database are available at <see href="http://aka.ms/orleans-sql-scripts"/>.
        /// </summary>
        /// <remarks>
        /// Instructions on configuring your database are available at <see href="http://aka.ms/orleans-sql-scripts"/>.
        /// </remarks>
        public static IServiceCollection AddNatsGrainStorageAsDefault(this IServiceCollection services, Action<OptionsBuilder<NatsGrainStorageOptions>> configureOptions = null)
        {
            return services.AddNatsGrainStorage(ProviderConstants.DEFAULT_STORAGE_PROVIDER_NAME, configureOptions);
        }

        /// <summary>
        /// Configure silo to use NATS grain storage for grain storage. Instructions on configuring your database are available at <see href="http://aka.ms/orleans-sql-scripts"/>.
        /// </summary>
        /// <remarks>
        /// Instructions on configuring your database are available at <see href="http://aka.ms/orleans-sql-scripts"/>.
        /// </remarks>
        public static IServiceCollection AddNatsGrainStorage(this IServiceCollection services, string name,
            Action<OptionsBuilder<NatsGrainStorageOptions>> configureOptions = null)
        {
            configureOptions?.Invoke(services.AddOptions<NatsGrainStorageOptions>(name));
            services.ConfigureNamedOptionForLogging<NatsGrainStorageOptions>(name);
            services.AddTransient<IPostConfigureOptions<NatsGrainStorageOptions>, DefaultStorageProviderSerializerOptionsConfigurator<NatsGrainStorageOptions>>();
            services.AddTransient<IConfigurationValidator>(sp => new NatsGrainStorageOptionsValidator(sp.GetRequiredService<IOptionsMonitor<NatsGrainStorageOptions>>().Get(name), name));
            return services.AddGrainStorage(name, NatsGrainStorageFactory.Create);
        }
    } 
}
