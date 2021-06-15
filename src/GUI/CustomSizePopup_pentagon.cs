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
    public partial class CustomSizePopup_pentagon : Form
    {
        string shape = "";
        private DialogProcessor dp;
        private DoubleBufferedPanel view_p;
        public CustomSizePopup_pentagon(DialogProcessor dialogP, DoubleBufferedPanel vp, string s, PointF p_1, PointF p_2, PointF p_3, PointF p_4, PointF p_5)
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
            textBox7.Text = p_4.X.ToString();
            textBox8.Text = p_4.Y.ToString();
            textBox9.Text = p_5.X.ToString();
            textBox10.Text = p_5.Y.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                dp.pentagonp1.X = int.Parse(textBox1.Text);
                dp.pentagonp1.Y = int.Parse(textBox2.Text);
                dp.pentagonp2.X = int.Parse(textBox3.Text);
                dp.pentagonp2.Y = int.Parse(textBox4.Text);
                dp.pentagonp3.X = int.Parse(textBox5.Text);
                dp.pentagonp3.Y = int.Parse(textBox6.Text);
                dp.pentagonp4.X = int.Parse(textBox7.Text);
                dp.pentagonp4.Y = int.Parse(textBox8.Text);
                dp.pentagonp5.X = int.Parse(textBox9.Text);
                dp.pentagonp5.Y = int.Parse(textBox10.Text);
                dp.AddRandomPentagon();
                view_p.Invalidate();
            }
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "340";
            textBox2.Text = "15";
            textBox3.Text = "390";
            textBox4.Text = "50";
            textBox5.Text = "370";
            textBox6.Text = "105";
            textBox7.Text = "310";
            textBox8.Text = "105";
            textBox9.Text = "290";
            textBox10.Text = "50";
        }
    }
}
