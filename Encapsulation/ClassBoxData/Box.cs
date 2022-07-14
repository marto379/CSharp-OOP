using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {

        private const int BoxPropertyMinValue = 0;
        private const string ZeroOrNegative = "{0} cannot be zero or negative.";

       private double lenght;
       private double width;
       private double height;

        public Box(double lenght, double width, double height)
        {
            Lenght = lenght;
            Width = width;
            Height = height;
            
        }

        public double Lenght
        {
            get
            {
                return lenght;
            }
            private set
            {
                if (value <= BoxPropertyMinValue)
                {
                    throw new ArgumentException(String.Format(ZeroOrNegative,nameof(this.Lenght)));
                }
                lenght = value;
            }
        }
        public double Width { 
            get
            {
                return width;
            } 
            private set
            {
                if (value <= BoxPropertyMinValue)
                {
                    throw new ArgumentException(String.Format(ZeroOrNegative,nameof(this.Width)));
                }
                width = value;
            }
        }
        public double Height 
        { get
            {
                return height;  
            }
           private set
            {
                if (value <= BoxPropertyMinValue)
                {
                    throw new ArgumentException(String.Format(ZeroOrNegative,nameof(this.Height)));
                }
                height = value;
            }   
        }

        public double SurfaceArea()
            => 2 * this.Lenght * this.Width + 2 * this.Lenght * this.Height + 2 * this.Width * this.Height;

        public double LateralSurfaceArea()
            => 2 * this.Lenght * this.Height + 2 * this.Width * this.Height;

        public double Volume()
            => this.Lenght * this.Height * this.Width;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {SurfaceArea():f2}")
                .AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}")
                .AppendLine($"Volume - {Volume():f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
