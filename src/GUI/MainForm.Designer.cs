namespace Draw
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllctrlAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diselectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ungroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedMenu = new System.Windows.Forms.ToolStrip();
            this.pickUpSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.selectToolSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.deleteSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.drawEllipseSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawTriangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.DrawPentagonButton = new System.Windows.Forms.ToolStripButton();
            this.drawLineSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawPointSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.BorderSizeBox = new System.Windows.Forms.ToolStripTextBox();
            this.BorderSizeLabel = new System.Windows.Forms.ToolStripLabel();
            this.ColorsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FillLabel = new System.Windows.Forms.Label();
            this.BorderLabel = new System.Windows.Forms.Label();
            this.BlackBorderButton = new System.Windows.Forms.Button();
            this.RedBorderButton = new System.Windows.Forms.Button();
            this.RedFillButton = new System.Windows.Forms.Button();
            this.BlackFillButton = new System.Windows.Forms.Button();
            this.WhiteBorderButton = new System.Windows.Forms.Button();
            this.GreenBorderButton = new System.Windows.Forms.Button();
            this.GreenFillButton = new System.Windows.Forms.Button();
            this.WhiteFillButton = new System.Windows.Forms.Button();
            this.BlueFillButton = new System.Windows.Forms.Button();
            this.BlueBorderButton = new System.Windows.Forms.Button();
            this.YellowBorderButton = new System.Windows.Forms.Button();
            this.YellowFillButton = new System.Windows.Forms.Button();
            this.BorderTransparency = new System.Windows.Forms.TrackBar();
            this.FillTransparency = new System.Windows.Forms.TrackBar();
            this.AlphaLabel1 = new System.Windows.Forms.Label();
            this.AlphaLabel2 = new System.Windows.Forms.Label();
            this.CusomFillColor = new System.Windows.Forms.Button();
            this.CustomBorderColor = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Ylabel = new System.Windows.Forms.Label();
            this.Xlabel = new System.Windows.Forms.Label();
            this.sizetextboxY = new System.Windows.Forms.TextBox();
            this.sizetextboxX = new System.Windows.Forms.TextBox();
            this.resizeBtn = new System.Windows.Forms.Button();
            this.rotateBox = new System.Windows.Forms.TextBox();
            this.Rotate = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SceneList = new System.Windows.Forms.FlowLayoutPanel();
            this.labelPanel = new System.Windows.Forms.Panel();
            this.ListLabel = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.viewPort = new Draw.DoubleBufferedPanel();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.speedMenu.SuspendLayout();
            this.ColorsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BorderTransparency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FillTransparency)).BeginInit();
            this.panel1.SuspendLayout();
            this.SceneList.SuspendLayout();
            this.labelPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(956, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveModelToolStripMenuItem,
            this.loadModelToolStripMenuItem,
            this.saveImageToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveModelToolStripMenuItem
            // 
            this.saveModelToolStripMenuItem.Name = "saveModelToolStripMenuItem";
            this.saveModelToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.saveModelToolStripMenuItem.Text = "Save Model";
            this.saveModelToolStripMenuItem.Click += new System.EventHandler(this.saveModelToolStripMenuItem_Click);
            // 
            // loadModelToolStripMenuItem
            // 
            this.loadModelToolStripMenuItem.Name = "loadModelToolStripMenuItem";
            this.loadModelToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.loadModelToolStripMenuItem.Text = "Load Model";
            this.loadModelToolStripMenuItem.Click += new System.EventHandler(this.loadModelToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllctrlAToolStripMenuItem,
            this.diselectToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.groupToolStripMenuItem,
            this.ungroupToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.editToolStripMenuItem.Text = "Select";
            // 
            // selectAllctrlAToolStripMenuItem
            // 
            this.selectAllctrlAToolStripMenuItem.Name = "selectAllctrlAToolStripMenuItem";
            this.selectAllctrlAToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.selectAllctrlAToolStripMenuItem.Text = "Select All (ctrl + a)";
            this.selectAllctrlAToolStripMenuItem.Click += new System.EventHandler(this.selectAllctrlAToolStripMenuItem_Click);
            // 
            // diselectToolStripMenuItem
            // 
            this.diselectToolStripMenuItem.Name = "diselectToolStripMenuItem";
            this.diselectToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.diselectToolStripMenuItem.Text = "Deselect (esc)";
            this.diselectToolStripMenuItem.Click += new System.EventHandler(this.diselectToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.deleteToolStripMenuItem.Text = "Delete (del)";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.groupToolStripMenuItem.Text = "Group (ctrl+g)";
            this.groupToolStripMenuItem.Click += new System.EventHandler(this.groupToolStripMenuItem_Click);
            // 
            // ungroupToolStripMenuItem
            // 
            this.ungroupToolStripMenuItem.Name = "ungroupToolStripMenuItem";
            this.ungroupToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.ungroupToolStripMenuItem.Text = "Ungroup (shift + g)";
            this.ungroupToolStripMenuItem.Click += new System.EventHandler(this.ungroupToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 500);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(956, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // speedMenu
            // 
            this.speedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pickUpSpeedButton,
            this.selectToolSpeedButton,
            this.deleteSpeedButton,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.drawEllipseSpeedButton,
            this.drawTriangleSpeedButton,
            this.DrawPentagonButton,
            this.drawLineSpeedButton,
            this.drawPointSpeedButton,
            this.BorderSizeBox,
            this.BorderSizeLabel});
            this.speedMenu.Location = new System.Drawing.Point(0, 24);
            this.speedMenu.Name = "speedMenu";
            this.speedMenu.Size = new System.Drawing.Size(956, 25);
            this.speedMenu.TabIndex = 3;
            this.speedMenu.Text = "toolStrip1";
            // 
            // pickUpSpeedButton
            // 
            this.pickUpSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pickUpSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("pickUpSpeedButton.Image")));
            this.pickUpSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pickUpSpeedButton.Name = "pickUpSpeedButton";
            this.pickUpSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.pickUpSpeedButton.Text = "toolStripButton1";
            this.pickUpSpeedButton.ToolTipText = "Select";
            this.pickUpSpeedButton.Click += new System.EventHandler(this.pickUpSpeedButton_Click);
            // 
            // selectToolSpeedButton
            // 
            this.selectToolSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectToolSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("selectToolSpeedButton.Image")));
            this.selectToolSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectToolSpeedButton.Name = "selectToolSpeedButton";
            this.selectToolSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.selectToolSpeedButton.Text = "SelectToolButton";
            this.selectToolSpeedButton.ToolTipText = "Group Select";
            this.selectToolSpeedButton.Click += new System.EventHandler(this.selectToolSpeedButton_Click);
            // 
            // deleteSpeedButton
            // 
            this.deleteSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteSpeedButton.Image = global::Draw.Properties.Resources.deleteShapeBtn;
            this.deleteSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteSpeedButton.Name = "deleteSpeedButton";
            this.deleteSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.deleteSpeedButton.Text = "deleteBtn";
            this.deleteSpeedButton.ToolTipText = "Delete";
            this.deleteSpeedButton.Click += new System.EventHandler(this.deleteSpeedButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "DrawRectangleButton";
            this.toolStripButton1.Click += new System.EventHandler(this.DrawRectangleSpeedButtonClick);
            this.toolStripButton1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripButton1_MouseUp);
            // 
            // drawEllipseSpeedButton
            // 
            this.drawEllipseSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawEllipseSpeedButton.Image = global::Draw.Properties.Resources.ellipsebitmap2;
            this.drawEllipseSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawEllipseSpeedButton.Name = "drawEllipseSpeedButton";
            this.drawEllipseSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawEllipseSpeedButton.Text = "DrawEllipseButton";
            this.drawEllipseSpeedButton.Click += new System.EventHandler(this.DrawEllipseSpeedButtonClick);
            this.drawEllipseSpeedButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawEllipseSpeedButton_MouseUp);
            // 
            // drawTriangleSpeedButton
            // 
            this.drawTriangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawTriangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawTriangleSpeedButton.Image")));
            this.drawTriangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawTriangleSpeedButton.Name = "drawTriangleSpeedButton";
            this.drawTriangleSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawTriangleSpeedButton.Text = "DrawTriangleButton";
            this.drawTriangleSpeedButton.Click += new System.EventHandler(this.DrawTriangleSpeedButtonClick);
            this.drawTriangleSpeedButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawTriangleSpeedButton_MouseUp);
            // 
            // DrawPentagonButton
            // 
            this.DrawPentagonButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawPentagonButton.Image = global::Draw.Properties.Resources.pentagon;
            this.DrawPentagonButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawPentagonButton.Name = "DrawPentagonButton";
            this.DrawPentagonButton.Size = new System.Drawing.Size(23, 22);
            this.DrawPentagonButton.Text = "DrawTriangleButton";
            this.DrawPentagonButton.Click += new System.EventHandler(this.DrawPentagonButton_Click);
            this.DrawPentagonButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawPentagonButton_MouseUp);
            // 
            // drawLineSpeedButton
            // 
            this.drawLineSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawLineSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawLineSpeedButton.Image")));
            this.drawLineSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawLineSpeedButton.Name = "drawLineSpeedButton";
            this.drawLineSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawLineSpeedButton.Text = "DrawLineButton";
            this.drawLineSpeedButton.Click += new System.EventHandler(this.DrawLineSpeedButtonClick);
            this.drawLineSpeedButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawLineSpeedButton_MouseUp);
            // 
            // drawPointSpeedButton
            // 
            this.drawPointSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawPointSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawPointSpeedButton.Image")));
            this.drawPointSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawPointSpeedButton.Name = "drawPointSpeedButton";
            this.drawPointSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawPointSpeedButton.Text = "DrawPointButton";
            this.drawPointSpeedButton.Click += new System.EventHandler(this.DrawPointSpeedButtonClick);
            this.drawPointSpeedButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawPointSpeedButton_MouseUp);
            // 
            // BorderSizeBox
            // 
            this.BorderSizeBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BorderSizeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BorderSizeBox.Name = "BorderSizeBox";
            this.BorderSizeBox.Size = new System.Drawing.Size(50, 25);
            this.BorderSizeBox.Text = "1";
            this.BorderSizeBox.Leave += new System.EventHandler(this.BorderSizeBox_Leave);
            this.BorderSizeBox.TextChanged += new System.EventHandler(this.BorderSizeBox_TextChanged);
            // 
            // BorderSizeLabel
            // 
            this.BorderSizeLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BorderSizeLabel.Name = "BorderSizeLabel";
            this.BorderSizeLabel.Size = new System.Drawing.Size(62, 22);
            this.BorderSizeLabel.Text = "BorderSize";
            // 
            // ColorsPanel
            // 
            this.ColorsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ColorsPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.ColorsPanel.ColumnCount = 2;
            this.ColorsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ColorsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ColorsPanel.Controls.Add(this.FillLabel, 1, 0);
            this.ColorsPanel.Controls.Add(this.BorderLabel, 0, 0);
            this.ColorsPanel.Controls.Add(this.BlackBorderButton, 0, 1);
            this.ColorsPanel.Controls.Add(this.RedBorderButton, 0, 3);
            this.ColorsPanel.Controls.Add(this.RedFillButton, 1, 3);
            this.ColorsPanel.Controls.Add(this.BlackFillButton, 1, 1);
            this.ColorsPanel.Controls.Add(this.WhiteBorderButton, 0, 2);
            this.ColorsPanel.Controls.Add(this.GreenBorderButton, 0, 4);
            this.ColorsPanel.Controls.Add(this.GreenFillButton, 1, 4);
            this.ColorsPanel.Controls.Add(this.WhiteFillButton, 1, 2);
            this.ColorsPanel.Controls.Add(this.BlueFillButton, 1, 5);
            this.ColorsPanel.Controls.Add(this.BlueBorderButton, 0, 5);
            this.ColorsPanel.Controls.Add(this.YellowBorderButton, 0, 6);
            this.ColorsPanel.Controls.Add(this.YellowFillButton, 1, 6);
            this.ColorsPanel.Controls.Add(this.BorderTransparency, 0, 9);
            this.ColorsPanel.Controls.Add(this.FillTransparency, 1, 9);
            this.ColorsPanel.Controls.Add(this.AlphaLabel1, 0, 8);
            this.ColorsPanel.Controls.Add(this.AlphaLabel2, 1, 8);
            this.ColorsPanel.Controls.Add(this.CusomFillColor, 1, 7);
            this.ColorsPanel.Controls.Add(this.CustomBorderColor, 0, 7);
            this.ColorsPanel.Location = new System.Drawing.Point(858, 49);
            this.ColorsPanel.Name = "ColorsPanel";
            this.ColorsPanel.RowCount = 11;
            this.ColorsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ColorsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ColorsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.ColorsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.ColorsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.ColorsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.ColorsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.ColorsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.ColorsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ColorsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.ColorsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ColorsPanel.Size = new System.Drawing.Size(99, 451);
            this.ColorsPanel.TabIndex = 6;
            // 
            // FillLabel
            // 
            this.FillLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FillLabel.Location = new System.Drawing.Point(56, 2);
            this.FillLabel.Name = "FillLabel";
            this.FillLabel.Size = new System.Drawing.Size(35, 12);
            this.FillLabel.TabIndex = 5;
            this.FillLabel.Text = "Fill";
            this.FillLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BorderLabel
            // 
            this.BorderLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BorderLabel.Location = new System.Drawing.Point(5, 2);
            this.BorderLabel.Name = "BorderLabel";
            this.BorderLabel.Size = new System.Drawing.Size(40, 12);
            this.BorderLabel.TabIndex = 4;
            this.BorderLabel.Text = "Border";
            this.BorderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BlackBorderButton
            // 
            this.BlackBorderButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BlackBorderButton.BackColor = System.Drawing.Color.Black;
            this.BlackBorderButton.Image = global::Draw.Properties.Resources.selectedWhite;
            this.BlackBorderButton.Location = new System.Drawing.Point(10, 19);
            this.BlackBorderButton.Name = "BlackBorderButton";
            this.BlackBorderButton.Size = new System.Drawing.Size(30, 30);
            this.BlackBorderButton.TabIndex = 9;
            this.BlackBorderButton.Text = "\r\n";
            this.BlackBorderButton.UseVisualStyleBackColor = false;
            this.BlackBorderButton.Click += new System.EventHandler(this.BlackBorderButton_Click);
            // 
            // RedBorderButton
            // 
            this.RedBorderButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RedBorderButton.BackColor = System.Drawing.Color.Red;
            this.RedBorderButton.Location = new System.Drawing.Point(10, 96);
            this.RedBorderButton.Name = "RedBorderButton";
            this.RedBorderButton.Size = new System.Drawing.Size(30, 30);
            this.RedBorderButton.TabIndex = 2;
            this.RedBorderButton.Text = "\r\n";
            this.RedBorderButton.UseVisualStyleBackColor = false;
            this.RedBorderButton.Click += new System.EventHandler(this.RedBorderButton_Click);
            // 
            // RedFillButton
            // 
            this.RedFillButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RedFillButton.BackColor = System.Drawing.Color.Red;
            this.RedFillButton.Location = new System.Drawing.Point(58, 96);
            this.RedFillButton.Name = "RedFillButton";
            this.RedFillButton.Size = new System.Drawing.Size(30, 30);
            this.RedFillButton.TabIndex = 3;
            this.RedFillButton.Text = "\r\n";
            this.RedFillButton.UseVisualStyleBackColor = false;
            this.RedFillButton.Click += new System.EventHandler(this.RedFillButton_Click);
            // 
            // BlackFillButton
            // 
            this.BlackFillButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BlackFillButton.BackColor = System.Drawing.Color.Black;
            this.BlackFillButton.Location = new System.Drawing.Point(58, 19);
            this.BlackFillButton.Name = "BlackFillButton";
            this.BlackFillButton.Size = new System.Drawing.Size(30, 30);
            this.BlackFillButton.TabIndex = 8;
            this.BlackFillButton.Text = "\r\n";
            this.BlackFillButton.UseVisualStyleBackColor = false;
            this.BlackFillButton.Click += new System.EventHandler(this.BlackFillButton_Click);
            // 
            // WhiteBorderButton
            // 
            this.WhiteBorderButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.WhiteBorderButton.BackColor = System.Drawing.Color.White;
            this.WhiteBorderButton.Location = new System.Drawing.Point(10, 57);
            this.WhiteBorderButton.Name = "WhiteBorderButton";
            this.WhiteBorderButton.Size = new System.Drawing.Size(30, 30);
            this.WhiteBorderButton.TabIndex = 10;
            this.WhiteBorderButton.Text = "\r\n";
            this.WhiteBorderButton.UseVisualStyleBackColor = false;
            this.WhiteBorderButton.Click += new System.EventHandler(this.WhiteBorderButton_Click);
            // 
            // GreenBorderButton
            // 
            this.GreenBorderButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GreenBorderButton.BackColor = System.Drawing.Color.Green;
            this.GreenBorderButton.Location = new System.Drawing.Point(10, 134);
            this.GreenBorderButton.Name = "GreenBorderButton";
            this.GreenBorderButton.Size = new System.Drawing.Size(30, 30);
            this.GreenBorderButton.TabIndex = 7;
            this.GreenBorderButton.Text = "\r\n";
            this.GreenBorderButton.UseVisualStyleBackColor = false;
            this.GreenBorderButton.Click += new System.EventHandler(this.GreenBorderButton_Click);
            // 
            // GreenFillButton
            // 
            this.GreenFillButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GreenFillButton.BackColor = System.Drawing.Color.Green;
            this.GreenFillButton.Location = new System.Drawing.Point(58, 134);
            this.GreenFillButton.Name = "GreenFillButton";
            this.GreenFillButton.Size = new System.Drawing.Size(30, 30);
            this.GreenFillButton.TabIndex = 6;
            this.GreenFillButton.Text = "\r\n";
            this.GreenFillButton.UseVisualStyleBackColor = false;
            this.GreenFillButton.Click += new System.EventHandler(this.GreenFillButton_Click);
            // 
            // WhiteFillButton
            // 
            this.WhiteFillButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.WhiteFillButton.BackColor = System.Drawing.Color.White;
            this.WhiteFillButton.Image = global::Draw.Properties.Resources.selectedBlack;
            this.WhiteFillButton.Location = new System.Drawing.Point(58, 57);
            this.WhiteFillButton.Name = "WhiteFillButton";
            this.WhiteFillButton.Size = new System.Drawing.Size(30, 30);
            this.WhiteFillButton.TabIndex = 11;
            this.WhiteFillButton.Text = "\r\n";
            this.WhiteFillButton.UseVisualStyleBackColor = false;
            this.WhiteFillButton.Click += new System.EventHandler(this.WhiteFillButton_Click);
            // 
            // BlueFillButton
            // 
            this.BlueFillButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BlueFillButton.BackColor = System.Drawing.Color.Blue;
            this.BlueFillButton.Location = new System.Drawing.Point(58, 172);
            this.BlueFillButton.Name = "BlueFillButton";
            this.BlueFillButton.Size = new System.Drawing.Size(30, 30);
            this.BlueFillButton.TabIndex = 12;
            this.BlueFillButton.Text = "\r\n";
            this.BlueFillButton.UseVisualStyleBackColor = false;
            this.BlueFillButton.Click += new System.EventHandler(this.BlueFillButton_Click);
            // 
            // BlueBorderButton
            // 
            this.BlueBorderButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BlueBorderButton.BackColor = System.Drawing.Color.Blue;
            this.BlueBorderButton.Location = new System.Drawing.Point(10, 172);
            this.BlueBorderButton.Name = "BlueBorderButton";
            this.BlueBorderButton.Size = new System.Drawing.Size(30, 30);
            this.BlueBorderButton.TabIndex = 13;
            this.BlueBorderButton.Text = "\r\n";
            this.BlueBorderButton.UseVisualStyleBackColor = false;
            this.BlueBorderButton.Click += new System.EventHandler(this.BlueBorderButton_Click);
            // 
            // YellowBorderButton
            // 
            this.YellowBorderButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.YellowBorderButton.BackColor = System.Drawing.Color.Yellow;
            this.YellowBorderButton.Location = new System.Drawing.Point(10, 210);
            this.YellowBorderButton.Name = "YellowBorderButton";
            this.YellowBorderButton.Size = new System.Drawing.Size(30, 30);
            this.YellowBorderButton.TabIndex = 15;
            this.YellowBorderButton.Text = "\r\n";
            this.YellowBorderButton.UseVisualStyleBackColor = false;
            this.YellowBorderButton.Click += new System.EventHandler(this.YellowBorderButton_Click);
            // 
            // YellowFillButton
            // 
            this.YellowFillButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.YellowFillButton.BackColor = System.Drawing.Color.Yellow;
            this.YellowFillButton.Location = new System.Drawing.Point(58, 210);
            this.YellowFillButton.Name = "YellowFillButton";
            this.YellowFillButton.Size = new System.Drawing.Size(30, 30);
            this.YellowFillButton.TabIndex = 14;
            this.YellowFillButton.Text = "\r\n";
            this.YellowFillButton.UseVisualStyleBackColor = false;
            this.YellowFillButton.Click += new System.EventHandler(this.YellowFillButton_Click);
            // 
            // BorderTransparency
            // 
            this.BorderTransparency.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BorderTransparency.Location = new System.Drawing.Point(5, 309);
            this.BorderTransparency.Maximum = 255;
            this.BorderTransparency.Name = "BorderTransparency";
            this.BorderTransparency.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.BorderTransparency.Size = new System.Drawing.Size(40, 142);
            this.BorderTransparency.TabIndex = 17;
            this.BorderTransparency.Value = 255;
            this.BorderTransparency.Scroll += new System.EventHandler(this.BorderTransparency_Scroll);
            // 
            // FillTransparency
            // 
            this.FillTransparency.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FillTransparency.Location = new System.Drawing.Point(53, 309);
            this.FillTransparency.Maximum = 255;
            this.FillTransparency.Name = "FillTransparency";
            this.FillTransparency.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.FillTransparency.Size = new System.Drawing.Size(41, 142);
            this.FillTransparency.TabIndex = 16;
            this.FillTransparency.Value = 255;
            this.FillTransparency.Scroll += new System.EventHandler(this.FillTransparency_Scroll);
            // 
            // AlphaLabel1
            // 
            this.AlphaLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.AlphaLabel1.AutoSize = true;
            this.AlphaLabel1.Location = new System.Drawing.Point(8, 284);
            this.AlphaLabel1.Name = "AlphaLabel1";
            this.AlphaLabel1.Size = new System.Drawing.Size(34, 20);
            this.AlphaLabel1.TabIndex = 18;
            this.AlphaLabel1.Text = "Alpha";
            this.AlphaLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlphaLabel2
            // 
            this.AlphaLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.AlphaLabel2.AutoSize = true;
            this.AlphaLabel2.Location = new System.Drawing.Point(56, 284);
            this.AlphaLabel2.Name = "AlphaLabel2";
            this.AlphaLabel2.Size = new System.Drawing.Size(34, 20);
            this.AlphaLabel2.TabIndex = 19;
            this.AlphaLabel2.Text = "Alpha";
            this.AlphaLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CusomFillColor
            // 
            this.CusomFillColor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CusomFillColor.BackColor = System.Drawing.Color.Yellow;
            this.CusomFillColor.Image = global::Draw.Properties.Resources.custom_color;
            this.CusomFillColor.Location = new System.Drawing.Point(58, 248);
            this.CusomFillColor.Name = "CusomFillColor";
            this.CusomFillColor.Size = new System.Drawing.Size(30, 30);
            this.CusomFillColor.TabIndex = 21;
            this.CusomFillColor.Text = "\r\n";
            this.CusomFillColor.UseVisualStyleBackColor = false;
            this.CusomFillColor.Click += new System.EventHandler(this.CusomFillColor_Click);
            // 
            // CustomBorderColor
            // 
            this.CustomBorderColor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CustomBorderColor.BackColor = System.Drawing.SystemColors.Control;
            this.CustomBorderColor.Image = global::Draw.Properties.Resources.custom_color;
            this.CustomBorderColor.Location = new System.Drawing.Point(10, 248);
            this.CustomBorderColor.Name = "CustomBorderColor";
            this.CustomBorderColor.Size = new System.Drawing.Size(30, 30);
            this.CustomBorderColor.TabIndex = 20;
            this.CustomBorderColor.Text = "\r\n";
            this.CustomBorderColor.UseVisualStyleBackColor = false;
            this.CustomBorderColor.Click += new System.EventHandler(this.CustomBorderColor_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.Ylabel);
            this.panel1.Controls.Add(this.Xlabel);
            this.panel1.Controls.Add(this.sizetextboxY);
            this.panel1.Controls.Add(this.sizetextboxX);
            this.panel1.Controls.Add(this.resizeBtn);
            this.panel1.Controls.Add(this.rotateBox);
            this.panel1.Controls.Add(this.Rotate);
            this.panel1.Location = new System.Drawing.Point(0, 384);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 116);
            this.panel1.TabIndex = 7;
            // 
            // Ylabel
            // 
            this.Ylabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Ylabel.AutoSize = true;
            this.Ylabel.Location = new System.Drawing.Point(162, 59);
            this.Ylabel.Name = "Ylabel";
            this.Ylabel.Size = new System.Drawing.Size(14, 13);
            this.Ylabel.TabIndex = 6;
            this.Ylabel.Text = "Y";
            // 
            // Xlabel
            // 
            this.Xlabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Xlabel.AutoSize = true;
            this.Xlabel.Location = new System.Drawing.Point(114, 59);
            this.Xlabel.Name = "Xlabel";
            this.Xlabel.Size = new System.Drawing.Size(14, 13);
            this.Xlabel.TabIndex = 5;
            this.Xlabel.Text = "X";
            // 
            // sizetextboxY
            // 
            this.sizetextboxY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.sizetextboxY.Location = new System.Drawing.Point(145, 75);
            this.sizetextboxY.Name = "sizetextboxY";
            this.sizetextboxY.Size = new System.Drawing.Size(46, 20);
            this.sizetextboxY.TabIndex = 4;
            this.sizetextboxY.TextChanged += new System.EventHandler(this.sizetextboxY_TextChanged);
            this.sizetextboxY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sizetextboxY_KeyDown);
            this.sizetextboxY.Leave += new System.EventHandler(this.sizetextboxY_Leave);
            // 
            // sizetextboxX
            // 
            this.sizetextboxX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.sizetextboxX.Location = new System.Drawing.Point(94, 75);
            this.sizetextboxX.Name = "sizetextboxX";
            this.sizetextboxX.Size = new System.Drawing.Size(45, 20);
            this.sizetextboxX.TabIndex = 3;
            this.sizetextboxX.TextChanged += new System.EventHandler(this.sizetextboxX_TextChanged);
            this.sizetextboxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sizetextboxX_KeyDown);
            this.sizetextboxX.Leave += new System.EventHandler(this.sizetextboxX_Leave);
            // 
            // resizeBtn
            // 
            this.resizeBtn.Location = new System.Drawing.Point(13, 75);
            this.resizeBtn.Name = "resizeBtn";
            this.resizeBtn.Size = new System.Drawing.Size(75, 23);
            this.resizeBtn.TabIndex = 2;
            this.resizeBtn.Text = "Resize";
            this.resizeBtn.UseVisualStyleBackColor = true;
            this.resizeBtn.Click += new System.EventHandler(this.resizeBtn_Click);
            // 
            // rotateBox
            // 
            this.rotateBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.rotateBox.Location = new System.Drawing.Point(94, 18);
            this.rotateBox.Name = "rotateBox";
            this.rotateBox.Size = new System.Drawing.Size(46, 20);
            this.rotateBox.TabIndex = 1;
            this.rotateBox.TextChanged += new System.EventHandler(this.rotateBox_TextChanged);
            this.rotateBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rotateBox_KeyDown);
            this.rotateBox.MouseLeave += new System.EventHandler(this.rotateBox_MouseLeave);
            // 
            // Rotate
            // 
            this.Rotate.Location = new System.Drawing.Point(13, 16);
            this.Rotate.Name = "Rotate";
            this.Rotate.Size = new System.Drawing.Size(75, 23);
            this.Rotate.TabIndex = 0;
            this.Rotate.Text = "Rotate";
            this.Rotate.UseVisualStyleBackColor = true;
            this.Rotate.Click += new System.EventHandler(this.Rotate_Click);
            // 
            // SceneList
            // 
            this.SceneList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SceneList.AutoScroll = true;
            this.SceneList.BackColor = System.Drawing.SystemColors.Control;
            this.SceneList.Controls.Add(this.labelPanel);
            this.SceneList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.SceneList.Location = new System.Drawing.Point(0, 49);
            this.SceneList.Name = "SceneList";
            this.SceneList.Size = new System.Drawing.Size(200, 329);
            this.SceneList.TabIndex = 8;
            this.SceneList.WrapContents = false;
            // 
            // labelPanel
            // 
            this.labelPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelPanel.Controls.Add(this.ListLabel);
            this.labelPanel.Location = new System.Drawing.Point(3, 3);
            this.labelPanel.Name = "labelPanel";
            this.labelPanel.Size = new System.Drawing.Size(194, 29);
            this.labelPanel.TabIndex = 0;
            // 
            // ListLabel
            // 
            this.ListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListLabel.AutoSize = true;
            this.ListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListLabel.Location = new System.Drawing.Point(41, 4);
            this.ListLabel.Name = "ListLabel";
            this.ListLabel.Size = new System.Drawing.Size(126, 20);
            this.ListLabel.TabIndex = 0;
            this.ListLabel.Text = "Scene Shapes";
            // 
            // viewPort
            // 
            this.viewPort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewPort.AutoScroll = true;
            this.viewPort.AutoSize = true;
            this.viewPort.BackColor = System.Drawing.SystemColors.Window;
            this.viewPort.Location = new System.Drawing.Point(203, 49);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(654, 451);
            this.viewPort.TabIndex = 4;
            this.viewPort.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPortPaint);
            this.viewPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.viewPort_KeyDown);
            this.viewPort.KeyUp += new System.Windows.Forms.KeyEventHandler(this.viewPort_KeyUp);
            this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseDown);
            this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseMove);
            this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseUp);
            this.viewPort.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.viewPort_PreviewKeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(956, 522);
            this.Controls.Add(this.SceneList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ColorsPanel);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.speedMenu);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "VectorDraw";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.speedMenu.ResumeLayout(false);
            this.speedMenu.PerformLayout();
            this.ColorsPanel.ResumeLayout(false);
            this.ColorsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BorderTransparency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FillTransparency)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.SceneList.ResumeLayout(false);
            this.labelPanel.ResumeLayout(false);
            this.labelPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
		private Draw.DoubleBufferedPanel viewPort;
		private System.Windows.Forms.ToolStripButton pickUpSpeedButton;
		private System.Windows.Forms.ToolStripButton drawEllipseSpeedButton;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStrip speedMenu;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton drawLineSpeedButton;
        private System.Windows.Forms.ToolStripButton drawPointSpeedButton;
        private System.Windows.Forms.ToolStripButton drawTriangleSpeedButton;
        private System.Windows.Forms.TableLayoutPanel ColorsPanel;
        private System.Windows.Forms.Button RedBorderButton;
        private System.Windows.Forms.Button RedFillButton;
        private System.Windows.Forms.Label FillLabel;
        private System.Windows.Forms.Label BorderLabel;
        private System.Windows.Forms.Button GreenBorderButton;
        private System.Windows.Forms.Button GreenFillButton;
        private System.Windows.Forms.Button BlackBorderButton;
        private System.Windows.Forms.Button BlackFillButton;
        private System.Windows.Forms.Button WhiteBorderButton;
        private System.Windows.Forms.Button WhiteFillButton;
        private System.Windows.Forms.Button BlueBorderButton;
        private System.Windows.Forms.Button BlueFillButton;
        private System.Windows.Forms.Button YellowBorderButton;
        private System.Windows.Forms.Button YellowFillButton;
        private System.Windows.Forms.TrackBar FillTransparency;
        private System.Windows.Forms.TrackBar BorderTransparency;
        private System.Windows.Forms.Label AlphaLabel2;
        private System.Windows.Forms.Label AlphaLabel1;
        private System.Windows.Forms.ToolStripTextBox BorderSizeBox;
        private System.Windows.Forms.ToolStripLabel BorderSizeLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Rotate;
        private System.Windows.Forms.TextBox rotateBox;
        private System.Windows.Forms.Button resizeBtn;
        private System.Windows.Forms.TextBox sizetextboxY;
        private System.Windows.Forms.TextBox sizetextboxX;
        private System.Windows.Forms.Label Ylabel;
        private System.Windows.Forms.Label Xlabel;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripButton selectToolSpeedButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem diselectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ungroupToolStripMenuItem;
        private System.Windows.Forms.Button CusomFillColor;
        private System.Windows.Forms.Button CustomBorderColor;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.FlowLayoutPanel SceneList;
        private System.Windows.Forms.Panel labelPanel;
        private System.Windows.Forms.Label ListLabel;
        private System.Windows.Forms.ToolStripButton deleteSpeedButton;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllctrlAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton DrawPentagonButton;
    }
}
