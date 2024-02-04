using System.Data;

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
    internal class NoOpCommandInterceptor : ICommandInterceptor
    {
        public static readonly ICommandInterceptor Instance = new NoOpCommandInterceptor();

        private NoOpCommandInterceptor()
        {
            
        }

        public void Intercept(IDbCommand command)
        {
            //NOP
        }
    }
}
