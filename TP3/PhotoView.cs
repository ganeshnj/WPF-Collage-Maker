using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TP3
{
    class PhotoView : Border
    {
        public Photo photo;
        public Image image;

        public PhotoView()
        {
            photo = new Photo();

            this.BorderBrush = Brushes.Black;
            this.BorderThickness = new Thickness(10);
        }

        public PhotoView(Photo photo)
        {
            this.photo = photo;
            this.BorderBrush = Brushes.Black;
            this.BorderThickness = new Thickness(10);

            BitmapImage bitmapPhoto = new BitmapImage();
            bitmapPhoto.BeginInit();
            bitmapPhoto.UriSource = new Uri(photo.FileName, UriKind.Absolute);
            bitmapPhoto.EndInit();

            this.image = new Image();
            image.Source = bitmapPhoto;
            image.MaxWidth = 500;
            image.MaxHeight = 200;
            Child = this.image;            

            Canvas.SetLeft(this, photo.Location.X);
            Canvas.SetTop(this, photo.Location.Y);
        }

        internal void SetSelection()
        {
            this.BorderBrush = Brushes.Red;
        }

        internal void RemoveSelection()
        {
            this.BorderBrush = Brushes.Black;
        }
    }

}
