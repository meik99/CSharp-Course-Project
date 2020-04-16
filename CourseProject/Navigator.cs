using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CourseProject
{
    public class Navigator
    {
        private static Navigator _navigator = null;

        public static Navigator Instance
        {
            get
            {
                _navigator ??= new Navigator();
                return _navigator;
            }
        }

        public Frame SourceFrame { get; set; }

        public void Navigate(UserControl control)
        {
            SourceFrame.Navigate(control);
            SourceFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }
    }
}