using System;
using System.Windows;
using System.Windows.Controls;

namespace Mine2CraftWinApp.Utils
{
    public class StateManager : DependencyObject
    {
        public static string GetVisualStateProperty(DependencyObject obj)
        {
            return (string)obj.GetValue(VisualStatePropertyProperty);
        }

        public static void SetVisualStateProperty(DependencyObject obj, string value)
        {
            obj.SetValue(VisualStatePropertyProperty, value);
        }

        public static readonly DependencyProperty VisualStatePropertyProperty =
            DependencyProperty.RegisterAttached(
                "VisualStateProperty",
                typeof(string),
                typeof(StateManager),
                new PropertyMetadata((s, e) =>
                {
                    var propertyName = (string)e.NewValue;
                    if (s is FrameworkElement)
                    {
                        var elt = s as FrameworkElement;
                        VisualStateManager.GoToElementState(elt, propertyName, true);
                    }
                    else if (s is Control)
                    {
                        var ctrl = s as Control;
                        VisualStateManager.GoToState(ctrl, propertyName, true);
                    }
                    else
                    {
                        throw new InvalidOperationException("This attached property only supports types derived from FrameworkElement or Control.");
                    }
                }));
    }

}
