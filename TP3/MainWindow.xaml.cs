using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TP3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Album album;
        public MainWindow()
        {
            album = new Album();

            InitializeComponent();
        }

        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e) 
        { 
            e.CanExecute = true; 
        }                  
        
        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e) 
        { 
            Application.Current.Shutdown(); 
        }

        private void ImportCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ImportCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); 
            openFileDialog.Multiselect = true; 
            openFileDialog.Filter = "JPEG files (*.jpg)|*.jpg|All files (*.*)|*.*"; 
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            if (openFileDialog.ShowDialog() == true) 
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    Photo photo = new Photo(new Point(0, 0), filename);
                    album.Photos.Add(photo);
                    albumCanvas.Children.Add(new PhotoView(photo));
                } 
            }      
        }
        private void DeleteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DeleteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            albumCanvas.delete();
        }

    }
}
