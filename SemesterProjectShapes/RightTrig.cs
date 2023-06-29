using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProjectShapes
{
    [Serializable]
    public class RightTrig : Shape
    {

        protected override int FrameConverter(int framedimention)
        {
            return framedimention;
        }
        public override void Paint(Graphics graphics, int thickness)
        {
            var colorborder = Selected
                ? Color.Red
                : Colorboarder;

            Point[] points = new Point[3];
            points[0] = new Point(Location.X, Location.Y);
            points[1] = new Point(Location.X, Location.Y + FrameConverter(FrameHeight));
            points[2] = new Point(Location.X + FrameConverter(FrameWidth), Location.Y + FrameConverter(FrameHeight));

            using (var brush = new SolidBrush(Fill))
            {
                graphics.FillPolygon(brush, points);
            }

            using (var pen = new Pen(colorborder, thickness))
            {
                graphics.DrawPolygon(pen, points);
            }
        }
        public override decimal Area => FrameConverter(FrameWidth) * FrameConverter(FrameHeight) / 2;
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
