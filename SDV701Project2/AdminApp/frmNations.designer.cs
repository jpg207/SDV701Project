namespace AdminApp
{
    partial class frmNations
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
            this.lblValue = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.lstNation = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblValue
            // 
            this.lblValue.Location = new System.Drawing.Point(87, 219);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(71, 24);
            this.lblValue.TabIndex = 13;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(17, 221);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 16);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "Total Value";
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(164, 211);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(80, 32);
            this.btnQuit.TabIndex = 11;
            this.btnQuit.Text = "Quit";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(17, 13);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(43, 13);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Nation";
            // 
            // lstNation
            // 
            this.lstNation.Location = new System.Drawing.Point(17, 29);
            this.lstNation.Name = "lstNation";
            this.lstNation.Size = new System.Drawing.Size(227, 173);
            this.lstNation.TabIndex = 7;
            this.lstNation.SelectedIndexChanged += new System.EventHandler(this.lstArtists_SelectedIndexChanged);
            this.lstNation.DoubleClick += new System.EventHandler(this.lstNations_DoubleClick);
            // 
            // frmNations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 253);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lstNation);
            this.Name = "frmNations";
            this.Text = "Nations list";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblValue;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnQuit;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ListBox lstNation;
    }
}

