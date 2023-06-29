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
    public partial class FormSelectBy : Form
    {
        
        public Color FillColor => buttonFill.BackColor;
        public Color ColorBorder => buttonBorder.BackColor;
        public int ShapeFlag { get; set; }
        public FormSelectBy()
        {
            InitializeComponent();
        }

        private void buttonBorder_Click(object sender, EventArgs e)
        {
            var ch = new ColorDialog();

            if (ch.ShowDialog() == DialogResult.OK)
                buttonBorder.BackColor = ch.Color;
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
                buttonFill.BackColor = cd.Color;
        }

        private void buttonCencel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

       

        private void FormSelectBy_Load(object sender, EventArgs e)
        {
            List<SelectByShape> ShapesTypes = new List<SelectByShape>();
            ShapesTypes.Add(new SelectByShape() { Shapeflag = 1, ShapeName = "Rectangle" });
            ShapesTypes.Add(new SelectByShape() { Shapeflag = 2, ShapeName = "Ellipse" });
            ShapesTypes.Add(new SelectByShape() { Shapeflag = 3, ShapeName = "Isosceles Triangle" });
            ShapesTypes.Add(new SelectByShape() { Shapeflag = 4, ShapeName = "Right Triangle" });
            comboBoxShapes.DataSource = ShapesTypes;
            comboBoxShapes.DisplayMember = "ShapeName";
            comboBoxShapes.ValueMember = "Shapeflag";
        }

        private void comboBoxShapes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectByShape selectByShape = (SelectByShape)comboBoxShapes.SelectedItem;
            ShapeFlag = selectByShape.Shapeflag;
        }
    }
}
