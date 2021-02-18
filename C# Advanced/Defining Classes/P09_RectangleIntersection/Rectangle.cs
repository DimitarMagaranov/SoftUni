using System;
using System.Collections.Generic;
using System.Text;

namespace P09_RectangleIntersection
{
    public class Rectangle
    {
        public string Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int CoordinateXtopLeft { get; set; }
        public int CoordinateYtopLeft { get; set; }

        public Rectangle(string id, int width, int height, int coordinateXtopLeft, int coordinateYtopLeft)
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.CoordinateXtopLeft = coordinateXtopLeft;
            this.CoordinateYtopLeft = coordinateYtopLeft;
        }

        public string ChecIntersect(Rectangle rectangle)
        {
            if (rectangle.Width == this.Width && rectangle.Height == this.Height
                && rectangle.CoordinateXtopLeft == this.CoordinateXtopLeft
                && rectangle.CoordinateYtopLeft == this.CoordinateYtopLeft)
            {
                return "true";
            }

            return "false";
        }
    }
}
