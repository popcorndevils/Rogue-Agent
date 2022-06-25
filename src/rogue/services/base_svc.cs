using Rogue.Systems;

namespace Rogue.Services
{
    /// <summary>
    /// Base class for services.  Services offer a safe interface to a client system.
    /// </summary>
    /// <typeparam name="T">Client system of the service.</typeparam>
    public abstract class BaseSvc<T> where T : BaseSys
    {    
        protected static T? Client;

        internal static void Register(T client)
        {
            BaseSvc<T>.Client = client;
        }
    }
}