using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProjectShapes
{
    [Serializable]
    public class Rectangle : Shape
    {
        protected override int FrameConverter(int framedimention)
        {
            return framedimention;
        }
        public override void Paint(Graphics graphics, int thickness = 1)
        {
            var colorborder = Selected
                ? Color.Red
                : Colorboarder;

            using (var brush = new SolidBrush(Fill))
            {
                graphics.FillRectangle(brush, Location.X, Location.Y, FrameConverter(FrameWidth), FrameConverter(FrameHeight));
            }

            using (var pen = new Pen(colorborder, thickness))
            {
                graphics.DrawRectangle(pen, Location.X, Location.Y, FrameConverter(FrameWidth), FrameConverter(FrameHeight));
            }
        }
        public override decimal Area => FrameConverter(FrameWidth) * FrameConverter(FrameHeight);
        public override bool InShape(Point point)
        {
            return
                Location.X <= point.X && point.X <= Location.X + FrameConverter(FrameWidth) &&
                Location.Y <= point.Y && point.Y <= Location.Y + FrameConverter(FrameHeight);
        }

        public override bool Intersect(Shape rectangle)
        {
            return
                Location.X < rectangle.Location.X + rectangle.FrameWidth && rectangle.Location.X < Location.X + FrameConverter(FrameWidth) &&
                Location.Y < rectangle.Location.Y + rectangle.FrameHeight && rectangle.Location.Y < Location.Y + FrameConverter(FrameHeight);

        }
        public override void Move(Point previous, Point current)
        {
            var changex = previous.X - current.X;
            var changey = previous.Y - current.Y;
            Point Destination1 = new Point(Location.X - changex, Location.Y - changey);
            Location = Destination1;
        }
    }
}
