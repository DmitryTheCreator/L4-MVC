using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L4_Without_MVC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int num = Int32.Parse(textBox1.Text);
                if (num < trackBar.Minimum || num > trackBar.Maximum)
                    num = new Random().Next(trackBar.Minimum, trackBar.Maximum);
                textBox1.Text = num.ToString();
                textBox2.Text = (num + 1).ToString();
                trackBar.Value = num;
                progressBar.Value = num;
                vScrollBar.Value = num;
                label.Text = num.ToString();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int num = Int32.Parse(textBox2.Text);
                if (num < trackBar.Minimum || num > trackBar.Maximum)
                    num = new Random().Next(trackBar.Minimum, trackBar.Maximum);                
                textBox2.Text = num.ToString();
                textBox1.Text = (num - 1).ToString();
                int num1 = Int32.Parse(textBox1.Text);

                trackBar.Value = num1;
                progressBar.Value = num1;
                vScrollBar.Value = num1;
                label.Text = num1.ToString();
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            int num = trackBar.Value;
            textBox1.Text = num.ToString();
            textBox2.Text = (num + 1).ToString();
            progressBar.Value = trackBar.Value;
            vScrollBar.Value = num;
            label.Text = num.ToString();
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            int num = vScrollBar.Value;
            textBox1.Text = num.ToString();
            textBox2.Text = (num + 1).ToString();
            progressBar.Value = num;
            trackBar.Value = num;
            label.Text = vScrollBar.Value.ToString();
        }
    }
}
