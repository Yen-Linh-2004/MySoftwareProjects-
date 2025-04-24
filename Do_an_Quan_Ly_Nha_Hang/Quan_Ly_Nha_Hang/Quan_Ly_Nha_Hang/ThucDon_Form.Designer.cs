namespace Quan_Ly_Nha_Hang
{
    partial class ThucDon_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThucDon_Form));
            this.ThucDon_panel = new System.Windows.Forms.Panel();
            this.btn_Back = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // ThucDon_panel
            // 
            this.ThucDon_panel.Location = new System.Drawing.Point(1, 153);
            this.ThucDon_panel.Name = "ThucDon_panel";
            this.ThucDon_panel.Size = new System.Drawing.Size(2176, 1422);
            this.ThucDon_panel.TabIndex = 20;
            // 
            // btn_Back
            // 
            this.btn_Back.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btn_Back.HoverState.ImageSize = new System.Drawing.Size(43, 43);
            this.btn_Back.Image = ((System.Drawing.Image)(resources.GetObject("btn_Back.Image")));
            this.btn_Back.ImageOffset = new System.Drawing.Point(0, 0);
            this.btn_Back.ImageRotate = 0F;
            this.btn_Back.ImageSize = new System.Drawing.Size(42, 42);
            this.btn_Back.Location = new System.Drawing.Point(2006, 44);
            this.btn_Back.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.PressedState.ImageSize = new System.Drawing.Size(43, 43);
            this.btn_Back.Size = new System.Drawing.Size(102, 100);
            this.btn_Back.TabIndex = 19;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // ThucDon_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(2169, 1573);
            this.Controls.Add(this.ThucDon_panel);
            this.Controls.Add(this.btn_Back);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ThucDon_Form";
            this.Text = "ThucDon_Form";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ImageButton btn_Back;
        private System.Windows.Forms.Panel ThucDon_panel;
    }
}