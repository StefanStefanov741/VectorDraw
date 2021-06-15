using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Draw.src.GUI
{
    public partial class CustomSizePopup_triangle : Form
    {
        string shape = "";
        private DialogProcessor dp;
        private DoubleBufferedPanel view_p;
        public CustomSizePopup_triangle(DialogProcessor dialogP, DoubleBufferedPanel vp, string s, PointF p_1, PointF p_2, PointF p_3)
        {
            dp = dialogP;
            shape = s;
            view_p = vp;
            InitializeComponent();
            textBox1.Text = p_1.X.ToString();
            textBox2.Text = p_1.Y.ToString();
            textBox3.Text = p_2.X.ToString();
            textBox4.Text = p_2.Y.ToString();
            textBox5.Text = p_3.X.ToString();
            textBox6.Text = p_3.Y.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "") {
                dp.trianglep1.X = int.Parse(textBox1.Text);
                dp.trianglep1.Y = int.Parse(textBox2.Text);
                dp.trianglep2.X = int.Parse(textBox3.Text);
                dp.trianglep2.Y = int.Parse(textBox4.Text);
                dp.trianglep3.X = int.Parse(textBox5.Text);
                dp.trianglep3.Y = int.Parse(textBox6.Text);
                dp.AddRandomTriangle();
                view_p.Invalidate();
            }
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "340";
            textBox2.Text = "20";
            textBox3.Text = "260";
            textBox4.Text = "130";
            textBox5.Text = "420";
            textBox6.Text = "130";
        }
    }
}
