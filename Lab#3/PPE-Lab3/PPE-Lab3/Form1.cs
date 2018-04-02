using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE_Lab3
{
    public partial class Form1 : Form
    {

        private bool paint;
        private bool drawFilledObjects;


        private Point startPoint;
        private Point endPoint;

        private Pen pencil;
        private Pen redrawPencil;
        private SolidBrush eraser;

        private SolidBrush brush;
        private SolidBrush refillBrush; // needs to paint with mouse

        private float pencilOffset; // needs to paint with mouse
        private Graphics g;

        private string drawObject;

        private int eraserRadius;

        private LinearGradientBrush gradientBrush;

        private Point initialPoint;
        private int direction;



        public Form1()
        {
            InitializeComponent();
            pencilOffset = 1.4f;
            paint = false;
            drawFilledObjects = false;

            eraserRadius = 0;
            eraser = new SolidBrush(Color.White);

            drawObject = "Line";

            startPoint = new Point(0,0);
            endPoint = new Point(0,0);

            g = Canvas.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            brush = new SolidBrush(Color.Black);
            refillBrush = new SolidBrush(Color.White);

            pencil = new Pen(Color.Black,1);
            pencil.StartCap = pencil.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            redrawPencil = new Pen(Color.White,1 + pencilOffset);
            redrawPencil.StartCap = redrawPencil.EndCap = System.Drawing.Drawing2D.LineCap.Round;


            initialPoint = new Point();
            direction = 1;
            gradientBrush = new LinearGradientBrush(
                new Point(0, 10),
                new Point(200, 10),
                Color.FromArgb(255, 255, 0, 0),   // Opaque red
                Color.FromArgb(255, 0, 0, 255));  // Opaque blue


        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            startPoint.X = e.X;
            startPoint.Y = e.Y;

        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {

            if (paint)
            {
                switch(drawObject)
                {
                    case "Line":
                        DrawLine(e);
                        break;
                    case "Lines":
                        DrawLines(e);
                        break;
                    case "BezierCurve":
                        DrawBezierCurve(e);
                        break;
                    case "Rectangle":
                        DrawRectangle(e);
                        break;
                    case "Ellipse":
                        DrawEllipse(e);
                        break;
                    case "Triangle":
                        DrawTriangle(e);
                        break;
                    case "DrawRectangleWithGradient":
                        DrawRectangleWithGradient(e);
                        break;
                    case "Eraser":
                        Erase(e);
                        break;
                    default:
                        MessageBox.Show("Problem in MouseMove Function !");
                        break;
                        
                }
                
            }
            else
            {
                startPoint.X = endPoint.X = e.X;
                startPoint.Y = endPoint.Y = e.Y;
                initialPoint.X = e.X;
                initialPoint.Y = e.Y;
                direction = 1;
            }
        }

        private void Erase(MouseEventArgs e)
        {
            g.FillEllipse(eraser, e.X-eraserRadius/2, e.Y-eraserRadius/2,
                eraserRadius, eraserRadius);
        }

        private void DrawLine(MouseEventArgs e)
        {
            endPoint = new Point(e.X,e.Y);
            g.DrawLine(pencil,startPoint,endPoint);

            startPoint = endPoint; 
           
        }

        private void DrawLines(MouseEventArgs e)
        {
            g.DrawLine(redrawPencil, startPoint, endPoint);
            endPoint = new Point(e.X, e.Y);
            g.DrawLine(pencil, startPoint, endPoint);
        }

        private void DrawBezierCurve(MouseEventArgs e)
        {

            Point centerPoint = new Point(Canvas.Width/2,Canvas.Height/2);

            Point p1 = new Point(startPoint.X, startPoint.Y);
            Point p2 = new Point(centerPoint.X - Math.Abs(startPoint.X - centerPoint.X),
                centerPoint.Y + Math.Abs(startPoint.Y - centerPoint.Y));
            Point p3 = new Point(endPoint.X, endPoint.Y);
            Point p4 = new Point(centerPoint.X - Math.Abs(endPoint.X - centerPoint.X),
                centerPoint.Y + Math.Abs(endPoint.Y - centerPoint.Y));

            g.DrawBezier(redrawPencil,p1,p2,p3,p4);

            if (e.X >= initialPoint.X)
                endPoint.X = e.X;
            else
                startPoint.X = e.X;

            if (e.Y >= initialPoint.Y)
                endPoint.Y = e.Y;
            else
                startPoint.Y = e.Y;

            centerPoint = new Point(Canvas.Width / 2, Canvas.Height / 2);

            p1 = new Point(startPoint.X, startPoint.Y);
            p2 = new Point(centerPoint.X - Math.Abs(startPoint.X - centerPoint.X),
                centerPoint.Y + Math.Abs(startPoint.Y - centerPoint.Y));
            p3 = new Point(endPoint.X, endPoint.Y);
            p4 = new Point(centerPoint.X - Math.Abs(endPoint.X - centerPoint.X),
                centerPoint.Y + Math.Abs(endPoint.Y - centerPoint.Y));

            g.DrawBezier(pencil, p1, p2, p3, p4);

        }

        private void DrawTriangle(MouseEventArgs e)
        {


            if (drawFilledObjects)
            {
                int offset = 0;
                if (startPoint.X < endPoint.X)
                    offset = 2;
                else
                    offset = -2;



                Point[] points =
                {
                    new Point(startPoint.X-offset, startPoint.Y+Math.Abs(offset/2)*direction ),
                    new Point(endPoint.X+offset, startPoint.Y+Math.Abs(offset/2)*direction),
                    new Point((endPoint.X + startPoint.X) / 2 , startPoint.Y - (Math.Abs(endPoint.X - startPoint.X) / 2 + Math.Abs(offset/2))*direction)

                };


                g.FillPolygon(refillBrush, points);

                if (initialPoint.Y >= e.Y)
                    direction = 1;
                else
                    direction = -1;

                endPoint.X = e.X;
                endPoint.Y = e.Y;

                Point[] points2 =
                {
                    new Point(startPoint.X, startPoint.Y),
                    new Point(endPoint.X, startPoint.Y),
                    new Point((endPoint.X + startPoint.X) / 2, startPoint.Y - (Math.Abs(endPoint.X - startPoint.X) / 2)*direction)
                };

                g.FillPolygon(brush, points2);
            }
            else
            {


                Point[] points =
                {
                    new Point(startPoint.X, startPoint.Y),
                    new Point(endPoint.X, startPoint.Y),
                    new Point((endPoint.X + startPoint.X) / 2, startPoint.Y - (Math.Abs(endPoint.X - startPoint.X) / 2*direction ))

                };

                g.DrawPolygon(redrawPencil, points);

                if (initialPoint.Y >= e.Y)
                    direction = 1;
                else
                    direction = -1;

                endPoint.X = e.X;
                endPoint.Y = e.Y;

                Point[] points2 =
                {
                    new Point(startPoint.X, startPoint.Y),
                    new Point(endPoint.X, startPoint.Y),
                    new Point((endPoint.X + startPoint.X) / 2, startPoint.Y - (Math.Abs(endPoint.X - startPoint.X) / 2*direction))
                };

                g.DrawPolygon(pencil, points2);

            }
        }
    

        private void DrawRectangle(MouseEventArgs e)
        {

            if (drawFilledObjects)
            {
                g.FillRectangle(refillBrush, startPoint.X-pencilOffset/2, startPoint.Y-pencilOffset/2,
                    Math.Abs(endPoint.X - startPoint.X)+pencilOffset, Math.Abs(endPoint.Y - startPoint.Y)+pencilOffset);


                if (e.X >= initialPoint.X)
                    endPoint.X = e.X;
                else
                    startPoint.X = e.X;

                if (e.Y >= initialPoint.Y)
                    endPoint.Y = e.Y;
                else
                    startPoint.Y = e.Y;

                g.FillRectangle(brush, startPoint.X, startPoint.Y,
                    Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
            }
            else
            {

                g.DrawRectangle(redrawPencil, startPoint.X, startPoint.Y,
                    Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));


                if (e.X >= initialPoint.X)
                    endPoint.X = e.X;
                else
                    startPoint.X = e.X;

                if (e.Y >= initialPoint.Y)
                    endPoint.Y = e.Y;
                else
                    startPoint.Y = e.Y;

                g.DrawRectangle(pencil, startPoint.X, startPoint.Y,
                    Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
            }

        }



        private void DrawRectangleWithGradient(MouseEventArgs e)
        {

                g.FillRectangle(refillBrush, startPoint.X - pencilOffset / 2, startPoint.Y - pencilOffset / 2,
                Math.Abs(endPoint.X - startPoint.X) + pencilOffset, Math.Abs(endPoint.Y - startPoint.Y) + pencilOffset);

                endPoint.X = e.X;
                endPoint.Y = e.Y;

                g.FillRectangle(gradientBrush, startPoint.X, startPoint.Y,
                    Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
            

        }




        private void DrawEllipse(MouseEventArgs e)
        {
            if (drawFilledObjects)
            {
                float redrawOffset = 2.4f;
                g.FillEllipse(refillBrush, startPoint.X-redrawOffset/2 , startPoint.Y-redrawOffset/2 ,
                    Math.Abs(endPoint.X - startPoint.X) + redrawOffset, Math.Abs(endPoint.Y - startPoint.Y)+redrawOffset);

                if (e.X >= initialPoint.X)
                    endPoint.X = e.X;
                else
                    startPoint.X = e.X;

                if (e.Y >= initialPoint.Y)
                    endPoint.Y = e.Y;
                else
                    startPoint.Y = e.Y;

                g.FillEllipse(brush, startPoint.X, startPoint.Y,
                    Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
                   
            }
            else
            {

                g.DrawEllipse(redrawPencil, startPoint.X, startPoint.Y,
                    Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));

                if (e.X >= initialPoint.X)
                    endPoint.X = e.X;
                else
                    startPoint.X = e.X;

                if (e.Y >= initialPoint.Y)
                    endPoint.Y = e.Y;
                else
                    startPoint.Y = e.Y;

                g.DrawEllipse(pencil, startPoint.X, startPoint.Y,
                    Math.Abs(endPoint.X - startPoint.X), Math.Abs(endPoint.Y - startPoint.Y));
            }
        }




        private void Save(Control c, string file)
        {
            Bitmap picture = new Bitmap(c.Width, c.Height);
            g = Graphics.FromImage(picture);
            Rectangle rect = c.RectangleToScreen(c.ClientRectangle);
            g.CopyFromScreen(rect.Location, Point.Empty, c.Size);

            picture.Save(file);
            picture.Dispose();

            g = Canvas.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private async  void toolStripSaveButton_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Do you really wanna Save this picture", "Save", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Image was succesefully saved ! \n" +
                                "You can see that in PPE-Lab3/bin/Debug Folder as Picture1.jpg image");
                await Task.Delay(200);
                Save(Canvas, "Picture1.jpg");
            }

        }

        private void toolStripColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                pencil.Color = cd.Color;
                brush.Color = cd.Color;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pencil.Width = 1;
            redrawPencil.Width = 1 + pencilOffset;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            pencil.Width = 5;
            redrawPencil.Width = 5 + pencilOffset;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            pencil.Width = 10;
            redrawPencil.Width = 10 + pencilOffset;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            pencil.Width = 15;
            redrawPencil.Width = 15 + pencilOffset;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            pencil.Width = 20;
            redrawPencil.Width = 20 + pencilOffset;

        }

        private void toolStripClearButton_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawObject = "Line";

        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawObject = "Rectangle";
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawObject = "Ellipse";
        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawObject = "Triangle";
        }

        private void drawFilledObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawFilledObjects = true;
        }

        private void drawNotFilledObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawFilledObjects = false;
        }

        private void drawBezierCurveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawObject = "BezierCurve";
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            drawObject = "Eraser";
            eraserRadius = 1;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            drawObject = "Eraser";
            eraserRadius = 5;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            drawObject = "Eraser";
            eraserRadius = 10;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            drawObject = "Eraser";
            eraserRadius = 20;
        }


        private void rectangleWithGradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawObject = "DrawRectangleWithGradient";

        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Canvas.Width = this.Width - 40;
            this.Canvas.Height = this.Height - 90;

            g = Canvas.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }


        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z)
            {
               // MessageBox.Show("Window is maximazed (Z) !!!");
                //this.WindowState = FormWindowState.Maximized;
                if (this.Width -40 > this.Canvas.Width)
                    this.Canvas.Width += 5;
                if (this.Height - 90 > this.Canvas.Height)
                    this.Canvas.Height += 5;
            }

            if (e.KeyCode == Keys.M)
            {
                // MessageBox.Show("Window is minimazed (M) !!!");
                //this.WindowState = FormWindowState.Minimized;
                if (this.Canvas.Width > this.MinimumSize.Width)
                    this.Canvas.Width -= 5;
                if (this.Canvas.Height  > this.MinimumSize.Height)
                    this.Canvas.Height -= 5;
            }
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            eraserRadius = 50;
        }

        private void linesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawObject = "Lines";
        }
    }
}
