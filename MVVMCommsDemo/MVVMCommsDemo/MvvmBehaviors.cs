using System;
using System.Windows;

namespace MVVMCommsDemo
{
    internal static class MvvmBehaviors
    {
        public static string GetLoadedMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(LoadedMethodNameProperty);
        }

        public static void SetLoadedMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(LoadedMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadedMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadedMethodNameProperty =
            DependencyProperty.RegisterAttached("LoadedMethodName", typeof(string), typeof(MvvmBehaviors), new PropertyMetadata(null, OnLoadedMethodNameChanged));

        private static void OnLoadedMethodNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = d as FrameworkElement;

            if (element != null)
            {
                element.Loaded += (sender, e2) =>
                {
                    object viewModel = element.DataContext;

                    if (viewModel == null)
                    {
                        return;
                    }

                    viewModel.GetType().GetMethod((string)e.NewValue)?.Invoke(viewModel, null);
                };
            }
        }
    }
}
