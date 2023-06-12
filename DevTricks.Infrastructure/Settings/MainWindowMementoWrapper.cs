using DevTricks.Domain.Settings;
using Newtonsoft.Json;

namespace DevTricks.Infrastructure.Settings
{
    /// <summary>
    /// Класс, объект которого будет отвечать за загрузку, сохранение и чтение настроек главного окна в файл JSON
    /// (Класс оболочки для Memento)
    /// </summary>
    internal class MainWindowMementoWrapper : IMainWindowMementoWrapper, IMainWindowMementoWrapperInitializer, IDisposable
    {
        private MainWindowMemento _mainWindowMemento;               // - экземпляр Memeno с настройками по умолчанию, когда файла ещё не существует 
        private bool _isInitialized;                                // - флаг, что Wrapper был инициализирован (false /отсутствие инициализации/ по умолчанию)
        private string? _settingsFilePath;                          // - полный путь с именем файла с настройками главного окна


        /// <summary>
        /// CTOR
        /// </summary>
        public MainWindowMementoWrapper()
        {
            _mainWindowMemento = new MainWindowMemento();           // - создание экземпляра Memento, который будет использован при первом запуске приложения
        }


        /// <summary>
        /// Проверка, были ли Wrapper инициализирован (защита, чтобы гарантировать инициализацию). 
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        private void EnshureInitialized()
        {
            if (!_isInitialized)
                throw new InvalidOperationException($"{nameof(IMainWindowMementoWrapper)} is not initialized");
        }


        //##############################################################################################################
        #region IMainWindowMementoWrapper

        // свойства Wrapper-a, должны читать и писать в соответстующие свойсва Memento
        // предварительно проверять, был ли Wrapper инициализирован

        public double Left
        {
            get
            {
                EnshureInitialized();
                return _mainWindowMemento.Left;
            }
            set
            {
                EnshureInitialized();
                _mainWindowMemento.Left = value;
            }
        }

        public double Top
        {
            get
            {
                EnshureInitialized();
                return _mainWindowMemento.Top;
            }
            set
            {
                EnshureInitialized();
                _mainWindowMemento.Top = value;
            }
        }

        public double Width
        {
            get
            {
                EnshureInitialized();
                return _mainWindowMemento.Width;
            }
            set
            {
                EnshureInitialized();
                _mainWindowMemento.Width = value;
            }
        }

        public double Height
        {
            get
            {
                EnshureInitialized();
                return _mainWindowMemento.Height;
            }
            set
            {
                EnshureInitialized();
                _mainWindowMemento.Height = value;
            }
        }

        public bool IsMaximized
        {
            get
            {
                EnshureInitialized();
                return _mainWindowMemento.IsMaximized;
            }
            set
            {
                EnshureInitialized();
                _mainWindowMemento.IsMaximized = value;
            }
        }

        #endregion // IMainWindowMementoWrapper


        //##############################################################################################################
        #region IMainWindowMementoWrapperInitializer

        public void Initialize()
        {
            // - проверим, не был ли Wrapper уже инициализирован
            if (_isInitialized)
                throw new InvalidOperationException($"{nameof(IMainWindowMementoWrapper)} is already initialized");

            _isInitialized = true;

            // - ищем settings файл, чтобы загрузить из него данные
            // - Microsoft рекомендует хранить настройки приложения в профиле Пользователя, который находится в папке с именем Пользователя в папке Users на диске С. 
            var localApplicationDataPath = Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData);   // - получаем имя папки Локальных данных профиля Пользователя
           
            // в этой папке принято создавать папку с наименованием компании, в которой создать папку с именем приложения, в которой иметь папку с настройками
            const string company = "DevTricks Channel";
            const string applicationName = "DevTricks App";
            const string settingsFolderName = "Settings";           // имя папки, в которой будут храниться настройки

            // - формируем путь к папке настроек Приложения (именно через Path, т.к. учитывает слэши)
            var settingsPath = Path.Combine( localApplicationDataPath, company, applicationName, settingsFolderName);

            // - формируем полный путь к файлу с настройками главного окна
            _settingsFilePath = Path.Combine(settingsPath, "MainWindowMemento.json");

            // - создаём директорию под Приложение, если её нет
            Directory.CreateDirectory(settingsPath);

            // - проверка на существование файла
            if (!File.Exists(_settingsFilePath))
                return;

            // - читаем файл в виде строки
            var serializedMemento = File.ReadAllText(_settingsFilePath);                                // - получим json-документ с сериализованной Memento 
            _mainWindowMemento = JsonConvert.DeserializeObject<MainWindowMemento>(serializedMemento);   // - десериализуем Memento
        }

        #endregion // IMainWindowMementoWrapperInitializer


        //##############################################################################################################
        #region IDisposable

        public void Dispose()
        {
            // 1. Сохраняем параметры главного окна при закрытии Приложения
            EnshureInitialized();                                                       // - проверка факта сериализации. Если не инициализирован, то мы не знаем пути к файлу

            var serializedMemento = JsonConvert.SerializeObject(_mainWindowMemento);    // - сериализуем Memento (получаем json документ)
            File.WriteAllText(_settingsFilePath, serializedMemento);                   // - сохраняем json в файл


        }

        #endregion // IDisposable
    }
}
 