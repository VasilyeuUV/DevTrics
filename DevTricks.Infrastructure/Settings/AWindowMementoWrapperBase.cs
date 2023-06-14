using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTricks.Domain.Settings
{
    /// <summary>
    /// Базовый абстрактный класс Wrapper-а для Memento окон
    /// </summary>
    internal abstract class AWindowMementoWrapperBase : IWindowMementoWrapper, IWindowMementoWrapperInitializer, IDisposable
    {


        /// <summary>
        /// CTOR
        /// </summary>
        protected AWindowMementoWrapperBase(
            IPathService 
            )
        {
                
        }

        //############################################################################################################
        #region IWindowMementoWrapper

        public double Left { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Top { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsMaximized { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }



        #endregion // IWindowMementoWrapper




        //############################################################################################################
        #region IDisposable

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion // IDisposable
    }
}
