namespace Quan_Ly_Nha_Hang
{
    partial class MonAn_ForThucDon_UserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_TenMon = new System.Windows.Forms.Label();
            this.txt_GiaMon = new System.Windows.Forms.Label();
            this.img_MonAn = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.img_MonAn)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_TenMon
            // 
            this.txt_TenMon.AutoSize = true;
            this.txt_TenMon.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenMon.ForeColor = System.Drawing.Color.White;
            this.txt_TenMon.Location = new System.Drawing.Point(22, 348);
            this.txt_TenMon.Name = "txt_TenMon";
            this.txt_TenMon.Size = new System.Drawing.Size(154, 39);
            this.txt_TenMon.TabIndex = 1;
            this.txt_TenMon.Text = "Tên Món";
            this.txt_TenMon.Click += new System.EventHandler(this.MonAn_ForThucDon_UserControl_Click);
            // 
            // txt_GiaMon
            // 
            this.txt_GiaMon.AutoSize = true;
            this.txt_GiaMon.Font = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_GiaMon.ForeColor = System.Drawing.Color.White;
            this.txt_GiaMon.Location = new System.Drawing.Point(23, 408);
            this.txt_GiaMon.Name = "txt_GiaMon";
            this.txt_GiaMon.Size = new System.Drawing.Size(125, 33);
            this.txt_GiaMon.TabIndex = 2;
            this.txt_GiaMon.Text = "120.000";
            this.txt_GiaMon.Click += new System.EventHandler(this.MonAn_ForThucDon_UserControl_Click);
            // 
            // img_MonAn
            // 
            this.img_MonAn.BackColor = System.Drawing.Color.White;
            this.img_MonAn.ErrorImage = global::Quan_Ly_Nha_Hang.Properties.Resources.Tôm_Hùm;
            this.img_MonAn.ImageRotate = 0F;
            this.img_MonAn.Location = new System.Drawing.Point(0, 0);
            this.img_MonAn.Name = "img_MonAn";
            this.img_MonAn.Size = new System.Drawing.Size(339, 315);
            this.img_MonAn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_MonAn.TabIndex = 0;
            this.img_MonAn.TabStop = false;
            this.img_MonAn.Click += new System.EventHandler(this.MonAn_ForThucDon_UserControl_Click);
            // 
            // MonAn_ForThucDon_UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.txt_GiaMon);
            this.Controls.Add(this.txt_TenMon);
            this.Controls.Add(this.img_MonAn);
            this.Margin = new System.Windows.Forms.Padding(12);
            this.Name = "MonAn_ForThucDon_UserControl";
            this.Size = new System.Drawing.Size(339, 476);
            this.Click += new System.EventHandler(this.MonAn_ForThucDon_UserControl_Click);
            ((System.ComponentModel.ISupportInitialize)(this.img_MonAn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label txt_TenMon;
        private System.Windows.Forms.Label txt_GiaMon;
        private Guna.UI2.WinForms.Guna2PictureBox img_MonAn;
    }
}
