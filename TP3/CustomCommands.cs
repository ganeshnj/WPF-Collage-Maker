using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TP3
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand(
            "Exit",
            "Exit",
            typeof(CustomCommands),
            new InputGestureCollection() 
            { 
                new KeyGesture(Key.F4, ModifierKeys.Alt) 
            }
        );

        public static readonly RoutedUICommand Import = new RoutedUICommand(
            "Import",
            "Import",
            typeof(CustomCommands),
            new InputGestureCollection(){
                new KeyGesture(Key.I, ModifierKeys.Alt)
            });

        public static readonly RoutedUICommand Delete = new RoutedUICommand(
           "Delete",
           "Delete",
           typeof(CustomCommands),
           new InputGestureCollection(){
                new KeyGesture(Key.Delete)
            });
    }
}
