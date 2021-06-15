
namespace Draw.src.GUI
{
    partial class CustomColor
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
            this.select_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.Rbox = new System.Windows.Forms.TextBox();
            this.Gbox = new System.Windows.Forms.TextBox();
            this.Bbox = new System.Windows.Forms.TextBox();
            this.Abox = new System.Windows.Forms.TextBox();
            this.rlabel = new System.Windows.Forms.Label();
            this.glabel = new System.Windows.Forms.Label();
            this.blabel = new System.Windows.Forms.Label();
            this.alabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectedColorLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PickColorBtn = new System.Windows.Forms.Button();
            this.previewColor = new System.Windows.Forms.PictureBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.advancedColorsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.previewColor)).BeginInit();
            this.SuspendLayout();
            // 
            // select_btn
            // 
            this.select_btn.Location = new System.Drawing.Point(54, 227);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(75, 23);
            this.select_btn.TabIndex = 0;
            this.select_btn.Text = "Select";
            this.select_btn.UseVisualStyleBackColor = true;
            this.select_btn.Click += new System.EventHandler(this.select_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(277, 227);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 1;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // Rbox
            // 
            this.Rbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Rbox.Location = new System.Drawing.Point(54, 40);
            this.Rbox.Name = "Rbox";
            this.Rbox.Size = new System.Drawing.Size(62, 20);
            this.Rbox.TabIndex = 2;
            this.Rbox.TextChanged += new System.EventHandler(this.Rbox_TextChanged);
            this.Rbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Rbox_MouseDown);
            this.Rbox.MouseLeave += new System.EventHandler(this.Rbox_MouseLeave);
            // 
            // Gbox
            // 
            this.Gbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Gbox.Location = new System.Drawing.Point(54, 85);
            this.Gbox.Name = "Gbox";
            this.Gbox.Size = new System.Drawing.Size(62, 20);
            this.Gbox.TabIndex = 3;
            this.Gbox.TextChanged += new System.EventHandler(this.Gbox_TextChanged);
            this.Gbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Gbox_MouseDown);
            this.Gbox.MouseLeave += new System.EventHandler(this.Gbox_MouseLeave);
            // 
            // Bbox
            // 
            this.Bbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Bbox.Location = new System.Drawing.Point(54, 130);
            this.Bbox.Name = "Bbox";
            this.Bbox.Size = new System.Drawing.Size(62, 20);
            this.Bbox.TabIndex = 4;
            this.Bbox.TextChanged += new System.EventHandler(this.Bbox_TextChanged);
            this.Bbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Bbox_MouseDown);
            this.Bbox.MouseLeave += new System.EventHandler(this.Bbox_MouseLeave);
            // 
            // Abox
            // 
            this.Abox.BackColor = System.Drawing.Color.White;
            this.Abox.Location = new System.Drawing.Point(54, 175);
            this.Abox.Name = "Abox";
            this.Abox.Size = new System.Drawing.Size(62, 20);
            this.Abox.TabIndex = 5;
            this.Abox.TextChanged += new System.EventHandler(this.Abox_TextChanged);
            this.Abox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Abox_MouseDown);
            this.Abox.MouseLeave += new System.EventHandler(this.Abox_MouseLeave);
            // 
            // rlabel
            // 
            this.rlabel.AutoSize = true;
            this.rlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rlabel.Location = new System.Drawing.Point(33, 43);
            this.rlabel.Name = "rlabel";
            this.rlabel.Size = new System.Drawing.Size(16, 13);
            this.rlabel.TabIndex = 6;
            this.rlabel.Text = "R";
            // 
            // glabel
            // 
            this.glabel.AutoSize = true;
            this.glabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glabel.Location = new System.Drawing.Point(32, 88);
            this.glabel.Name = "glabel";
            this.glabel.Size = new System.Drawing.Size(16, 13);
            this.glabel.TabIndex = 7;
            this.glabel.Text = "G";
            // 
            // blabel
            // 
            this.blabel.AutoSize = true;
            this.blabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blabel.Location = new System.Drawing.Point(32, 133);
            this.blabel.Name = "blabel";
            this.blabel.Size = new System.Drawing.Size(15, 13);
            this.blabel.TabIndex = 8;
            this.blabel.Text = "B";
            // 
            // alabel
            // 
            this.alabel.AutoSize = true;
            this.alabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alabel.Location = new System.Drawing.Point(32, 178);
            this.alabel.Name = "alabel";
            this.alabel.Size = new System.Drawing.Size(15, 13);
            this.alabel.TabIndex = 9;
            this.alabel.Text = "A";
            // 
            // nameBox
            // 
            this.nameBox.BackColor = System.Drawing.Color.White;
            this.nameBox.Location = new System.Drawing.Point(283, 133);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(69, 20);
            this.nameBox.TabIndex = 10;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            this.nameBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.nameBox_MouseDown);
            this.nameBox.MouseLeave += new System.EventHandler(this.nameBox_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(300, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "HEX";
            // 
            // selectedColorLabel
            // 
            this.selectedColorLabel.AutoSize = true;
            this.selectedColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedColorLabel.Location = new System.Drawing.Point(158, 54);
            this.selectedColorLabel.Name = "selectedColorLabel";
            this.selectedColorLabel.Size = new System.Drawing.Size(90, 13);
            this.selectedColorLabel.TabIndex = 13;
            this.selectedColorLabel.Text = "Selected Color";
            this.selectedColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(274, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Pick from scene";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PickColorBtn
            // 
            this.PickColorBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PickColorBtn.Image = global::Draw.Properties.Resources.colorpicker;
            this.PickColorBtn.Location = new System.Drawing.Point(303, 49);
            this.PickColorBtn.Name = "PickColorBtn";
            this.PickColorBtn.Size = new System.Drawing.Size(30, 30);
            this.PickColorBtn.TabIndex = 14;
            this.PickColorBtn.UseVisualStyleBackColor = true;
            this.PickColorBtn.Click += new System.EventHandler(this.PickColorBtn_Click);
            // 
            // previewColor
            // 
            this.previewColor.BackColor = System.Drawing.Color.White;
            this.previewColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewColor.Location = new System.Drawing.Point(152, 70);
            this.previewColor.Name = "previewColor";
            this.previewColor.Size = new System.Drawing.Size(100, 100);
            this.previewColor.TabIndex = 12;
            this.previewColor.TabStop = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("NSimSun", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(152, 5);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(52, 15);
            this.TitleLabel.TabIndex = 16;
            this.TitleLabel.Text = "Color";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // advancedColorsBtn
            // 
            this.advancedColorsBtn.Location = new System.Drawing.Point(161, 172);
            this.advancedColorsBtn.Name = "advancedColorsBtn";
            this.advancedColorsBtn.Size = new System.Drawing.Size(75, 23);
            this.advancedColorsBtn.TabIndex = 17;
            this.advancedColorsBtn.Text = "Advanced";
            this.advancedColorsBtn.UseVisualStyleBackColor = true;
            this.advancedColorsBtn.Click += new System.EventHandler(this.advancedColorsBtn_Click);
            // 
            // CustomColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(408, 275);
            this.Controls.Add(this.advancedColorsBtn);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PickColorBtn);
            this.Controls.Add(this.selectedColorLabel);
            this.Controls.Add(this.previewColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.alabel);
            this.Controls.Add(this.blabel);
            this.Controls.Add(this.glabel);
            this.Controls.Add(this.rlabel);
            this.Controls.Add(this.Abox);
            this.Controls.Add(this.Bbox);
            this.Controls.Add(this.Gbox);
            this.Controls.Add(this.Rbox);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.select_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CustomColor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose a custom color";
            ((System.ComponentModel.ISupportInitialize)(this.previewColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button select_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.TextBox Rbox;
        private System.Windows.Forms.TextBox Gbox;
        private System.Windows.Forms.TextBox Bbox;
        private System.Windows.Forms.TextBox Abox;
        private System.Windows.Forms.Label rlabel;
        private System.Windows.Forms.Label glabel;
        private System.Windows.Forms.Label blabel;
        private System.Windows.Forms.Label alabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox previewColor;
        private System.Windows.Forms.Label selectedColorLabel;
        private System.Windows.Forms.Button PickColorBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button advancedColorsBtn;
    }
}