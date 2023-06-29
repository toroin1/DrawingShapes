using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemesterProjectShapes
{
    public partial class FormFile : Form
    {
        public List<Shape> SavedScene { get; set; }
        private bool Save;
        public FormFile(bool save)
        {
            Save = save;
            InitializeComponent();
        }

        private void buttonCencel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonLoadSave_Click(object sender, EventArgs e)
        {
            var formsetter = new BinaryFormatter();
            if (Save)
            {
                using (var stream = new FileStream("save", FileMode.Create))
                {
                    formsetter.Serialize(stream, SavedScene);
                }
            }
            else
            {
                if (!File.Exists("save"))
                    return;
                using (var stream = new FileStream("save", FileMode.Open))
                {
                    SavedScene = (List<Shape>)formsetter.Deserialize(stream);
                }
            }
            DialogResult = DialogResult.OK;
        }

        private void FormFile_Load(object sender, EventArgs e)
        {
            if (Save)
                buttonLoadSave.Text = "Save";
            else
                buttonLoadSave.Text = "Load";
        }
    }
}
