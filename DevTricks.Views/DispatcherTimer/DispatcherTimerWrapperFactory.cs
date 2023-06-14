using DevTricks.Domain.DispatcherTimer;

namespace DevTricks.Views.DispatcherTimer
{
    internal class DispatcherTimerWrapperFactory : IDispatcherTimerFactory
    {

        //############################################################################################################
        #region IDispatcherTimerFactory

        public IDispatcherTimer Create(TimeSpan interval)
        {
            return new DispatcherTimerWrapper
            {
                Interval = interval
            };
        }

        #endregion // IDispatcherTimerFactory

    }
}
