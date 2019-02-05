using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VariabelBegreb.Models
{
    public class MoreXAMLProps
    {
        public static readonly DependencyProperty MarginLeftProperty = DependencyProperty.RegisterAttached(
            "MarginLeft",
            typeof(string),
            typeof(MoreXAMLProps),
            new UIPropertyMetadata(OnMarginLeftPropertyChanged));

        public static string GetMarginLeft(FrameworkElement element)
        {
            return (string)element.GetValue(MarginLeftProperty);
        }

        public static void SetMarginLeft(FrameworkElement element, string value)
        {
            element.SetValue(MarginLeftProperty, value);
        }

        public static void OnMarginLeftPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var element = obj as FrameworkElement;

            if (element != null)
            {
                int value;
                if (Int32.TryParse((string)args.NewValue, out value))
                {
                    var margin = element.Margin;
                    margin.Left = value;
                    element.Margin = margin;
                }
            }
        }
    }
}
