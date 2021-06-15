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
    public partial class CustomSizePopup_line : Form
    {
        string shape = "";
        private DialogProcessor dp;
        private DoubleBufferedPanel view_p;
        public CustomSizePopup_line(DialogProcessor dialogP,DoubleBufferedPanel vp,string s,int x,int y)
        {
            dp = dialogP;
            shape = s;
            view_p = vp;
            InitializeComponent();
            textBox1.Text = dp.linepoint2.X.ToString();
            textBox2.Text = dp.linepoint2.Y.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "") {
                dp.linepoint2.X = int.Parse(textBox1.Text);
                dp.linepoint2.Y = int.Parse(textBox2.Text);
                dp.AddRandomLine();
                view_p.Invalidate();
            }
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "360";
            textBox2.Text = "20";
        }
    }
}
