using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProjectShapes
{
    [Serializable]
    public abstract class Shape
    {
        public int ShapeFlag { get; set; }
        public int FrameWidth { get; set; }
        public int FrameHeight { get; set; }
        public Point Location { get; set; }
        public Color Colorboarder { get; set; }
        public Color Fill { get; set; }
        public bool Selected { get; set; }
        public abstract void Paint(Graphics graphics, int thickness);
        public abstract decimal Area { get; }
        public abstract bool InShape(Point point);
        public abstract bool Intersect(Shape rectangle);
        public abstract void Move(Point previous, Point current);
        protected abstract int FrameConverter(int framedimention);
    }
}
