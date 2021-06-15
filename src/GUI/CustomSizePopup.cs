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
    public partial class CustomSizePopup : Form
    {
        string shape = "";
        private DialogProcessor dp;
        private DoubleBufferedPanel view_p;
        public CustomSizePopup(DialogProcessor dialogP,DoubleBufferedPanel vp, string s,int w,int h)
        {
            dp = dialogP;
            shape = s;
            InitializeComponent();
            view_p = vp;
            textBox1.Text = w.ToString();
            textBox2.Text = h.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "") {
                switch (shape)
                {
                    case "rectangle":
                        dp.rect_width = int.Parse(textBox1.Text);
                        dp.rect_height = int.Parse(textBox2.Text);
                        dp.AddRandomRectangle();
                        view_p.Invalidate();
                        break;
                    case "ellipse":
                        dp.ell_width = int.Parse(textBox1.Text);
                        dp.ell_height = int.Parse(textBox2.Text);
                        dp.AddRandomEllipse();
                        view_p.Invalidate();
                        break;
                    case "point":
                        dp.point_width = int.Parse(textBox1.Text);
                        dp.point_height = int.Parse(textBox2.Text);
                        dp.AddRandomPoint();
                        view_p.Invalidate();
                        break;
                    default:
                        break;
                }
            }
            
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (shape)
            {
                case "rectangle":
                    textBox1.Text = "100";
                    textBox2.Text = "100";
                    break;
                case "ellipse":
                    textBox1.Text = "100";
                    textBox2.Text = "100";
                    break;
                case "point":
                    textBox1.Text = "4";
                    textBox1.Text = "4";
                    break;
                default:
                    break;
            }
        }
    }
}
