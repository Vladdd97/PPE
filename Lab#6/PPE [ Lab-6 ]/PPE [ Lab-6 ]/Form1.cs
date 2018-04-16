using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE___Lab_6__
{
    public partial class Form1 : Form
    {
        private int boldCount;
        private int italicCount;
        public Form1()
        {
            InitializeComponent();
            this.infoLabel.Text = "Fill the fields and press GENERATE !";

            boldCount = 0;
            italicCount = 0;

            this.generateButton.Location = new Point(
                (this.ClientSize.Width - this.generateButton.Size.Width) / 2,
                (this.ClientSize.Height - this.generateButton.Size.Height) / 2
            );

        }


        private void generateButton_Click(object sender, EventArgs e)
        {
            this.displayTextBox.Text = this.nameTextBox.Text + " " + this.surnameTextBox.Text + 
                                       " is from " + this.groupTextBox.Text + " group";
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.displayTextBox.Text,"Display Text");
        }

        private void BgColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = cd.Color;
            }
        }

        private void textBoldButton_Click(object sender, EventArgs e)
        {
            if ( boldCount % 2 == 0 )
                this.displayTextBox.Font = new Font("Papyrus", 14, FontStyle.Bold);
            else
                this.displayTextBox.Font = new Font("Papyrus", 14, FontStyle.Regular);
            boldCount++;
        }

        private void ObliqueTextButton_Click(object sender, EventArgs e)
        {
            if (italicCount % 2 == 0)
                this.displayTextBox.Font = new Font("Papyrus", 14, FontStyle.Italic);
            else
                this.displayTextBox.Font = new Font("Papyrus", 14, FontStyle.Regular);
            italicCount++;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.generateButton.Location = new Point(
                (this.ClientSize.Width - this.generateButton.Size.Width) / 2,
                (this.ClientSize.Height - this.generateButton.Size.Height) / 2
            );
        }
    }
}
