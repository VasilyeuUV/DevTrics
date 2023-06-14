using DevTricks.Domain.Settings;


namespace DevTricks.Infrastructure.Settings
{
    /// <summary>
    /// Базовый абстрактный класс Wrapper-а для Memento окон
    /// </summary>
    public abstract class AWindowMementoWrapperBase<TMemento> : IWindowMementoWrapper, IWindowMementoWrapperInitializer, IDisposable
        where TMemento : AWindowMemento, new()
    {
        private readonly IPathService _pathService;

        private TMemento _windowMemento;
        private bool _isInitialized;                // - флаг, что Wrapper был инициализирован (false /отсутствие инициализации/ по умолчанию)
        private string _settingsFilePath;           // - полный путь к файлу с настройками окна


        /// <summary>
        /// CTOR
        /// </summary>
        protected AWindowMementoWrapperBase(
            IPathService pathService
            )
        {
            this._pathService = pathService;            // - экземпляр PathService
            this._windowMemento = new TMemento();       // - создание экземпляра Memento, который будет использован при первом запуске приложения
        }


        /// <summary>
        /// Для название файла для конкретной Memento
        /// </summary>
        protected abstract string MementoName { get; }


        /// <summary>
        /// Проверка, были ли Wrapper инициализирован (защита, чтобы гарантировать инициализацию). 
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        private void EnshureInitialized()
        {
            if (!_isInitialized)
                throw new InvalidOperationException($"Wrapper for {typeof(TMemento)} is not initialized");
        }


        //############################################################################################################
        #region IWindowMementoWrapper

        // свойства Wrapper-a, должны читать и писать в соответстующие свойсва Memento
        // предварительно проверять, был ли Wrapper инициализирован

        public double Left
        {
            get
            {
                EnshureInitialized();
                return _windowMemento.Left;
            }
            set
            {
                EnshureInitialized();
                _windowMemento.Left = value;
            }
        }

        public double Top
        {
            get
            {
                EnshureInitialized();
                return _windowMemento.Top;
            }
            set
            {
                EnshureInitialized();
                _windowMemento.Top = value;
            }
        }

        public double Width
        {
            get
            {
                EnshureInitialized();
                return _windowMemento.Width;
            }
            set
            {
                EnshureInitialized();
                _windowMemento.Width = value;
            }
        }

        public double Height
        {
            get
            {
                EnshureInitialized();
                return _windowMemento.Height;
            }
            set
            {
                EnshureInitialized();
                _windowMemento.Height = value;
            }
        }

        public bool IsMaximized
        {
            get
            {
                EnshureInitialized();
                return _windowMemento.IsMaximized;
            }
            set
            {
                EnshureInitialized();
                _windowMemento.IsMaximized = value;
            }
        }



        #endregion // IWindowMementoWrapper


        //############################################################################################################
        #region IWindowMementoWrapperInitializer

        public void Initialize()
        {
            // - проверим, не был ли Wrapper уже инициализирован
            if (_isInitialized)
                throw new InvalidOperationException($"Wrapper for {typeof(TMemento)} is already initialized");

            const string settingsFolderName = "Settings";           // имя папки, в которой будут храниться настройки

            // - путь к папке с настройками
            var settingsPath = Path.Combine(_pathService.ApplicationFolder, settingsFolderName);
            _settingsFilePath = Path.Combine(settingsPath, $"{MementoName}.json");

            // - создаём директорию под Приложение, если её нет
            Directory.CreateDirectory(settingsPath);

            // - проверка на существование файла
            if (!File.Exists(_settingsFilePath))
                return;

            // - читаем файл в виде строки
            var serializedMemento = File.ReadAllText(_settingsFilePath);                        // - получим json-документ с сериализованной Memento 
            _windowMemento = JsonConvert.DeserializeObject<TMemento>(serializedMemento);        // - десериализуем Memento
        }

        #endregion // IWindowMementoWrapperInitializer



        //############################################################################################################
        #region IDisposable

        public void Dispose()
        {
            // 1. Сохраняем параметры окна при закрытии Приложения
            EnshureInitialized();                                                      // - проверка факта сериализации. Если не инициализирован, то мы не знаем пути к файлу

            var serializedMemento = JsonConvert.SerializeObject(_windowMemento);       // - сериализуем Memento (получаем json документ)
            File.WriteAllText(_settingsFilePath, serializedMemento);                   // - сохраняем json в файл


        }

        #endregion // IDisposable
    }
}
