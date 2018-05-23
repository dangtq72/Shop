using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace NangShop.Themes
{
    public partial class MainWindowETF
    {
        private void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            Window w = Window.GetWindow((System.Windows.DependencyObject)sender);
            w.Close();
        }

        private void Title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window w = Window.GetWindow((System.Windows.DependencyObject)sender);
            w.DragMove();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            Window w = Window.GetWindow((System.Windows.DependencyObject)sender);
            w.DialogResult = true;
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            Window w = Window.GetWindow((System.Windows.DependencyObject)sender);
            w.DialogResult = false;
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            Window w = Window.GetWindow((System.Windows.DependencyObject)sender);
            w.WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            Window w = Window.GetWindow((System.Windows.DependencyObject)sender);
            if (w.WindowState == WindowState.Maximized)
                w.WindowState = WindowState.Normal;
            else
                w.WindowState = WindowState.Maximized;
        }

        private void DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window w = Window.GetWindow((System.Windows.DependencyObject)sender);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (w.WindowState == WindowState.Maximized)
                {
                    w.WindowState = WindowState.Normal;
                }
                else
                    w.WindowState = WindowState.Maximized;
                e.Handled = true;
            }
        }
    }
}
