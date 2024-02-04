using LionFire.Orleans_.Persistence.NATS.Storage;
using LionFire.Orleans_.Storage;
using Orleans;
using Orleans.Runtime;
using Orleans.Storage;

namespace LionFire.Orleans_.Configuration
{
    /// <summary>
    /// Options for NATS grain storage.
    /// </summary>
    public class NatsGrainStorageOptions : IStorageProviderSerializerOptions
    {
        /// <summary>
        /// Connection string for NATS storage.
        /// </summary>
        [Redact]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Stage of silo lifecycle where storage should be initialized.  Storage must be initialized prior to use.
        /// </summary>
        public int InitStage { get; set; } = DEFAULT_INIT_STAGE;
        /// <summary>
        /// Default init stage in silo lifecycle.
        /// </summary>
        public const int DEFAULT_INIT_STAGE = ServiceLifecycleStage.ApplicationServices;

        /// <summary>
        /// The default ADO.NET invariant used for storage if none is given. 
        /// </summary>
        public const string DEFAULT_NATS_INVARIANT = NatsInvariants.InvariantNameSqlServer;

        /// <summary>
        /// The invariant name for storage.
        /// </summary>
        public string Invariant { get; set; } = DEFAULT_NATS_INVARIANT;

        /// <inheritdoc/>
        public IGrainStorageSerializer GrainStorageSerializer { get; set; }
    }

    /// <summary>
    /// ConfigurationValidator for NatsGrainStorageOptions
    /// </summary>
    public class NatsGrainStorageOptionsValidator : IConfigurationValidator
    {
        private readonly NatsGrainStorageOptions options;
        private readonly string name;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configurationOptions">The option to be validated.</param>
        /// <param name="name">The name of the option to be validated.</param>
        public NatsGrainStorageOptionsValidator(NatsGrainStorageOptions configurationOptions, string name)
        {
            if(configurationOptions == null)
                throw new OrleansConfigurationException($"Invalid NatsGrainStorageOptions for NatsGrainStorage {name}. Options is required.");
            this.options = configurationOptions;
            this.name = name;
        }
        /// <inheritdoc cref="IConfigurationValidator"/>
        public void ValidateConfiguration()
        {
            if (string.IsNullOrWhiteSpace(this.options.Invariant))
            {
                throw new OrleansConfigurationException($"Invalid {nameof(NatsGrainStorageOptions)} values for {nameof(NatsGrainStorage)} \"{name}\". {nameof(options.Invariant)} is required.");
            }

            if (string.IsNullOrWhiteSpace(this.options.ConnectionString))
            {
                throw new OrleansConfigurationException($"Invalid {nameof(NatsGrainStorageOptions)} values for {nameof(NatsGrainStorage)} \"{name}\". {nameof(options.ConnectionString)} is required.");
            }
        }
    }
}
