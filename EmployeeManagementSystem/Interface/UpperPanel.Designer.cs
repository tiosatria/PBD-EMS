namespace EmployeeManagementSystem.Interface
{
    partial class UpperPanel
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
            this.components = new System.ComponentModel.Container();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.picMoreMenu = new System.Windows.Forms.PictureBox();
            this.PicExit = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMoreMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicExit)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.guna2ShadowPanel1.Controls.Add(this.label2);
            this.guna2ShadowPanel1.Controls.Add(this.picMoreMenu);
            this.guna2ShadowPanel1.Controls.Add(this.PicExit);
            this.guna2ShadowPanel1.Controls.Add(this.label1);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(163)))), ((int)(((byte)(101)))));
            this.guna2ShadowPanel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(1280, 45);
            this.guna2ShadowPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Menu";
            this.label2.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // picMoreMenu
            // 
            this.picMoreMenu.BackColor = System.Drawing.Color.Transparent;
            this.picMoreMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMoreMenu.Image = global::EmployeeManagementSystem.Properties.Resources.icons8_view_more_64px;
            this.picMoreMenu.Location = new System.Drawing.Point(21, 9);
            this.picMoreMenu.Name = "picMoreMenu";
            this.picMoreMenu.Size = new System.Drawing.Size(29, 27);
            this.picMoreMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMoreMenu.TabIndex = 2;
            this.picMoreMenu.TabStop = false;
            this.picMoreMenu.MouseEnter += new System.EventHandler(this.picMoreMenu_MouseEnter);
            this.picMoreMenu.MouseLeave += new System.EventHandler(this.picMoreMenu_MouseLeave);
            // 
            // PicExit
            // 
            this.PicExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(163)))), ((int)(((byte)(101)))));
            this.PicExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicExit.Image = global::EmployeeManagementSystem.Properties.Resources.icons8_shutdown_64px;
            this.PicExit.Location = new System.Drawing.Point(1223, 9);
            this.PicExit.Name = "PicExit";
            this.PicExit.Size = new System.Drawing.Size(29, 27);
            this.PicExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicExit.TabIndex = 1;
            this.PicExit.TabStop = false;
            this.PicExit.Click += new System.EventHandler(this.PicExit_Click);
            this.PicExit.MouseEnter += new System.EventHandler(this.PicExit_MouseEnter);
            this.PicExit.MouseLeave += new System.EventHandler(this.PicExit_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(163)))), ((int)(((byte)(101)))));
            this.label1.Location = new System.Drawing.Point(549, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Management";
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.guna2ShadowPanel1;
            // 
            // UpperPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "UpperPanel";
            this.Size = new System.Drawing.Size(1280, 45);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMoreMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.PictureBox PicExit;
        private System.Windows.Forms.PictureBox picMoreMenu;
        private System.Windows.Forms.Label label2;
    }
}
