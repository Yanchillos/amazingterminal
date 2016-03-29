using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTerminal.Misc
{
    public abstract class BaseViewModel<T> : INotifyPropertyChanged where T : class, new()
    {
        private static T _Current;
        public static T Current
        {
            get
            {
                if (_Current == null)
                    _Current = new T();
                return _Current;
            }
            protected set
            {
                _Current = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
