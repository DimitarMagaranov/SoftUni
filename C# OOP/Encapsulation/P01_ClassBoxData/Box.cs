namespace P01_ClassBoxData
{
    using System;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;

            private set
            {
                if (value > 0)
                {
                    this.length = value;
                }
                else
                {
                    throw new InvalidOperationException("Length cannot be zero or negative.");
                }
            }
        }

        public double Width
        {
            get => this.width;

            private set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new InvalidOperationException("Width cannot be zero or negative.");
                }
            }
        }

        public double Height
        {
            get => this.height;

            private set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new InvalidOperationException("Height cannot be zero or negative.");
                }
            }
        }

        public string SurfaceArea()
        {
            double result = 2 * (this.length * this.width) + 2 * (this.length * this.height) + 2 * (this.width * this.height);

            return $"Surface Area - {result:f2}";
        }

        public string LaterealSurfaceArea()
        {
            double result = 2 * (this.length * this.height) + 2 * (this.width * this.height);

            return $"Lateral Surface Area - {result:f2}";
        }

        public string Volume()
        {
            double result = this.length * this.width * this.height;

            return $"Volume - {result:f2}";
        }
    }
}
