namespace PPE_Lab3
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
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSaveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripColorButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownWidthButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownShapesButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawBezierCurveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleWithGradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownFilledButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.drawFilledObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawNotFilledObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownEraserButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripClearButton = new System.Windows.Forms.ToolStripButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.linesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.Color.White;
            this.Canvas.Location = new System.Drawing.Point(12, 40);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(683, 316);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSaveButton,
            this.toolStripColorButton,
            this.toolStripDropDownWidthButton,
            this.toolStripDropDownShapesButton,
            this.toolStripDropDownFilledButton,
            this.toolStripDropDownEraserButton,
            this.toolStripClearButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(707, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSaveButton
            // 
            this.toolStripSaveButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSaveButton.Image")));
            this.toolStripSaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSaveButton.Name = "toolStripSaveButton";
            this.toolStripSaveButton.Size = new System.Drawing.Size(51, 22);
            this.toolStripSaveButton.Text = "Save";
            this.toolStripSaveButton.Click += new System.EventHandler(this.toolStripSaveButton_Click);
            // 
            // toolStripColorButton
            // 
            this.toolStripColorButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripColorButton.Image")));
            this.toolStripColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripColorButton.Name = "toolStripColorButton";
            this.toolStripColorButton.Size = new System.Drawing.Size(61, 22);
            this.toolStripColorButton.Text = "Colors";
            this.toolStripColorButton.Click += new System.EventHandler(this.toolStripColorButton_Click);
            // 
            // toolStripDropDownWidthButton
            // 
            this.toolStripDropDownWidthButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownWidthButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.toolStripDropDownWidthButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownWidthButton.Image")));
            this.toolStripDropDownWidthButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownWidthButton.Name = "toolStripDropDownWidthButton";
            this.toolStripDropDownWidthButton.Size = new System.Drawing.Size(96, 22);
            this.toolStripDropDownWidthButton.Text = "Change Width";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem2.Text = "1";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem3.Text = "5";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem4.Text = "10";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem5.Text = "15";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem6.Text = "20";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripDropDownShapesButton
            // 
            this.toolStripDropDownShapesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownShapesButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem,
            this.squareToolStripMenuItem,
            this.circleToolStripMenuItem,
            this.triangleToolStripMenuItem,
            this.drawBezierCurveToolStripMenuItem,
            this.rectangleWithGradientToolStripMenuItem,
            this.linesToolStripMenuItem});
            this.toolStripDropDownShapesButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownShapesButton.Image")));
            this.toolStripDropDownShapesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownShapesButton.Name = "toolStripDropDownShapesButton";
            this.toolStripDropDownShapesButton.Size = new System.Drawing.Size(57, 22);
            this.toolStripDropDownShapesButton.Text = "Shapes";
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.lineToolStripMenuItem.Text = "Paint";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // squareToolStripMenuItem
            // 
            this.squareToolStripMenuItem.Name = "squareToolStripMenuItem";
            this.squareToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.squareToolStripMenuItem.Text = "Rectangle";
            this.squareToolStripMenuItem.Click += new System.EventHandler(this.squareToolStripMenuItem_Click);
            // 
            // circleToolStripMenuItem
            // 
            this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            this.circleToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.circleToolStripMenuItem.Text = "Circle";
            this.circleToolStripMenuItem.Click += new System.EventHandler(this.circleToolStripMenuItem_Click);
            // 
            // triangleToolStripMenuItem
            // 
            this.triangleToolStripMenuItem.Name = "triangleToolStripMenuItem";
            this.triangleToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.triangleToolStripMenuItem.Text = "Triangle";
            this.triangleToolStripMenuItem.Click += new System.EventHandler(this.triangleToolStripMenuItem_Click);
            // 
            // drawBezierCurveToolStripMenuItem
            // 
            this.drawBezierCurveToolStripMenuItem.Name = "drawBezierCurveToolStripMenuItem";
            this.drawBezierCurveToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.drawBezierCurveToolStripMenuItem.Text = "Draw BezierCurve";
            this.drawBezierCurveToolStripMenuItem.Click += new System.EventHandler(this.drawBezierCurveToolStripMenuItem_Click);
            // 
            // rectangleWithGradientToolStripMenuItem
            // 
            this.rectangleWithGradientToolStripMenuItem.Name = "rectangleWithGradientToolStripMenuItem";
            this.rectangleWithGradientToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.rectangleWithGradientToolStripMenuItem.Text = "RectangleWithGradient";
            this.rectangleWithGradientToolStripMenuItem.Click += new System.EventHandler(this.rectangleWithGradientToolStripMenuItem_Click);
            // 
            // toolStripDropDownFilledButton
            // 
            this.toolStripDropDownFilledButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownFilledButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawFilledObjectToolStripMenuItem,
            this.drawNotFilledObjectsToolStripMenuItem});
            this.toolStripDropDownFilledButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownFilledButton.Image")));
            this.toolStripDropDownFilledButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownFilledButton.Name = "toolStripDropDownFilledButton";
            this.toolStripDropDownFilledButton.Size = new System.Drawing.Size(85, 22);
            this.toolStripDropDownFilledButton.Text = "Filled or Not";
            // 
            // drawFilledObjectToolStripMenuItem
            // 
            this.drawFilledObjectToolStripMenuItem.Name = "drawFilledObjectToolStripMenuItem";
            this.drawFilledObjectToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.drawFilledObjectToolStripMenuItem.Text = "Draw Filled objects";
            this.drawFilledObjectToolStripMenuItem.Click += new System.EventHandler(this.drawFilledObjectToolStripMenuItem_Click);
            // 
            // drawNotFilledObjectsToolStripMenuItem
            // 
            this.drawNotFilledObjectsToolStripMenuItem.Name = "drawNotFilledObjectsToolStripMenuItem";
            this.drawNotFilledObjectsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.drawNotFilledObjectsToolStripMenuItem.Text = "Draw Not Filled objects";
            this.drawNotFilledObjectsToolStripMenuItem.Click += new System.EventHandler(this.drawNotFilledObjectsToolStripMenuItem_Click);
            // 
            // toolStripDropDownEraserButton
            // 
            this.toolStripDropDownEraserButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11});
            this.toolStripDropDownEraserButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownEraserButton.Image")));
            this.toolStripDropDownEraserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownEraserButton.Name = "toolStripDropDownEraserButton";
            this.toolStripDropDownEraserButton.Size = new System.Drawing.Size(67, 22);
            this.toolStripDropDownEraserButton.Text = "Eraser";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem7.Text = "1";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem8.Text = "5";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem9.Text = "10";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem10.Text = "20";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem11.Text = "50";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
            // 
            // toolStripClearButton
            // 
            this.toolStripClearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripClearButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripClearButton.Image")));
            this.toolStripClearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripClearButton.Name = "toolStripClearButton";
            this.toolStripClearButton.Size = new System.Drawing.Size(38, 22);
            this.toolStripClearButton.Text = "Clear";
            this.toolStripClearButton.Click += new System.EventHandler(this.toolStripClearButton_Click);
            // 
            // linesToolStripMenuItem
            // 
            this.linesToolStripMenuItem.Name = "linesToolStripMenuItem";
            this.linesToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.linesToolStripMenuItem.Text = "Lines";
            this.linesToolStripMenuItem.Click += new System.EventHandler(this.linesToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(707, 368);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Canvas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "Form1";
            this.Text = "PPE [ Lab-3 ]";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripSaveButton;
        private System.Windows.Forms.ToolStripButton toolStripColorButton;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownWidthButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripButton toolStripClearButton;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownShapesButton;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownFilledButton;
        private System.Windows.Forms.ToolStripMenuItem drawFilledObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawNotFilledObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawBezierCurveToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownEraserButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem rectangleWithGradientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem linesToolStripMenuItem;
    }
}

