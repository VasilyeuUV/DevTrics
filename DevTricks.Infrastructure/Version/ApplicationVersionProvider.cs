using DevTricks.Domain.Version;

namespace DevTricks.Infrastructure.Version
{
    /// <summary>
    /// Провайдер версии приложения  
    /// </summary>
    internal class ApplicationVersionProvider : IApplicationVersionProvider
    {

        //############################################################################################################
        #region IApplicationVersionProvider

        public System.Version Version => new(1,0,0);        // - пока не вычисляем


        #endregion // IApplicationVersionProvider
    }
}
