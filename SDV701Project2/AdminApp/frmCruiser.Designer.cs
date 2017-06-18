namespace AdminApp
{
    partial class frmCruiser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPlaneType = new System.Windows.Forms.TextBox();
            this.txtTorpTubes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Torpedo tubes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "Plane type";
            // 
            // txtPlaneType
            // 
            this.txtPlaneType.Location = new System.Drawing.Point(97, 163);
            this.txtPlaneType.Name = "txtPlaneType";
            this.txtPlaneType.Size = new System.Drawing.Size(100, 20);
            this.txtPlaneType.TabIndex = 52;
            // 
            // txtTorpTubes
            // 
            this.txtTorpTubes.Location = new System.Drawing.Point(97, 137);
            this.txtTorpTubes.Name = "txtTorpTubes";
            this.txtTorpTubes.Size = new System.Drawing.Size(100, 20);
            this.txtTorpTubes.TabIndex = 55;
            // 
            // frmCruiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(352, 245);
            this.Controls.Add(this.txtTorpTubes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPlaneType);
            this.Controls.Add(this.label5);
            this.Name = "frmCruiser";
            this.Text = "Cruiser";
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtPlaneType, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtTorpTubes, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPlaneType;
        private System.Windows.Forms.TextBox txtTorpTubes;
    }
}
