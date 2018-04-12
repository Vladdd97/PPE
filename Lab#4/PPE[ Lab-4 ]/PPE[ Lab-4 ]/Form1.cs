using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE__Lab_4__
{

    public enum Collision
    {
        Left, Right, Up, Down , None
    }

    public partial class Form1 : Form
    {



        private Graphics graphics;
        private SolidBrush brush;
        private List<Object> objects;
        private int dimensionX;
        private int dimensionY;


        public Form1()
        {

            InitializeComponent();
            DoubleBuffered = true; // need to solve flickering problem
            objects = new List<Object>();
            this.MouseWheel += from_MouseWheel; // need for creating MouseWheel event
            dimensionX = 40;
            dimensionY = 40;


        }


        private void from_MouseWheel(object sender, MouseEventArgs e)
        {
            this.label2.Text = "Speed : " + (101-this.timer1.Interval);

            if (e.Delta > 0) // need to check MouseWheel rotation (+up) (-down)
            {
                if (this.timer1.Interval > 1)
                {
                    this.timer1.Interval--;
                }
                else
                {
                    MessageBox.Show("It is the max speed");
                }
            }

            if (e.Delta < 0)
            {
                if (this.timer1.Interval < 100)
                {
                    this.timer1.Interval++;
                }
                else
                {
                    MessageBox.Show("It is the min speed");
                }
            }

            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        { 
            foreach (var obj in objects)
            {
               e.Graphics.FillEllipse(obj.brush,obj.PosX,obj.PosY,obj.DimensionX,obj.DimensionY);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var obj in objects)
            {
                obj.MoveObj(); // change object PosX and PosY
                Collision(obj); // check collision
            }
            Invalidate(); // clear form
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int speedX = 2, speedY = 2;
            bool create = true;
            foreach (var obj in objects)
            {
                if (Math.Abs(e.X - obj.PosX) <= obj.DimensionX && Math.Abs(e.Y - obj.PosY) <= obj.DimensionY)
                {
                    create = false;
                    MessageBox.Show("You can not create a ball inside another ball !");
                }

            }


            if (e.X + dimensionX >= this.ClientSize.Width || e.Y + dimensionY >= this.ClientSize.Height)
            {
                create = false;
                MessageBox.Show("You can not create a ball out of Form's Area !");
            }

            double areaOfObject = 2 * Math.PI * Math.Pow((dimensionX / 2), 2);
            double areaOfForm = this.ClientSize.Width * this.ClientSize.Height;
            if (objects.Count * areaOfObject > areaOfForm/6 )
            {
                create = false;
                MessageBox.Show("The area of Form is too small !!!" +
                                "\nIf you want to add more objects please resize the Form . " +
                                "\n( Make it bigger) !!!");


            }

            if (create)
            {
                if (Object.count % 4 == 3)
                {
                    speedX = -2;
                }
                if (Object.count % 4 == 2)
                {
                    speedY = -2;
                }
                if (Object.count % 4 == 1)
                {
                    speedX = -2;
                    speedY = -2;
                }

                objects.Add(new Object(e.X, e.Y, speedX, speedY, dimensionX, dimensionY));
            }


        }


        public void Collision(Object obj)
        {
            bool collision = false; // need to avoid bags on bounds

            if (obj.PosX + obj.DimensionX >= this.ClientSize.Width)
            {
                collision = true;
                obj.MoveX = -obj.MoveX;
                obj.ChangeColor();
            }
            if (obj.PosX <= 0)
            {
                collision = true;
                obj.MoveX = -obj.MoveX;
                obj.ChangeColor();
            }

            if (obj.PosY + obj.DimensionY >= this.ClientSize.Height)
            {
                collision = true;
                obj.MoveY = -obj.MoveY;
                obj.ChangeColor();
            }
            if (obj.PosY <= 0)
            {
                collision = true;
                obj.MoveY = -obj.MoveY;
                obj.ChangeColor();
            }

            if (collision)
            {
                return ; // if there is a collision on form's bounds then don't check other collisions
            }

            foreach (var obj2 in objects)
            {
                if (obj.Id == obj2.Id)
                    continue;

                if (Math.Sqrt(Math.Pow((obj.CenterX - obj2.CenterX), 2) + Math.Pow((obj.CenterY - obj2.CenterY), 2)) < obj.DimensionX)
                {
                    if (obj.CenterX < obj2.CenterX || obj.CenterX > obj2.CenterX)
                    {
                        obj.MoveX = -obj.MoveX;
                    }

                    if (obj.CenterY < obj2.CenterY || obj.CenterY > obj2.CenterY)
                    {
                        obj.MoveY = -obj.MoveY;
                    }

                    obj.ChangeColor();

                    break;
                }

            }

        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B)
            {
                if (this.timer1.Enabled == true)
                {
                    this.timer1.Enabled = false;
                }
                else
                {
                    this.timer1.Enabled = true;
                }
            }
        }



    }
}
