namespace AdminApp
{
    partial class frmNation
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.lstShips = new System.Windows.Forms.ListBox();
            this.lblNation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(155, 233);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(72, 16);
            this.lblTotal.TabIndex = 27;
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(75, 233);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(64, 16);
            this.Label5.TabIndex = 26;
            this.Label5.Text = "Total Value";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(171, 257);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 32);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(91, 257);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 32);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(11, 257);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 32);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(5, 31);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(53, 12);
            this.Label4.TabIndex = 21;
            this.Label4.Text = "Ships";
            // 
            // lstShips
            // 
            this.lstShips.Location = new System.Drawing.Point(11, 46);
            this.lstShips.Name = "lstShips";
            this.lstShips.Size = new System.Drawing.Size(224, 173);
            this.lstShips.TabIndex = 20;
            this.lstShips.DoubleClick += new System.EventHandler(this.lstWorks_DoubleClick);
            // 
            // lblNation
            // 
            this.lblNation.Location = new System.Drawing.Point(5, 9);
            this.lblNation.Name = "lblNation";
            this.lblNation.Size = new System.Drawing.Size(64, 16);
            this.lblNation.TabIndex = 14;
            this.lblNation.Text = "Name";
            // 
            // frmNation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 299);
            this.ControlBox = false;
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.lstShips);
            this.Controls.Add(this.lblNation);
            this.Name = "frmNation";
            this.Text = "Nations ships";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblTotal;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ListBox lstShips;
        internal System.Windows.Forms.Label lblNation;
    }
}