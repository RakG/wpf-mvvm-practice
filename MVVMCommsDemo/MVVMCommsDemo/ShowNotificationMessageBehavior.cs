using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace MVVMCommsDemo
{
    internal sealed class ShowNotificationMessageBehavior : Behavior<ContentControl>
    {
        // Using a DependencyProperty as the backing store for Message. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(ShowNotificationMessageBehavior), new PropertyMetadata(null, OnMessageChanged));

        public string Message
        {
            get => (string)this.GetValue(MessageProperty);
            set => this.SetValue(MessageProperty, value);
        }

        private static void OnMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ShowNotificationMessageBehavior behavior = (ShowNotificationMessageBehavior)d;
            behavior.AssociatedObject.Content = e.NewValue;
            behavior.AssociatedObject.Visibility = Visibility.Visible;
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.MouseLeftButtonDown += (sender, e) =>
            {
                this.AssociatedObject.Visibility = Visibility.Hidden;
            };
        }
    }
}
