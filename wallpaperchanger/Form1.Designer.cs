namespace wallpaperchanger
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.wallpaperCategory = new System.Windows.Forms.TextBox();
            this.updateCategory = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFolder = new System.Windows.Forms.TextBox();
            this.updateSaveFolder = new System.Windows.Forms.Button();
            this.rotationTimeLabel = new System.Windows.Forms.Label();
            this.rotationTime = new System.Windows.Forms.ComboBox();
            this.updateRotationTime = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.manualChangeWallpaper = new System.Windows.Forms.Button();
            this.ChooseFolder = new System.Windows.Forms.Button();
            this.UpdateResolution = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ResolutionHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ResolutionWidth = new System.Windows.Forms.TextBox();
            this.GetCurrentResolution = new System.Windows.Forms.Button();
            this.ToggleRotation = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wallpaper Category";
            // 
            // wallpaperCategory
            // 
            this.wallpaperCategory.Location = new System.Drawing.Point(20, 70);
            this.wallpaperCategory.Margin = new System.Windows.Forms.Padding(4);
            this.wallpaperCategory.Name = "wallpaperCategory";
            this.wallpaperCategory.Size = new System.Drawing.Size(377, 22);
            this.wallpaperCategory.TabIndex = 1;
            // 
            // updateCategory
            // 
            this.updateCategory.Location = new System.Drawing.Point(23, 102);
            this.updateCategory.Margin = new System.Windows.Forms.Padding(4);
            this.updateCategory.Name = "updateCategory";
            this.updateCategory.Size = new System.Drawing.Size(100, 28);
            this.updateCategory.TabIndex = 2;
            this.updateCategory.Text = "Update";
            this.updateCategory.UseVisualStyleBackColor = true;
            this.updateCategory.Click += new System.EventHandler(this.updateCategory_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 160);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Save directory";
            // 
            // saveFolder
            // 
            this.saveFolder.Location = new System.Drawing.Point(20, 180);
            this.saveFolder.Margin = new System.Windows.Forms.Padding(4);
            this.saveFolder.Name = "saveFolder";
            this.saveFolder.Size = new System.Drawing.Size(348, 22);
            this.saveFolder.TabIndex = 4;
            // 
            // updateSaveFolder
            // 
            this.updateSaveFolder.Location = new System.Drawing.Point(23, 212);
            this.updateSaveFolder.Margin = new System.Windows.Forms.Padding(4);
            this.updateSaveFolder.Name = "updateSaveFolder";
            this.updateSaveFolder.Size = new System.Drawing.Size(100, 28);
            this.updateSaveFolder.TabIndex = 5;
            this.updateSaveFolder.Text = "Update";
            this.updateSaveFolder.UseVisualStyleBackColor = true;
            this.updateSaveFolder.Click += new System.EventHandler(this.updateSaveFolder_Click);
            // 
            // rotationTimeLabel
            // 
            this.rotationTimeLabel.AutoSize = true;
            this.rotationTimeLabel.Location = new System.Drawing.Point(19, 372);
            this.rotationTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rotationTimeLabel.Name = "rotationTimeLabel";
            this.rotationTimeLabel.Size = new System.Drawing.Size(91, 17);
            this.rotationTimeLabel.TabIndex = 6;
            this.rotationTimeLabel.Text = "Rotation time";
            // 
            // rotationTime
            // 
            this.rotationTime.FormattingEnabled = true;
            this.rotationTime.Location = new System.Drawing.Point(20, 391);
            this.rotationTime.Margin = new System.Windows.Forms.Padding(4);
            this.rotationTime.Name = "rotationTime";
            this.rotationTime.Size = new System.Drawing.Size(165, 24);
            this.rotationTime.TabIndex = 7;
            this.rotationTime.SelectedIndexChanged += new System.EventHandler(this.rotationTime_SelectedIndexChanged);
            // 
            // updateRotationTime
            // 
            this.updateRotationTime.Location = new System.Drawing.Point(23, 425);
            this.updateRotationTime.Margin = new System.Windows.Forms.Padding(4);
            this.updateRotationTime.Name = "updateRotationTime";
            this.updateRotationTime.Size = new System.Drawing.Size(100, 28);
            this.updateRotationTime.TabIndex = 8;
            this.updateRotationTime.Text = "Update";
            this.updateRotationTime.UseVisualStyleBackColor = true;
            this.updateRotationTime.Click += new System.EventHandler(this.updateRotationTime_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(320, 554);
            this.okBtn.Margin = new System.Windows.Forms.Padding(4);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(100, 28);
            this.okBtn.TabIndex = 9;
            this.okBtn.Text = "Close";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // manualChangeWallpaper
            // 
            this.manualChangeWallpaper.Location = new System.Drawing.Point(16, 554);
            this.manualChangeWallpaper.Margin = new System.Windows.Forms.Padding(4);
            this.manualChangeWallpaper.Name = "manualChangeWallpaper";
            this.manualChangeWallpaper.Size = new System.Drawing.Size(164, 33);
            this.manualChangeWallpaper.TabIndex = 10;
            this.manualChangeWallpaper.Text = "Manual Change";
            this.manualChangeWallpaper.UseVisualStyleBackColor = true;
            this.manualChangeWallpaper.Click += new System.EventHandler(this.manualChangeWallpaper_Click);
            // 
            // ChooseFolder
            // 
            this.ChooseFolder.Location = new System.Drawing.Point(377, 180);
            this.ChooseFolder.Margin = new System.Windows.Forms.Padding(4);
            this.ChooseFolder.Name = "ChooseFolder";
            this.ChooseFolder.Size = new System.Drawing.Size(43, 28);
            this.ChooseFolder.TabIndex = 11;
            this.ChooseFolder.Text = "...";
            this.ChooseFolder.UseVisualStyleBackColor = true;
            this.ChooseFolder.Click += new System.EventHandler(this.ChooseFolder_Click);
            // 
            // UpdateResolution
            // 
            this.UpdateResolution.Location = new System.Drawing.Point(23, 315);
            this.UpdateResolution.Margin = new System.Windows.Forms.Padding(4);
            this.UpdateResolution.Name = "UpdateResolution";
            this.UpdateResolution.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UpdateResolution.Size = new System.Drawing.Size(100, 28);
            this.UpdateResolution.TabIndex = 12;
            this.UpdateResolution.Text = "Update";
            this.UpdateResolution.UseVisualStyleBackColor = true;
            this.UpdateResolution.Click += new System.EventHandler(this.UpdateResolution_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 263);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Height";
            // 
            // ResolutionHeight
            // 
            this.ResolutionHeight.Location = new System.Drawing.Point(159, 284);
            this.ResolutionHeight.Margin = new System.Windows.Forms.Padding(4);
            this.ResolutionHeight.Name = "ResolutionHeight";
            this.ResolutionHeight.Size = new System.Drawing.Size(115, 22);
            this.ResolutionHeight.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 263);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Width";
            // 
            // ResolutionWidth
            // 
            this.ResolutionWidth.Location = new System.Drawing.Point(23, 283);
            this.ResolutionWidth.Margin = new System.Windows.Forms.Padding(4);
            this.ResolutionWidth.Name = "ResolutionWidth";
            this.ResolutionWidth.Size = new System.Drawing.Size(115, 22);
            this.ResolutionWidth.TabIndex = 16;
            // 
            // GetCurrentResolution
            // 
            this.GetCurrentResolution.Location = new System.Drawing.Point(281, 283);
            this.GetCurrentResolution.Name = "GetCurrentResolution";
            this.GetCurrentResolution.Size = new System.Drawing.Size(104, 23);
            this.GetCurrentResolution.TabIndex = 17;
            this.GetCurrentResolution.Text = "Automatic";
            this.GetCurrentResolution.UseVisualStyleBackColor = true;
            this.GetCurrentResolution.Click += new System.EventHandler(this.Automatic);
            // 
            // ToggleRotation
            // 
            this.ToggleRotation.Location = new System.Drawing.Point(16, 497);
            this.ToggleRotation.Name = "ToggleRotation";
            this.ToggleRotation.Size = new System.Drawing.Size(164, 32);
            this.ToggleRotation.TabIndex = 18;
            this.ToggleRotation.Text = "Start Rotation";
            this.ToggleRotation.UseVisualStyleBackColor = true;
            this.ToggleRotation.Click += new System.EventHandler(this.ToggleRotation_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 477);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Toggle rotation";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 603);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ToggleRotation);
            this.Controls.Add(this.GetCurrentResolution);
            this.Controls.Add(this.ResolutionWidth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ResolutionHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UpdateResolution);
            this.Controls.Add(this.ChooseFolder);
            this.Controls.Add(this.manualChangeWallpaper);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.updateRotationTime);
            this.Controls.Add(this.rotationTime);
            this.Controls.Add(this.rotationTimeLabel);
            this.Controls.Add(this.updateSaveFolder);
            this.Controls.Add(this.saveFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.updateCategory);
            this.Controls.Add(this.wallpaperCategory);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Wallpaper Changer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox wallpaperCategory;
        private System.Windows.Forms.Button updateCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox saveFolder;
        private System.Windows.Forms.Button updateSaveFolder;
        private System.Windows.Forms.Label rotationTimeLabel;
        private System.Windows.Forms.ComboBox rotationTime;
        private System.Windows.Forms.Button updateRotationTime;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button manualChangeWallpaper;
        private System.Windows.Forms.Button ChooseFolder;
        private System.Windows.Forms.Button UpdateResolution;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ResolutionHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ResolutionWidth;
        private System.Windows.Forms.Button GetCurrentResolution;
        private System.Windows.Forms.Button ToggleRotation;
        private System.Windows.Forms.Label label5;
    }
}

