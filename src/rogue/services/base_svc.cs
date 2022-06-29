using Rogue.System;

namespace Rogue.Services
{
    /// <summary>
    /// Base class for services.  Services offer a safe interface to a client system.
    /// </summary>
    /// <typeparam name="T">Client system of the service.</typeparam>
    public abstract class BaseSvc<T> where T : BaseSys, new()
    {    
        protected static T? Minion;

        /// <summary>
        /// Instantiates the base system type and registers with parent service.
        /// </summary>
        internal static T Register()
        {
            T minion = new T();
            minion.Initialize();
            BaseSvc<T>.Minion = minion;
            return minion;
        }

        /// <summary>
        /// Runs during update cycle of application.
        /// </summary>
        internal static void Update()
        {
            if(BaseSvc<T>.Minion is not null)
            {
                BaseSvc<T>.Minion.Update();
            }
        }

        /// <summary>
        /// Runs during render cycle of application.
        /// </summary>
        internal static void Render()
        {
            if(BaseSvc<T>.Minion is not null)
            {
                BaseSvc<T>.Minion.Render();
            }
        }
    }
}