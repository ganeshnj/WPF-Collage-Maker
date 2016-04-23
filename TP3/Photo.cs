using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TP3
{
    public class Photo
    {
        public Point Location;
        public String FileName;

        public Photo()
        {

        }

        public Photo(Point location, String filename)
        {
            this.Location.X = location.X;
            this.Location.Y = location.Y;
            this.FileName = filename;
        }
    }
}
