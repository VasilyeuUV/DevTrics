using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DevTricks.ViewModels.Commands
{
    /// <summary>
    /// Класс универсальной команды (не привязанной к конкретной логической задаче)
    /// т.е. нужно передать команде выполняемую логику извне 
    /// </summary>
    public class Command : ICommand
    {
        private readonly Action _execute;       // - выполняемая логика команды
        private ICommand openAboutWindow;


        /// <summary>
        /// СТОР
        /// </summary>
        /// <param name="execute">Метод для выполнения, переданный извне</param>
        public Command(Action execute)
        {
            this._execute = execute;
        }

        public Command(ICommand openAboutWindow)
        {
            this.openAboutWindow = openAboutWindow;
        }


        //################################################################################################
        #region ICommand

        public event EventHandler? CanExecuteChanged;


        public bool CanExecute(object? parameter)
        {
            return true;
        }


        public void Execute(object? parameter)
        {
            _execute.Invoke();      // - выполнение логики команды, поступившей извне
        }

        #endregion // ICommand
    }
}
