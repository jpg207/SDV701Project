﻿namespace AdminApp
{
    partial class frmBattleShip
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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTorpedoBulge = new System.Windows.Forms.NumericUpDown();
            this.txtHealAmount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.txtTorpedoBulge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHealAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Torpedo bulge %";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "Heal amount";
            // 
            // txtTorpedoBulge
            // 
            this.txtTorpedoBulge.Location = new System.Drawing.Point(97, 137);
            this.txtTorpedoBulge.Name = "txtTorpedoBulge";
            this.txtTorpedoBulge.Size = new System.Drawing.Size(120, 20);
            this.txtTorpedoBulge.TabIndex = 54;
            // 
            // txtHealAmount
            // 
            this.txtHealAmount.Location = new System.Drawing.Point(98, 166);
            this.txtHealAmount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtHealAmount.Name = "txtHealAmount";
            this.txtHealAmount.Size = new System.Drawing.Size(120, 20);
            this.txtHealAmount.TabIndex = 55;
            // 
            // frmBattleShip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(352, 245);
            this.Controls.Add(this.txtHealAmount);
            this.Controls.Add(this.txtTorpedoBulge);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Name = "frmBattleShip";
            this.Text = "BattleShip";
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtTorpedoBulge, 0);
            this.Controls.SetChildIndex(this.txtHealAmount, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtTorpedoBulge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHealAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown txtTorpedoBulge;
        private System.Windows.Forms.NumericUpDown txtHealAmount;
    }
}
