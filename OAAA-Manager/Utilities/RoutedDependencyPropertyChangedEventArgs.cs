using System;
using System.Windows;

namespace OAAA_Manager.Utilities
{
    /// <summary>
    /// This is a special args set that combines the important parts of RoutedEventArgs (Handled) with DependencyPropertyChangedEventArgs
    /// </summary>
    public class RoutedDependencyPropertyChangedEventArgs : EventArgs
    {
        public Boolean Handled { get; set; }
        public Object OldValue { get; set; }
        public Object NewValue { get; set; }
        public DependencyProperty Property { get; set; }
    }

    public delegate void RoutedPropertyChangedCallback(DependencyObject sender, RoutedDependencyPropertyChangedEventArgs e);
}
