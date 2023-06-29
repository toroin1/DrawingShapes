using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemesterProjectShapes
{
    public partial class FormScene : Form
    {
        private List<Shape> Shapes = new List<Shape>();
        private Point mousecaptured;
        private bool action = false;
        private Shape frame;
        private int chosenshapeFlag;
        private Shape newshape;
        private Shape copiedshape;


        public FormScene()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Shapes == null)
                return;
            for (int s = Shapes.Count() - 1; s >= 0; s--)
                Shapes[s]?.Paint(e.Graphics, 2);
            frame?.Paint(e.Graphics, 1);
        }

        private void FormScene_DoubleClick(object sender, EventArgs e)
        {
            if (Shapes == null)
                return;
            foreach (var shape in Shapes)
                if (shape.Selected)
                {
                    var fp = new FormProperties();
                    fp.Shape = shape;

                    fp.ShowDialog();
                    Invalidate();
                    break;
                }
        }

        private void FormScene_MouseDown(object sender, MouseEventArgs e)
        {
            action = true;
            mousecaptured = e.Location;
            
            frame = new Rectangle
            {
                Colorboarder = Color.Black
            };
            foreach (var s in Shapes)
                s.Selected = false;
            foreach (var selectedshape in Shapes)
            {
                if (selectedshape.InShape(e.Location))
                {
                    selectedshape.Selected = true;
                    frame = null;
                    break;
                }
                else
                    selectedshape.Selected = false;
            }
           
            Invalidate();
        }

        private void FormScene_MouseMove(object sender, MouseEventArgs e)
        {
            if (action  == false)
                return;
            if(frame != null)
            {
                frame.Location = new Point
                {
                    X = Math.Min(mousecaptured.X, e.Location.X),
                    Y = Math.Min(mousecaptured.Y, e.Location.Y)
                };

                frame.FrameWidth = Math.Abs(mousecaptured.X - e.Location.X);
                frame.FrameHeight = Math.Abs(mousecaptured.Y - e.Location.Y);
            }
            
            if (e.Button == MouseButtons.Right)
            {
                foreach (var s in Shapes)
                {
                    if (s.Selected && frame == null)
                    {
                        s.Move(mousecaptured, e.Location);
                        mousecaptured = e.Location;
                    }
                    else if(frame != null)
                        s.Selected = s.Intersect(frame);
                }               
            }
            
            Invalidate();
        }
        private void FormScene_MouseUp(object sender, MouseEventArgs e)
        {

            decimal area = 0;
            
            if (e.Button == MouseButtons.Middle && copiedshape != null)
            {
                foreach (var s in Shapes)
                {
                    s.Selected = false;
                    area = s.Area;
                }
                copiedshape.Location = e.Location;
                copiedshape.Selected = true;
                Shapes.Insert(0, copiedshape);
                copiedshape = null;
                toolStripStatusLabelArea.Text = "Area is : " + " " + area.ToString();
            }
            if(frame != null && e.Button == MouseButtons.Left)
            {
                foreach (var s in Shapes)
                {
                    s.Selected = false;
                    area = s.Area;
                }
                
                if (chosenshapeFlag > 0)
                {
                    Choice(chosenshapeFlag);
                    newshape.Location = frame.Location;
                    newshape.FrameHeight = frame.FrameHeight;
                    newshape.FrameWidth = frame.FrameWidth;
                    newshape.Selected = true;
                    area += newshape.Area;
                    Shapes.Insert(0, newshape);
                }

                toolStripStatusLabelArea.Text = "Area is : " + " " + area.ToString();
            }
            frame = null;
            action = false;
            Invalidate();
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chosenshapeFlag = 1;
        }

        private void elipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chosenshapeFlag = 2;
        }

        private void isoscelesTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chosenshapeFlag = 3;
        }

        private void rightTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chosenshapeFlag = 4;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Shapes == null)
                return;
            decimal area = 0;
            for (int s = Shapes.Count() - 1; s >= 0; s--)
            {
                if (Shapes[s].Selected)
                    Shapes.RemoveAt(s);
                else
                    area += Shapes[s].Area;
            }

            toolStripStatusLabelArea.Text = area.ToString();

            Invalidate();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Shapes == null)
                return;
            foreach (var s in Shapes)
            {
                if (s.Selected)
                {
                    if (s.ShapeFlag == 1)
                        copiedshape = new Rectangle { ShapeFlag = 1 };
                    else if (s.ShapeFlag == 2)
                        copiedshape = new Elipse { ShapeFlag = 2 };
                    else if (s.ShapeFlag == 3)
                        copiedshape = new isoscelesTrig { ShapeFlag = 3 };
                    else if (s.ShapeFlag == 4)
                        copiedshape = new RightTrig { ShapeFlag = 4 };
                    copiedshape.Fill = s.Fill;
                    copiedshape.Colorboarder = s.Colorboarder;
                    copiedshape.FrameHeight = s.FrameHeight;
                    copiedshape.FrameWidth = s.FrameWidth;
                    break;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ff = new FormFile(true);
            ff.SavedScene = Shapes;
            ff.ShowDialog();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ff = new FormFile(false);
            ff.ShowDialog();
            if (ff.SavedScene == null)
                return;
            Shapes = ff.SavedScene;
            Invalidate();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Shapes == null)
                return;
            Shapes.Clear();
            Invalidate();
        }

        private void selectByToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Shapes == null)
                return;
            var sb = new FormSelectBy();
            if (sb.ShowDialog() == DialogResult.OK)
            {
                foreach (var shape in Shapes
                    .Where(s => s.Fill == sb.FillColor || s.Colorboarder == sb.ColorBorder || s.ShapeFlag == sb.ShapeFlag))
                    shape.Selected = true;
                
            }
            Invalidate();
            
        }

        private void FormScene_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Do you wish to save this Scene",
                "Close Scene",
                MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                var ff = new FormFile(true);
                ff.SavedScene = Shapes;
                ff.ShowDialog();
            }
        }
        private void Choice(int flag)
        {

            if (flag == 1)
                newshape = new Rectangle { ShapeFlag = 1, Colorboarder = Color.Black, Fill = Color.White};
            else if (flag == 2)
                newshape= new Elipse { ShapeFlag = 2, Colorboarder = Color.Black, Fill = Color.White };
            else if (flag == 3)
                newshape = new isoscelesTrig { ShapeFlag = 3, Colorboarder = Color.Black, Fill = Color.White };
            else if (flag == 4)
                newshape = new RightTrig { ShapeFlag = 4, Colorboarder = Color.Black, Fill = Color.White };
            
        }
    }
}
