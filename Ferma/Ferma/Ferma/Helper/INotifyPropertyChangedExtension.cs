﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ferma.Helper
{
    public static class INotifyPropertyChangedExtension
    {
        public static void Mutateverbose<TField>(this INotifyPropertyChanged instance, ref TField field,
           TField newValue, Action<PropertyChangedEventArgs> raise, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<TField>.Default.Equals(field, newValue)) return;
            field = newValue;
            raise?.Invoke(new PropertyChangedEventArgs(propertyName));
        }
 
}
}
