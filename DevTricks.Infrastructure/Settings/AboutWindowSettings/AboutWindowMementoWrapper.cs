using DevTricks.Domain.Settings;
using DevTricks.Domain.Settings.AboutWindowSettings;
using DevTricks.Infrastructure.Common.Services.PathService;

namespace DevTricks.Infrastructure.Settings.AboutWindowSettings
{
    /// <summary>
    /// Оболочка для настройек окна "О программе"
    /// </summary>
    internal class AboutWindowMementoWrapper : AWindowMementoWrapperBase<AboutWindowMemento>, IAboutWindowMementoWrapper
    {
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="pathService"></param>
        public AboutWindowMementoWrapper(IPathService pathService) : base(pathService)
        {
        }

        protected override string MementoName => nameof(AboutWindowMementoWrapper).Remove("Wrapper".Length);
    }
}
