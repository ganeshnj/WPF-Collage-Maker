using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace TP3
{
    class AlbumCanvas : Canvas
    {
        private UIElement elementBeingDragged;
        public UIElement ElementBeingDragged 
        {
            get
            {
                return elementBeingDragged;
            }
            set
            {
                if (value != elementBeingDragged)
                {
                    elementBeingDragged = value;
                }
            }
        }

        public PhotoView PhotoViewDragging { get; set; }

        private Point startPoint;
        private Point movingPoint;
        private Boolean isMoving;

        public UIElement FindCanvasChild(DependencyObject depObj)
        {
            while (depObj != null)
            {
                UIElement elem = depObj as UIElement;
                if (elem != null && base.Children.Contains(elem))
                    break;

                if (depObj is Visual || depObj is Visual3D)
                    depObj = VisualTreeHelper.GetParent(depObj);
                else
                    depObj = LogicalTreeHelper.GetParent(depObj);
            }
            return depObj as UIElement;
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);
            this.isMoving = false;
            this.startPoint = e.GetPosition(this);

            this.ElementBeingDragged = null;
            //this.PhotoViewDragging = null;

            this.ElementBeingDragged = this.FindCanvasChild(e.Source as DependencyObject);

            if (PhotoViewDragging != null)
                PhotoViewDragging.RemoveSelection();

            if (ElementBeingDragged != null && ElementBeingDragged.GetType()== typeof(PhotoView))
            {
                PhotoViewDragging = (PhotoView)ElementBeingDragged;
                PhotoViewDragging.SetSelection();
                PhotoViewDragging.CaptureMouse();
                this.isMoving = true;    
            }
        }

        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonUp(e);
            if (PhotoViewDragging != null)
            {
                PhotoViewDragging.ReleaseMouseCapture();
            }
            this.isMoving = false;
        }

        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);

            if (isMoving == true && e.LeftButton == MouseButtonState.Pressed )
            {
                movingPoint = e.GetPosition(this);
                ((PhotoView)ElementBeingDragged).photo.Location.X += movingPoint.X - startPoint.X;
                ((PhotoView)ElementBeingDragged).photo.Location.Y += movingPoint.Y - startPoint.Y;

                Canvas.SetLeft(ElementBeingDragged, ((PhotoView)ElementBeingDragged).photo.Location.X);
                Canvas.SetTop(ElementBeingDragged, ((PhotoView)ElementBeingDragged).photo.Location.Y);

                startPoint = movingPoint;
            }
        }


        internal void delete()
        {
            if (PhotoViewDragging != null)
            {
                this.Children.Remove(PhotoViewDragging);
            }
        }
    }
}
