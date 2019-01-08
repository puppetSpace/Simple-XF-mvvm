using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pi.Xf.SimpleMvvm
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Set a value and notify the change
        /// </summary>
        /// <typeparam name="TE"></typeparam>
        /// <param name="originalvalue"></param>
        /// <param name="newvalue"></param>
        /// <param name="notifiedProperty"></param>
        protected void Set<TE>(ref TE originalvalue, TE newvalue, bool ignoreEquality = false, [CallerMemberName]string notifiedProperty = "")
        {
            if (!ignoreEquality && EqualityComparer<TE>.Default.Equals(originalvalue, newvalue))
                return;

            originalvalue = newvalue;
            OnPropertyChanged(new PropertyChangedEventArgs(notifiedProperty));
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs propertyChangedEventArgs)
        {
            PropertyChanged?.Invoke(this, propertyChangedEventArgs);
        }
    }
}
