namespace PPE___Lab_6__
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.nameLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.groupLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.groupTextBox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.displayTextBox = new System.Windows.Forms.TextBox();
            this.displayButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.BgColorButton = new System.Windows.Forms.Button();
            this.textBoldButton = new System.Windows.Forms.Button();
            this.ObliqueTextButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(48, 70);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(53, 16);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name:";
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.surnameLabel.Location = new System.Drawing.Point(48, 93);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(73, 16);
            this.surnameLabel.TabIndex = 2;
            this.surnameLabel.Text = "Surname:";
            // 
            // groupLabel
            // 
            this.groupLabel.AutoSize = true;
            this.groupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupLabel.Location = new System.Drawing.Point(48, 115);
            this.groupLabel.Name = "groupLabel";
            this.groupLabel.Size = new System.Drawing.Size(54, 16);
            this.groupLabel.TabIndex = 3;
            this.groupLabel.Text = "Group:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(129, 66);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(178, 20);
            this.nameTextBox.TabIndex = 4;
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(129, 89);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(178, 20);
            this.surnameTextBox.TabIndex = 5;
            // 
            // groupTextBox
            // 
            this.groupTextBox.Location = new System.Drawing.Point(129, 114);
            this.groupTextBox.Name = "groupTextBox";
            this.groupTextBox.Size = new System.Drawing.Size(178, 20);
            this.groupTextBox.TabIndex = 6;
            // 
            // generateButton
            // 
            this.generateButton.BackColor = System.Drawing.Color.Lime;
            this.generateButton.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateButton.ForeColor = System.Drawing.Color.DarkRed;
            this.generateButton.Location = new System.Drawing.Point(142, 151);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(134, 45);
            this.generateButton.TabIndex = 7;
            this.generateButton.Text = "GENERATE";
            this.generateButton.UseVisualStyleBackColor = false;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // displayTextBox
            // 
            this.displayTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.displayTextBox.Font = new System.Drawing.Font("Papyrus", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.displayTextBox.Location = new System.Drawing.Point(51, 202);
            this.displayTextBox.Multiline = true;
            this.displayTextBox.Name = "displayTextBox";
            this.displayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.displayTextBox.Size = new System.Drawing.Size(299, 78);
            this.displayTextBox.TabIndex = 8;
            // 
            // displayButton
            // 
            this.displayButton.BackColor = System.Drawing.Color.Black;
            this.displayButton.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayButton.ForeColor = System.Drawing.Color.Gold;
            this.displayButton.Location = new System.Drawing.Point(184, 286);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(138, 37);
            this.displayButton.TabIndex = 9;
            this.displayButton.Text = "Display Text";
            this.displayButton.UseVisualStyleBackColor = false;
            this.displayButton.Click += new System.EventHandler(this.displayButton_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.infoLabel.Location = new System.Drawing.Point(184, 34);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(64, 18);
            this.infoLabel.TabIndex = 11;
            this.infoLabel.Text = "info text";
            // 
            // BgColorButton
            // 
            this.BgColorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BgColorButton.Location = new System.Drawing.Point(437, 190);
            this.BgColorButton.Name = "BgColorButton";
            this.BgColorButton.Size = new System.Drawing.Size(125, 31);
            this.BgColorButton.TabIndex = 12;
            this.BgColorButton.Text = "Background Color";
            this.BgColorButton.UseVisualStyleBackColor = true;
            this.BgColorButton.Click += new System.EventHandler(this.BgColorButton_Click);
            // 
            // textBoldButton
            // 
            this.textBoldButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoldButton.Location = new System.Drawing.Point(437, 227);
            this.textBoldButton.Name = "textBoldButton";
            this.textBoldButton.Size = new System.Drawing.Size(125, 30);
            this.textBoldButton.TabIndex = 13;
            this.textBoldButton.Text = "Bold Text";
            this.textBoldButton.UseVisualStyleBackColor = true;
            this.textBoldButton.Click += new System.EventHandler(this.textBoldButton_Click);
            // 
            // ObliqueTextButton
            // 
            this.ObliqueTextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ObliqueTextButton.Location = new System.Drawing.Point(437, 263);
            this.ObliqueTextButton.Name = "ObliqueTextButton";
            this.ObliqueTextButton.Size = new System.Drawing.Size(125, 28);
            this.ObliqueTextButton.TabIndex = 14;
            this.ObliqueTextButton.Text = "Italic Text";
            this.ObliqueTextButton.UseVisualStyleBackColor = true;
            this.ObliqueTextButton.Click += new System.EventHandler(this.ObliqueTextButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(584, 341);
            this.Controls.Add(this.ObliqueTextButton);
            this.Controls.Add(this.textBoldButton);
            this.Controls.Add(this.BgColorButton);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.displayButton);
            this.Controls.Add(this.displayTextBox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.groupTextBox);
            this.Controls.Add(this.surnameTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.groupLabel);
            this.Controls.Add(this.surnameLabel);
            this.Controls.Add(this.nameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(700, 400);
            this.MinimumSize = new System.Drawing.Size(580, 370);
            this.Name = "Form1";
            this.Text = "PPE [ Lab-6 ]";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.Label groupLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox groupTextBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox displayTextBox;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button BgColorButton;
        private System.Windows.Forms.Button textBoldButton;
        private System.Windows.Forms.Button ObliqueTextButton;
    }
}

