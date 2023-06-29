using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemesterProjectShapes
{
    public partial class FormProperties : Form
    {
        public Shape Shape { get; set; }
        public Color Color => buttonColorBorder.BackColor;
        public FormProperties()
        {
            InitializeComponent();
        }

        private void FormProperties_Load(object sender, EventArgs e)
        {
            if(Shape.ShapeFlag == 1)
            {
                
                labelHeight.Text = "Height";
                labelWidth.Text = "Width";
            }
            else if(Shape.ShapeFlag == 2)
            {
                textBoxHeight.Text = (Shape.FrameHeight/2).ToString();
                textBoxWidth.Text = (Shape.FrameWidth/2).ToString();
                labelHeight.Text = "RadiusH";
                labelWidth.Text = "RadiusW";
            }
            else if(Shape.ShapeFlag == 3 | Shape.ShapeFlag == 4)
            {
                
                labelHeight.Text = "Height";
                labelWidth.Text = "Base";
            }
            textBoxHeight.Text = Shape.FrameHeight.ToString();
            textBoxWidth.Text = Shape.FrameWidth.ToString();
            buttonColorBorder.BackColor = Shape.Colorboarder;
            buttonColorFill.BackColor = Shape.Fill;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if(Shape.ShapeFlag == 2)
            {
                Shape.FrameHeight = int.Parse(textBoxHeight.Text) * 2;
                Shape.FrameWidth = int.Parse(textBoxWidth.Text) * 2;
            }
            Shape.FrameHeight = int.Parse(textBoxHeight.Text);
            Shape.FrameWidth = int.Parse(textBoxWidth.Text);
            Shape.Colorboarder = buttonColorBorder.BackColor;
            Shape.Fill = buttonColorFill.BackColor;
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonColorBorder_Click(object sender, EventArgs e)
        {
            var ch = new ColorDialog();

            if (ch.ShowDialog() == DialogResult.OK)
                buttonColorBorder.BackColor = ch.Color;
        }

        private void buttonColorFill_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
                buttonColorFill.BackColor = cd.Color;
        }
    }
}
