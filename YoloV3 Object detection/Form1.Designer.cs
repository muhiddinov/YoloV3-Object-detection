namespace YoloV3_Object_detection
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.faylToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cUDNNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yOLO3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabel_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox_image = new System.Windows.Forms.PictureBox();
            this.btn_open = new System.Windows.Forms.Button();
            this.btn_detect = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_image)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.faylToolStripMenuItem,
            this.cUDNNToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // faylToolStripMenuItem
            // 
            this.faylToolStripMenuItem.Name = "faylToolStripMenuItem";
            this.faylToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.faylToolStripMenuItem.Text = "Fayl";
            // 
            // cUDNNToolStripMenuItem
            // 
            this.cUDNNToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yOLO3ToolStripMenuItem});
            this.cUDNNToolStripMenuItem.Name = "cUDNNToolStripMenuItem";
            this.cUDNNToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.cUDNNToolStripMenuItem.Text = "DNN";
            // 
            // yOLO3ToolStripMenuItem
            // 
            this.yOLO3ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadModelToolStripMenuItem,
            this.testModelToolStripMenuItem});
            this.yOLO3ToolStripMenuItem.Name = "yOLO3ToolStripMenuItem";
            this.yOLO3ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.yOLO3ToolStripMenuItem.Text = "YOLO 3";
            // 
            // loadModelToolStripMenuItem
            // 
            this.loadModelToolStripMenuItem.Name = "loadModelToolStripMenuItem";
            this.loadModelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadModelToolStripMenuItem.Text = "Load model";
            this.loadModelToolStripMenuItem.Click += new System.EventHandler(this.loadModelToolStripMenuItem_Click);
            // 
            // testModelToolStripMenuItem
            // 
            this.testModelToolStripMenuItem.Name = "testModelToolStripMenuItem";
            this.testModelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.testModelToolStripMenuItem.Text = "Test model";
            this.testModelToolStripMenuItem.Click += new System.EventHandler(this.testModelToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripLabel_status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // toolStripLabel_status
            // 
            this.toolStripLabel_status.Name = "toolStripLabel_status";
            this.toolStripLabel_status.Size = new System.Drawing.Size(82, 17);
            this.toolStripLabel_status.Text = "Select weigths";
            // 
            // pictureBox_image
            // 
            this.pictureBox_image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_image.Location = new System.Drawing.Point(12, 27);
            this.pictureBox_image.Name = "pictureBox_image";
            this.pictureBox_image.Size = new System.Drawing.Size(560, 398);
            this.pictureBox_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_image.TabIndex = 2;
            this.pictureBox_image.TabStop = false;
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(658, 27);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(75, 23);
            this.btn_open.TabIndex = 3;
            this.btn_open.Text = "File open";
            this.btn_open.UseVisualStyleBackColor = true;
            // 
            // btn_detect
            // 
            this.btn_detect.Location = new System.Drawing.Point(658, 56);
            this.btn_detect.Name = "btn_detect";
            this.btn_detect.Size = new System.Drawing.Size(75, 23);
            this.btn_detect.TabIndex = 4;
            this.btn_detect.Text = "Detect";
            this.btn_detect.UseVisualStyleBackColor = true;
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(658, 85);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 5;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_detect);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.pictureBox_image);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem faylToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cUDNNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yOLO3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testModelToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabel_status;
        private System.Windows.Forms.PictureBox pictureBox_image;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button btn_detect;
        private System.Windows.Forms.Button btn_clear;
    }
}

