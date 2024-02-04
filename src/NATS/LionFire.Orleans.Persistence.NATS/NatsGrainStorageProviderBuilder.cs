#if TODO
using System;
using LionFire.Orleans_.Configuration;
using LionFire.Orleans_.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Providers;
using Orleans.Storage;

[assembly: RegisterProvider("NATS", "GrainStorage", "Silo", typeof(NatsGrainStorageProviderBuilder))]

namespace LionFire.Orleans_.Hosting;

internal sealed class NatsGrainStorageProviderBuilder : IProviderBuilder<ISiloBuilder>
{
    public void Configure(ISiloBuilder builder, string name, IConfigurationSection configurationSection)
    {
        builder.AddNatsGrainStorage(name, (OptionsBuilder<NatsGrainStorageOptions> optionsBuilder) => optionsBuilder.Configure<IServiceProvider>((options, services) =>
            {
                var invariant = configurationSection[nameof(options.Invariant)];
                if (!string.IsNullOrEmpty(invariant))
                {
                    options.Invariant = invariant;
                }

                var connectionString = configurationSection[nameof(options.ConnectionString)];
                var connectionName = configurationSection["ConnectionName"];
                if (string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(connectionName))
                {
                    connectionString = services.GetRequiredService<IConfiguration>().GetConnectionString(connectionName);
                }

                if (!string.IsNullOrEmpty(connectionString))
                {
                    options.ConnectionString = connectionString;
                }

                var serializerKey = configurationSection["SerializerKey"];
                if (!string.IsNullOrEmpty(serializerKey))
                {
                    options.GrainStorageSerializer = services.GetRequiredKeyedService<IGrainStorageSerializer>(serializerKey);
                }
            }));
    }
}
#endif