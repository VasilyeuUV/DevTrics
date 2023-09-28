using DevTricks.Domain.DevTools;

namespace DevTricks.Infrastructure.DevTools
{
    /// <summary>
    /// Провайдер для режима DevTools
    /// </summary>
    internal class DevToolsStatusProvider : IDevToolsStatusProvider
    {

        //############################################################################################################
        #region IDevToolsStatusProvider

        public bool IsEnabled =>
        #if DEBUG 
            true;
        #else 
            false;
        #endif

        #endregion // IDevToolsStatusProvider
    }
}
