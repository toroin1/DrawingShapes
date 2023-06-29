
namespace SemesterProjectShapes
{
    partial class FormFile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCencel = new System.Windows.Forms.Button();
            this.buttonLoadSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCencel
            // 
            this.buttonCencel.Location = new System.Drawing.Point(12, 24);
            this.buttonCencel.Name = "buttonCencel";
            this.buttonCencel.Size = new System.Drawing.Size(86, 23);
            this.buttonCencel.TabIndex = 0;
            this.buttonCencel.Text = "Cencel";
            this.buttonCencel.UseVisualStyleBackColor = true;
            this.buttonCencel.Click += new System.EventHandler(this.buttonCencel_Click);
            // 
            // buttonLoadSave
            // 
            this.buttonLoadSave.Location = new System.Drawing.Point(126, 24);
            this.buttonLoadSave.Name = "buttonLoadSave";
            this.buttonLoadSave.Size = new System.Drawing.Size(86, 23);
            this.buttonLoadSave.TabIndex = 1;
            this.buttonLoadSave.Text = "button2";
            this.buttonLoadSave.UseVisualStyleBackColor = true;
            this.buttonLoadSave.Click += new System.EventHandler(this.buttonLoadSave_Click);
            // 
            // FormFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 61);
            this.Controls.Add(this.buttonLoadSave);
            this.Controls.Add(this.buttonCencel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFile";
            this.Text = "File";
            this.Load += new System.EventHandler(this.FormFile_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCencel;
        private System.Windows.Forms.Button buttonLoadSave;
    }
}