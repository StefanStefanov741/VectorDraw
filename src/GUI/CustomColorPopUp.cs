using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Draw.src.GUI
{
    public partial class CustomColor : Form
    {
        MainForm mainF = null;
        DialogProcessor dialogP = null;
        Color selectedC = new Color();
        bool skipHex = false;
        bool waitPicker = false;
        bool waitAdvanced = false;
        public CustomColor(MainForm m, DialogProcessor dp, string Title, Color chosenOne = new Color())
        {
            InitializeComponent();
            mainF = m;
            dialogP = dp;
            TitleLabel.Text = Title;
            ResetToDefault();
            if (chosenOne != new Color())
            {
                mainF.Cursor= System.Windows.Forms.Cursors.Arrow;
                waitPicker = true;
                SetToChosenColor(chosenOne);
            }
        }

        private void updateColorData() {
            Rbox.Text = selectedC.R.ToString();
            Gbox.Text = selectedC.G.ToString();
            Bbox.Text = selectedC.B.ToString();
            Abox.Text = selectedC.A.ToString();
            if (!skipHex) {
                string hex = "#" + selectedC.R.ToString("X2") + selectedC.G.ToString("X2") + selectedC.B.ToString("X2");
                nameBox.Text = hex;
            }
            previewColor.BackColor = selectedC;
            if (waitPicker) {
                waitPicker = false;
            }
        }

        private void ResetToDefault() {
            if (mainF.selectedType == "border")
            {
                selectedC = dialogP.SelectedBorderColor;
            }
            else if (mainF.selectedType == "fill")
            {
                selectedC = dialogP.SelectedFillColor;
            }
            updateColorData();
        }

        private void SetToChosenColor(Color c) {
            selectedC = c;
            updateColorData();
        }

        private void ChangeSelectedColor()
        {
            if (!skipHex && !waitPicker && !waitAdvanced) {
                int r = -1;
                int g = -1;
                int b = -1;
                int a = -1;
                if (Rbox.Text != "" && Gbox.Text != "" && Bbox.Text != "" && Abox.Text != "")
                {
                    try
                    {
                        r = int.Parse(Rbox.Text);
                        g = int.Parse(Gbox.Text);
                        b = int.Parse(Bbox.Text);
                        a = int.Parse(Abox.Text);
                    }
                    catch
                    {
                        ResetToDefault();
                    }
                    if (r >= 0 && g >= 0 && b >= 0 && a >= 0 && r <= 255 && g <= 255 && b <= 255 && a <= 255)
                    {
                        selectedC = Color.FromArgb(a, r, g, b);
                        updateColorData();
                    }
                    else
                    {
                        ResetToDefault();
                    }
                }
            }
        }

        private void Rbox_TextChanged(object sender, EventArgs e)
        {
            ChangeSelectedColor();
        }

        private void Gbox_TextChanged(object sender, EventArgs e)
        {
            ChangeSelectedColor();
        }

        private void Bbox_TextChanged(object sender, EventArgs e)
        {
            ChangeSelectedColor();
        }

        private void Abox_TextChanged(object sender, EventArgs e)
        {
            ChangeSelectedColor();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            mainF.ResetSpeedBtn();
            Dispose();
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            if (mainF.selectedType == "border")
            {
                mainF.ClearSelectedBorderIcon();
                dialogP.SelectedBorderColor = selectedC;
                mainF.SetBorderTransDial(selectedC.A);
            }
            else if (mainF.selectedType == "fill")
            {
                mainF.ClearSelectedFillIcon();
                dialogP.SelectedFillColor = selectedC;
                mainF.SetFillTransDial(selectedC.A);
            }
            mainF.selectedType = "";
            mainF.ResetSpeedBtn();
            Dispose();
        }

        private void Rbox_MouseLeave(object sender, EventArgs e)
        {
            if (Rbox.Text == "") {
                Rbox.Text = "0";
            }
        }

        private void Gbox_MouseLeave(object sender, EventArgs e)
        {
            if (Gbox.Text == "")
            {
                Gbox.Text = "0";
            }
        }

        private void Bbox_MouseLeave(object sender, EventArgs e)
        {
            if (Bbox.Text == "")
            {
                Bbox.Text = "0";
            }
        }

        private void Abox_MouseLeave(object sender, EventArgs e)
        {
            if (Abox.Text == "")
            {
                Abox.Text = "255";
            }
        }

        private void nameBox_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Color color = ColorTranslator.FromHtml(nameBox.Text);
            }
            catch
            {
                ResetToDefault();
            }
        }
        bool isHex(string s)
        {
            if (s=="" || s[0] != '#') {
                return false;
            }
            s = s.Substring(1,s.Length-1);
            int n = s.Length;
            for (int i = 0; i < n; i++)
            {
                char ch = s[i];

                // Check each character if it is invalid
                if ((ch < '0' || ch > '9') &&
                    (ch < 'A' || ch > 'F'))
                {
                    return false;
                }
            }
            return true;
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            string txt = nameBox.Text.ToUpper();
            if (txt.Length==7 && isHex(txt)) {
                Color color = ColorTranslator.FromHtml(txt);
                selectedC = color;
                updateColorData();
            }
        }

        private void nameBox_MouseDown(object sender, MouseEventArgs e)
        {
            waitAdvanced = false;
            skipHex = true;
        }

        private void Rbox_MouseDown(object sender, MouseEventArgs e)
        {
            waitAdvanced = false;
            skipHex = false;
        }

        private void Gbox_MouseDown(object sender, MouseEventArgs e)
        {
            waitAdvanced = false;
            skipHex = false;
        }

        private void Bbox_MouseDown(object sender, MouseEventArgs e)
        {
            waitAdvanced = false;
            skipHex = false;
        }

        private void Abox_MouseDown(object sender, MouseEventArgs e)
        {
            waitAdvanced = false;
            skipHex = false;
        }

        private void PickColorBtn_Click(object sender, EventArgs e)
        {
            Cursor colPickCur = new Cursor(Properties.Resources.colorpicker.GetHicon());
            mainF.ColorPicking = true;
            mainF.Cursor = colPickCur;
            Dispose();
        }

        private void advancedColorsBtn_Click(object sender, EventArgs e)
        {
            waitAdvanced = true;
            skipHex = false;
            ColorDialog clDialog = new ColorDialog();

            //show the color dialog and wait for ok click
            if (clDialog.ShowDialog() == DialogResult.OK)
            {
                //save the chosen color
                selectedC = clDialog.Color;
                updateColorData();
            }
        }
    }
}
