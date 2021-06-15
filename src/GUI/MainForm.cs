using Draw.src.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Draw
{
	/// <summary>
	/// Върху главната форма е поставен потребителски контрол,
	/// в който се осъществява визуализацията
	/// </summary>
	public partial class MainForm : Form
	{
		//for color picking feature
		public bool ColorPicking = false;

		//for detecting multiple key presses
		bool ctrl_down = false;
		bool shift_down = false;
		bool e_down = false;
		/// <summary>
		/// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
		/// </summary>
		private DialogProcessor dialogProcessor = new DialogProcessor();

		//adding different cursors for different actions
		Cursor delCursor = new Cursor(Properties.Resources.deleteShapeBtn.GetHicon());

		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			dialogProcessor.sceneItemsList = SceneList;
			dialogProcessor.viewPort = viewPort;
			dialogProcessor.rotateBox = rotateBox;
			dialogProcessor.scaleYbox = sizetextboxY;
			dialogProcessor.scaleXbox = sizetextboxX;
			this.KeyPreview = true;
			pickUpSpeedButton.Checked = true;

			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		/// <summary>
		/// Изход от програмата. Затваря главната форма, а с това и програмата.
		/// </summary>
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
		/// </summary>
		/// 

		void ViewPortPaint(object sender, PaintEventArgs e)
		{
			dialogProcessor.ReDraw(sender, e);
			if (selectToolSpeedButton.Checked) {
				dialogProcessor.DrawSelection(sender, e);
			}
			if (dialogProcessor.Selections.Count > 0) {
				dialogProcessor.DrawSelection(e.Graphics);
			}
		}

		/// <summary>
		/// Бутон, който поставя на произволно място правоъгълник със зададените размери.
		/// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
		/// </summary>

		void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomRectangle();
			
			statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";
			
			viewPort.Invalidate();
		}

		void DrawEllipseSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomEllipse();

			statusBar.Items[0].Text = "Последно действие: Рисуване на елипса";

			viewPort.Invalidate();
		}

		void DrawLineSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomLine();

			statusBar.Items[0].Text = "Последно действие: Рисуване на линия";

			viewPort.Invalidate();
		}
		void DrawPointSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomPoint();

			statusBar.Items[0].Text = "Последно действие: Рисуване на точка";

			viewPort.Invalidate();
		}

		void DrawTriangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomTriangle();

			statusBar.Items[0].Text = "Последно действие: Рисуване на триъгълник";

			viewPort.Invalidate();
		}

		private void DrawPentagonButton_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomPentagon();

			statusBar.Items[0].Text = "Последно действие: Рисуване на петоъгълник";

			viewPort.Invalidate();
		}

		//method for color picking from scene
		public Color GetColorAt(Point location)
		{
			Rectangle bsize = viewPort.ClientRectangle;
			Bitmap b = new Bitmap(bsize.Width, bsize.Height);
			viewPort.DrawToBitmap(b, bsize);
			Color c = b.GetPixel(location.X,location.Y);
			return c;
		}

		/// <summary>
		/// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
		/// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
		/// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
		/// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
		/// </summary>
		void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			List<Shape> shapesToDeselect = new List<Shape>();
			//dont allow right click selecting with other tools except pickup
			if (e.Button == MouseButtons.Right)
			{
				if (!pickUpSpeedButton.Checked)
				{
					return;
				}
			}
			//detect normal click and the specific mode the user is in when clicking
			if (ctrl_down) {
				dialogProcessor.MultiSelect = true;
			}
			if (ColorPicking)
			{
				ColorPicking = false;
				Color chosen = GetColorAt(e.Location);
				if (selectedType == "border")
				{
					CustomColor popup = new CustomColor(this, dialogProcessor, "Border Color", chosen);
					popup.ShowDialog();
				}
				else if (selectedType == "fill")
				{
					CustomColor popup = new CustomColor(this, dialogProcessor, "Fill Color", chosen);
					popup.ShowDialog();
				}
			}
			else {
				if (deleteSpeedButton.Checked) {
					if (dialogProcessor.ContainsPoint(e.Location) != null) {
						dialogProcessor.DeleteShape(dialogProcessor.ContainsPoint(e.Location));
					}
				}
				if (pickUpSpeedButton.Checked)
				{
					if (dialogProcessor.ContainsPoint(e.Location) != null)
					{
						Shape s = dialogProcessor.ContainsPoint(e.Location);
						if (s is GroupShape)
						{
							GroupShape gr = (GroupShape)s;
							List<Shape> grShapes = gr.ReturnGroup();
							bool deselect = true;
							foreach (Shape containedShape in grShapes)
							{
								if (dialogProcessor.Selections.Contains(containedShape))
								{
									if (ctrl_down) {
										shapesToDeselect.Add(containedShape);
									}
									deselect = false;
									break;
								}
							}
							if (deselect)
							{
								if (!ctrl_down) {
									dialogProcessor.DeselectAll();
								}
							}
						}
						//if it was clicked on a selected shape while holding control deselect that shape
						if (ctrl_down && dialogProcessor.Selections.Contains(s)) {
							shapesToDeselect.Add(s);
						}
						if (!dialogProcessor.Selections.Contains(s) && !(s is GroupShape))
						{
							if (!ctrl_down) {
								dialogProcessor.MultiSelect = false;
								dialogProcessor.Selections.Clear();
								dialogProcessor.DeselectAllBtns();
							}
							dialogProcessor.Selections.Add(s);
							if (dialogProcessor.Selections.Count < 2) {
								dialogProcessor.MultiSelect = false;
							}
							foreach (Button b in dialogProcessor.buttonList) {
								if (b.Text==s.name) {
									dialogProcessor.SelectBtn(b);
									break;
								}
							}
						}
						else if (!dialogProcessor.Selections.Contains(s) && s is GroupShape)
						{
							GroupShape grp = (GroupShape)s;
							if (dialogProcessor.MultiSelect)
							{
								dialogProcessor.Selections.Remove(s);
							}
							else
							{
								if (!ctrl_down) {
									dialogProcessor.Selections.Clear();
									dialogProcessor.DeselectAllBtns();
								}
							}
							foreach (Shape shp in grp.Group)
							{
								if (!dialogProcessor.Selections.Contains(shp))
								{
									dialogProcessor.Selections.Add(shp);
								}
							}
							foreach (Button b in dialogProcessor.buttonList)
							{
								if (b.Text == s.name)
								{
									dialogProcessor.SelectBtn(b);
									break;
								}
							}
						}
					}
					else
					{
						dialogProcessor.Selections.Clear();
						dialogProcessor.DeselectAllBtns();
						dialogProcessor.MultiSelect = false;
					}
					if (dialogProcessor.Selections.Count == 1)
					{
						statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
						dialogProcessor.IsDragging = true;
						dialogProcessor.LastLocation = e.Location;
						rotateBox.Text = dialogProcessor.Selections[0].angle.ToString();
						sizetextboxX.Text = dialogProcessor.Selections[0].scaleX.ToString();
						sizetextboxY.Text = dialogProcessor.Selections[0].scaleY.ToString();
					}
					if (dialogProcessor.Selections.Count > 1)
					{
						statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
						dialogProcessor.IsDragging = true;
						dialogProcessor.LastLocation = e.Location;
						double angl = dialogProcessor.Selections[0].angle;
						double scX = dialogProcessor.Selections[0].scaleX;
						double scY = dialogProcessor.Selections[0].scaleY;
						bool anglK = true;
						bool scXK = true;
						bool scYK = true;
						//check if all selected shapes have the same angle and scale
						foreach (Shape s in dialogProcessor.Selections)
						{
							if (s.angle != angl)
							{
								anglK = false;
							}
							if (s.scaleX != scX)
							{
								scXK = false;
							}
							if (s.scaleY != scY)
							{
								scXK = false;
							}
						}
						//if they dont then clear the scale and rotate boxes
						if (anglK)
						{
							rotateBox.Text = angl.ToString();
						}
						else
						{
							rotateBox.Text = "";
						}
						if (scXK)
						{
							sizetextboxX.Text = scX.ToString();
						}
						else
						{
							sizetextboxX.Text = "";
						}
						if (scYK)
						{
							sizetextboxY.Text = scY.ToString();
						}
						else
						{
							sizetextboxY.Text = "";
						}
					}
					if (dialogProcessor.Selections.Count == 0)
					{
						rotateBox.Text = "";
						sizetextboxX.Text = "";
						sizetextboxY.Text = "";
					}
					viewPort.Invalidate();
				}
				if (selectToolSpeedButton.Checked)
				{
					dialogProcessor.CreateSelection(new PointF(e.X, e.Y));

					statusBar.Items[0].Text = "Последно действие: Множествена селекция";

					viewPort.Invalidate();
				}
			}

			//if it was right clicked open options menu for the selected shapes
			if (e.Button == MouseButtons.Right)
			{
				ContextMenuStrip cm = new ContextMenuStrip();
				cm.Items.Add("Select ALL (ctrl + a)");
				cm.Items.Add("Deselect ALL (esc)");
				RightClickOpenCM(cm);
				RightClickCloseCM(cm);
				viewPort.ContextMenuStrip = cm;
			}

			if (shapesToDeselect.Count > 0) {
				List<GroupShape> DeselectedGroups = new List<GroupShape>();
				foreach (Shape std in shapesToDeselect) {
					if (!std.Grouped)
					{
						dialogProcessor.Selections.Remove(std);
						foreach (Button b in dialogProcessor.buttonList)
						{
							if (b.Text == std.name)
							{
								dialogProcessor.DeselectBtn(b);
								break;
							}
						}
					}
					else {
                        for (int i = 0; i < dialogProcessor.ShapeList.Count; i++)
                        {
							if (dialogProcessor.ShapeList[i] is GroupShape) {
								GroupShape grp = (GroupShape)dialogProcessor.ShapeList[i];
								if (grp.ContainsMember(std) && !DeselectedGroups.Contains(grp))
								{
									foreach (Shape element in grp.Group) {
										dialogProcessor.Selections.Remove(element);
										foreach (Button b in dialogProcessor.buttonList)
										{
											if (b.Text == grp.name)
											{
												dialogProcessor.DeselectBtn(b);
												break;
											}
										}
									}
									DeselectedGroups.Add(grp);
								}
							}
						}
					}
				}
			}
		}//end of mouse click function

		void RightClickOpenCM(ContextMenuStrip cm) {
			cm.Opening += (sender, e) =>
			{
				if (dialogProcessor.CopiedShapes.Count > 0 || dialogProcessor.CutShapes.Count > 0) {
					cm.Items.Add("Paste (ctrl + v)");
				}
				if (dialogProcessor.Selections.Count > 0) {
					cm.Items.Add("Change Fill Color");
					cm.Items.Add("Change Border Color");
					cm.Items.Add("Copy (ctrl + c)");
					cm.Items.Add("Cut (ctrl + x)");
					cm.Items.Add("Delete (del)");
				}
				if (dialogProcessor.Selections.Count > 1)
				{
					bool addGroup = true;
					bool addUngroup = false;
					//check if all selections aren't a part of a single group
					List<GroupShape> SelectedGroups = new List<GroupShape>();
					foreach (Shape s in dialogProcessor.Selections) {
						if (s.Grouped)
						{
							foreach (Shape pg in dialogProcessor.ShapeList) {
								if (pg is GroupShape) {
									GroupShape g = (GroupShape)pg;
									if (g.ContainsMember(s))
									{
										if (!SelectedGroups.Contains(g))
										{
											SelectedGroups.Add(g);
										}
									}
								}
							}
						}
						else {
							addGroup = true;
							addUngroup = false;
							break;
						}
					}
					if (SelectedGroups.Count > 1)
					{
						addGroup = true;
						addUngroup = false;
					}
					else if (SelectedGroups.Count == 1) {
						bool ung = true;
                        for (int i = 0; i < dialogProcessor.Selections.Count; i++)
                        {
							if (!SelectedGroups[0].ContainsMember(dialogProcessor.Selections[i])) {
								ung = false;
								break;
							}
                        }
						if (ung) {
							addGroup = false;
							addUngroup = true;
						}
					}
					if (addGroup) {
						cm.Items.Add("Group (ctrl + g)");
					}
					if (addUngroup) {
						cm.Items.Add("Ungroup (shift + g)");
					}
				}
				RightClickMenuFuns(cm);
			};
		}

		void RightClickCloseCM(ContextMenuStrip cm)
		{
			cm.Closing += (sender, e) => {
				cm.Items.Clear();
				cm.Items.Add("Select ALL (ctrl + a)");
				cm.Items.Add("Deselect ALL (esc)");
			};
		}

		void RightClickMenuFuns(ContextMenuStrip cm)
		{
			for (int i = 0; i < cm.Items.Count; i++)
			{
				if (cm.Items[i].Text == "Select ALL (ctrl + a)")
				{
					cm.Items[i].Click += (sender, e) => {
						dialogProcessor.SelectAllShapes();
					};
				}
				if (cm.Items[i].Text == "Deselect ALL (esc)")
				{
					cm.Items[i].Click += (sender, e) => {
						dialogProcessor.DeselectAll();
						viewPort.Invalidate();
					};
				}
				if (cm.Items[i].Text == "Paste (ctrl + v)")
				{
					cm.Items[i].Click += (sender, e) => {
						dialogProcessor.PasteClipboard();
					};
				}
				if (cm.Items[i].Text == "Delete (del)")
				{
					cm.Items[i].Click += (sender, e) => {
						dialogProcessor.DeleteAllSelected();
					};
				}
				if (cm.Items[i].Text == "Copy (ctrl + c)")
				{
					cm.Items[i].Click += (sender, e) => {
						dialogProcessor.CopySelected();
					};
				}
				if (cm.Items[i].Text == "Cut (ctrl + x)")
				{
					cm.Items[i].Click += (sender, e) => {
						dialogProcessor.CutSelected();
					};
				}
				if (cm.Items[i].Text == "Group (ctrl + g)")
				{
					cm.Items[i].Click += (sender, e) => {
						dialogProcessor.CreateGroup();
					};
				}
				if (cm.Items[i].Text == "Ungroup (shift + g)")
				{
					cm.Items[i].Click += (sender, e) => {
						dialogProcessor.Ungroup();
						dialogProcessor.DeselectAll();
						viewPort.Invalidate();
					};
				}
				if (cm.Items[i].Text == "Change Fill Color")
				{
					cm.Items[i].Click += (sender, e) => {
						ColorDialog clDialog = new ColorDialog();

						//show the color dialog and wait for ok click
						if (clDialog.ShowDialog() == DialogResult.OK)
						{
							//apply chosen color
							Color newC = Color.FromArgb(dialogProcessor.FillAlpha, clDialog.Color);
							foreach (Shape forColoring in dialogProcessor.Selections)
							{
								forColoring.FillColor = newC;
							}
							viewPort.Invalidate();
						}
					};
				}
				if (cm.Items[i].Text == "Change Border Color")
				{
					cm.Items[i].Click += (sender, e) => {
						ColorDialog clDialog = new ColorDialog();
						//show the color dialog and wait for ok click
						if (clDialog.ShowDialog() == DialogResult.OK)
						{
							//apply chosen color
							Color newC = Color.FromArgb(dialogProcessor.BorderAlpha, clDialog.Color);
							foreach (Shape forColoring in dialogProcessor.Selections)
							{
								forColoring.BorderColor = newC;
							}
							viewPort.Invalidate();
						}
					};
				}
			}
		}

		/// <summary>
		/// Прихващане на преместването на мишката.
		/// Ако сме в режм на "влачене", то избрания елемент се транслира.
		/// </summary>
		void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (dialogProcessor.IsDragging) {
				if (dialogProcessor.Selections[0] != null) statusBar.Items[0].Text = "Последно действие: Влачене";
				dialogProcessor.TranslateTo(e.Location);
				viewPort.Invalidate();
			}
			if (selectToolSpeedButton.Checked && dialogProcessor.SelectRect!=null)
			{
				float w = e.X-dialogProcessor.SelectRect.Location.X;
				float h = e.Y - dialogProcessor.SelectRect.Location.Y;
				dialogProcessor.ChangeSelection(w, h);
				viewPort.Invalidate();
			}
		}

		/// <summary>
		/// Прихващане на отпускането на бутона на мишката.
		/// Излизаме от режим "влачене".
		/// </summary>
		
		void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dialogProcessor.IsDragging = false;
			if (selectToolSpeedButton.Checked) {
				dialogProcessor.CheckMultiSelection();
				viewPort.Invalidate();
			}
		}

		//Set Colors
		public string selectedType = "";
		public void ClearSelectedBorderIcon()
        {
			BlackBorderButton.Image = null;
			RedBorderButton.Image = null;
			WhiteBorderButton.Image = null;
			BlueBorderButton.Image = null;
			GreenBorderButton.Image = null;
			YellowBorderButton.Image = null;
		}
		public void ClearSelectedFillIcon()
		{
			BlackFillButton.Image = null;
			RedFillButton.Image = null;
			WhiteFillButton.Image = null;
			BlueFillButton.Image = null;
			GreenFillButton.Image = null;
			YellowFillButton.Image = null;
		}
		private void RedBorderButton_Click(object sender, EventArgs e)
        {
			dialogProcessor.SetBorderColor(Color.Red);
			ClearSelectedBorderIcon();
			RedBorderButton.Image = Draw.Properties.Resources.selectedBlack;
			dialogProcessor.SetBorderTransparency(BorderTransparency.Value);
		}

        private void RedFillButton_Click(object sender, EventArgs e)
        {
			dialogProcessor.SetFillColor(Color.Red);
			ClearSelectedFillIcon();
			RedFillButton.Image = Draw.Properties.Resources.selectedBlack;
			dialogProcessor.SetFillTransparency(FillTransparency.Value);
		}

        private void GreenBorderButton_Click(object sender, EventArgs e)
        {
			dialogProcessor.SetBorderColor(Color.Green);
			ClearSelectedBorderIcon();
			GreenBorderButton.Image = Draw.Properties.Resources.selectedBlack;
			dialogProcessor.SetBorderTransparency(BorderTransparency.Value);
		}

        private void GreenFillButton_Click(object sender, EventArgs e)
        {
			dialogProcessor.SetFillColor(Color.Green);
			ClearSelectedFillIcon();
			GreenFillButton.Image = Draw.Properties.Resources.selectedBlack;
			dialogProcessor.SetFillTransparency(FillTransparency.Value);
		}

        private void BlackBorderButton_Click(object sender, EventArgs e)
        {
			dialogProcessor.SetBorderColor(Color.Black);
			ClearSelectedBorderIcon();
			BlackBorderButton.Image = Draw.Properties.Resources.selectedWhite;
			dialogProcessor.SetBorderTransparency(BorderTransparency.Value);
		}

        private void BlackFillButton_Click(object sender, EventArgs e)
        {
			dialogProcessor.SetFillColor(Color.Black);
			ClearSelectedFillIcon();
			BlackFillButton.Image = Draw.Properties.Resources.selectedWhite;
			dialogProcessor.SetFillTransparency(FillTransparency.Value);
		}

        private void WhiteBorderButton_Click(object sender, EventArgs e)
        {
			dialogProcessor.SetBorderColor(Color.White);
			ClearSelectedBorderIcon();
			WhiteBorderButton.Image = Draw.Properties.Resources.selectedBlack;
			dialogProcessor.SetBorderTransparency(BorderTransparency.Value);
		}

        private void WhiteFillButton_Click(object sender, EventArgs e)
        {
			dialogProcessor.SetFillColor(Color.White);
			ClearSelectedFillIcon();
			WhiteFillButton.Image = Draw.Properties.Resources.selectedBlack;
			dialogProcessor.SetFillTransparency(FillTransparency.Value);
		}

        private void BlueBorderButton_Click(object sender, EventArgs e)
        {
			dialogProcessor.SetBorderColor(Color.Blue);
			ClearSelectedBorderIcon();
			BlueBorderButton.Image = Draw.Properties.Resources.selectedBlack;
			dialogProcessor.SetBorderTransparency(BorderTransparency.Value);
		}

        private void BlueFillButton_Click(object sender, EventArgs e)
        {
			dialogProcessor.SetFillColor(Color.Blue);
			ClearSelectedFillIcon();
			BlueFillButton.Image = Draw.Properties.Resources.selectedBlack;
			dialogProcessor.SetFillTransparency(FillTransparency.Value);
		}

        private void YellowBorderButton_Click(object sender, EventArgs e)
        {
			dialogProcessor.SetBorderColor(Color.Yellow);
			ClearSelectedBorderIcon();
			YellowBorderButton.Image = Draw.Properties.Resources.selectedBlack;
			dialogProcessor.SetBorderTransparency(BorderTransparency.Value);
		}

        private void YellowFillButton_Click(object sender, EventArgs e)
        {
			dialogProcessor.SetFillColor(Color.Yellow);
			ClearSelectedFillIcon();
			YellowFillButton.Image = Draw.Properties.Resources.selectedBlack;
			dialogProcessor.SetFillTransparency(FillTransparency.Value);
		}

		private void CustomBorderColor_Click(object sender, EventArgs e)
		{
			selectedType = "border";
			CustomColor popup = new CustomColor(this,dialogProcessor,"Border Color");
			popup.ShowDialog();
		}

		private void CusomFillColor_Click(object sender, EventArgs e)
		{
			selectedType = "fill";
			CustomColor popup = new CustomColor(this,dialogProcessor,"Fill Color");
			popup.ShowDialog();
		}

		private void BorderTransparency_Scroll(object sender, EventArgs e)
        {
			dialogProcessor.SetBorderTransparency(BorderTransparency.Value);
        }

        private void FillTransparency_Scroll(object sender, EventArgs e)
        {
			dialogProcessor.SetFillTransparency(FillTransparency.Value);
		}

		public void SetBorderTransDial(int value) {
			BorderTransparency.Value = value;
		}

		public void SetFillTransDial(int value)
		{
			FillTransparency.Value = value;
		}

		private char[] allowedSymbols = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '\0', ' ' };
        private void BorderSizeBox_TextChanged(object sender, EventArgs e)
        {
			string s = BorderSizeBox.Text;
			bool allgood = true;
			foreach (char c in s) {
				bool found = false;
				for (int i = 0; i < 12;i++) {
					if (allowedSymbols[i] == c)
					{
						found = true;
					}
				}
				if (found == false){
					allgood = false;
					break;
				}
			}
			int f = 1;
			if (allgood)
			{
				if (s != "" && s != " " && s!="0" && !s.Contains(" "))
				{
					f = int.Parse(s);
					dialogProcessor.SelectedBorderSize = f;
					BorderSizeBox.Text = f.ToString();
				}
			}
			else {
				dialogProcessor.SelectedBorderSize = f;
				BorderSizeBox.Text = f.ToString();
			}

		}

        private void BorderSizeBox_Leave(object sender, EventArgs e)
        {
			if (BorderSizeBox.Text == "" || BorderSizeBox.Text == "0" || BorderSizeBox.Text.Contains(" ")) {
				BorderSizeBox.Text = "1";
				dialogProcessor.SelectedBorderSize = 1;
			}
		}

        private void Rotate_Click(object sender, EventArgs e)
        {
			if (rotateBox.Text != "" && !rotateBox.Text.Contains(" ") && dialogProcessor.Selections[0] != null) {
				statusBar.Items[0].Text = "Последно действие: Завъртане";
				dialogProcessor.Rotate(float.Parse(rotateBox.Text));
				viewPort.Invalidate();
			}
		}
		private char[] allowedSymbols2 = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '\0', ' ','-' };

		private void rotateBox_TextChanged(object sender, EventArgs e)
        {
			if (dialogProcessor.Selections.Count>0)
			{
				string s = rotateBox.Text;
				bool allgood = true;
				foreach (char c in s)
				{
					bool found = false;
					for (int i = 0; i < allowedSymbols2.Length; i++)
					{
						if (allowedSymbols2[i] == c)
						{
							found = true;
							break;
						}
					}
					if (found == false)
					{
						allgood = false;
						break;
					}
				}
				int r = (int)dialogProcessor.Selections[0].angle;
				if (!allgood)
				{
					rotateBox.Text = r.ToString();
				}
			}
			else {
				rotateBox.Clear();
			}
		}

        private void rotateBox_MouseLeave(object sender, EventArgs e)
        {
			if (dialogProcessor.Selections.Count>0)
			{
				string s = rotateBox.Text;
				if (s == "" || s == " " || s.Contains(" "))
				{
					rotateBox.Text = dialogProcessor.Selections[0].angle.ToString();
				}
			}
			else {
				rotateBox.Clear();
			}
		}

        private void resizeBtn_Click(object sender, EventArgs e)
        {
			if (sizetextboxX.Text != "" && !sizetextboxX.Text.Contains(" ") && sizetextboxY.Text != "" && !sizetextboxY.Text.Contains(" ") && sizetextboxY.Text != "." && sizetextboxX.Text != "." && dialogProcessor.Selections.Count > 0) {
				dialogProcessor.Resize(float.Parse(sizetextboxX.Text), float.Parse(sizetextboxY.Text));
				statusBar.Items[0].Text = "Последно действие: Мащабиране";

				viewPort.Invalidate();
			}
		}
		private void sizetextboxX_Leave(object sender, EventArgs e)
		{
			if (dialogProcessor.Selections.Count>0)
			{
				string s = sizetextboxX.Text;
				if (s == "" || s == " " || s.Contains(" ") || s==".")
				{
					sizetextboxX.Text = dialogProcessor.Selections[0].scaleX.ToString();
				}
			}
			else
			{
				sizetextboxX.Clear();
			}

		}

        private void sizetextboxY_Leave(object sender, EventArgs e)
        {
			if (dialogProcessor.Selections.Count>0)
			{
				string s = sizetextboxY.Text;
				if (s == "" || s == " " || s.Contains(" ") || s == ".")
				{
					sizetextboxY.Text = dialogProcessor.Selections[0].scaleY.ToString();
				}
			}
			else
			{
				sizetextboxY.Clear();
			}
		}
		private char[] allowedSymbols3 = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '\0', ' ', '.' };

		private void sizetextboxX_TextChanged(object sender, EventArgs e)
        {
			if (dialogProcessor.Selections.Count>0)
			{
				string s = sizetextboxX.Text;
				bool allgood = true;
				foreach (char c in s)
				{
					bool found = false;
					for (int i = 0; i < allowedSymbols3.Length; i++)
					{
						if (allowedSymbols3[i] == c)
						{
							found = true;
							break;
						}
					}
					if (found == false)
					{
						allgood = false;
						break;
					}
				}
				int siz = (int)dialogProcessor.Selections[0].scaleX;
				if (!allgood)
				{
					sizetextboxX.Text = siz.ToString();
				}
			}
			else
			{
				sizetextboxX.Clear();
			}
		}

        private void sizetextboxY_TextChanged(object sender, EventArgs e)
        {
			if (dialogProcessor.Selections.Count>0)
			{
				string s = sizetextboxY.Text;
				bool allgood = true;
				foreach (char c in s)
				{
					bool found = false;
					for (int i = 0; i < allowedSymbols3.Length; i++)
					{
						if (allowedSymbols3[i] == c)
						{
							found = true;
							break;
						}
					}
					if (found == false)
					{
						allgood = false;
						break;
					}
				}
				int siz = (int)dialogProcessor.Selections[0].scaleY;
				if (!allgood)
				{
					sizetextboxY.Text = siz.ToString();
				}
			}
			else
			{
				sizetextboxY.Clear();
			}
		}

        private void selectToolSpeedButton_Click(object sender, EventArgs e)
        {
			if (!ColorPicking) {
				if (!selectToolSpeedButton.Checked)
				{
					selectToolSpeedButton.Checked = true;
					pickUpSpeedButton.Checked = false;
					deleteSpeedButton.Checked = false;
					this.Cursor = System.Windows.Forms.Cursors.Cross;
				}
				else
				{
					selectToolSpeedButton.Checked = false;
				}
			}
        }

        private void pickUpSpeedButton_Click(object sender, EventArgs e)
        {
			if (!ColorPicking) {
				if (!pickUpSpeedButton.Checked)
				{
					pickUpSpeedButton.Checked = true;
					selectToolSpeedButton.Checked = false;
					deleteSpeedButton.Checked = false;
					this.Cursor = System.Windows.Forms.Cursors.Arrow;
				}
				else
				{
					pickUpSpeedButton.Checked = false;
				}
			}
		}

		private void deleteSpeedButton_Click(object sender, EventArgs e)
		{
			if (!ColorPicking)
			{
				if (!deleteSpeedButton.Checked)
				{
					dialogProcessor.Selections.Clear();
					deleteSpeedButton.Checked = true;
					selectToolSpeedButton.Checked = false;
					pickUpSpeedButton.Checked = false;
					rotateBox.Text = "";
					sizetextboxX.Text = "";
					sizetextboxY.Text = "";
					dialogProcessor.DeselectAllBtns();
					this.Cursor = delCursor;
					viewPort.Invalidate();
				}
				else
				{
					deleteSpeedButton.Checked = false;
				}
			}
		}

		public void ResetSpeedBtn() {
			pickUpSpeedButton.Checked = true;
			selectToolSpeedButton.Checked = false;
			deleteSpeedButton.Checked = false;
		}

		private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.CreateGroup();
        }

        private void diselectToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.DeselectAll();
			viewPort.Invalidate();
		}

        private void ungroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.Ungroup();
			dialogProcessor.DeselectAll();
			viewPort.Invalidate();
		}

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.DeleteAllSelected();
        }

        private void viewPort_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyCode == Keys.Delete)
			{
				dialogProcessor.DeleteAllSelected();
			}
			else if (e.KeyCode == Keys.Escape)
			{
				dialogProcessor.DeselectAll();
				viewPort.Invalidate();
			}
			else if (e.KeyCode == Keys.Enter) {
				//apply rotation and scale
				if (sizetextboxX.Text != "" && !sizetextboxX.Text.Contains(" ") && sizetextboxY.Text != "" && !sizetextboxY.Text.Contains(" ") && sizetextboxY.Text != "." && sizetextboxX.Text != "." && dialogProcessor.Selections.Count > 0)
				{
					dialogProcessor.Resize(float.Parse(sizetextboxX.Text), float.Parse(sizetextboxY.Text));
					statusBar.Items[0].Text = "Последно действие: Мащабиране";

					viewPort.Invalidate();
				}
				if (rotateBox.Text != "" && !rotateBox.Text.Contains(" ") && dialogProcessor.Selections[0] != null)
				{
					statusBar.Items[0].Text = "Последно действие: Завъртане";
					dialogProcessor.Rotate(float.Parse(rotateBox.Text));
					viewPort.Invalidate();
				}
			} else if (e.KeyCode == Keys.Q) {
				//select next tool from the tool strip
				if (pickUpSpeedButton.Checked)
				{
					//select multi select button
					if (!ColorPicking)
					{
						if (!selectToolSpeedButton.Checked)
						{
							selectToolSpeedButton.Checked = true;
							pickUpSpeedButton.Checked = false;
							deleteSpeedButton.Checked = false;
							this.Cursor = System.Windows.Forms.Cursors.Cross;
						}
						else
						{
							selectToolSpeedButton.Checked = false;
						}
					}
				}
				else if (selectToolSpeedButton.Checked)
				{
					//select delete button
					if (!ColorPicking)
					{
						if (!deleteSpeedButton.Checked)
						{
							dialogProcessor.Selections.Clear();
							deleteSpeedButton.Checked = true;
							selectToolSpeedButton.Checked = false;
							pickUpSpeedButton.Checked = false;
							rotateBox.Text = "";
							sizetextboxX.Text = "";
							sizetextboxY.Text = "";
							dialogProcessor.DeselectAllBtns();
							this.Cursor = delCursor;
							viewPort.Invalidate();
						}
						else
						{
							deleteSpeedButton.Checked = false;
						}
					}
				}
				else if (deleteSpeedButton.Checked)
				{
					//select pick up button
					if (!ColorPicking)
					{
						if (!pickUpSpeedButton.Checked)
						{
							pickUpSpeedButton.Checked = true;
							selectToolSpeedButton.Checked = false;
							deleteSpeedButton.Checked = false;
							this.Cursor = System.Windows.Forms.Cursors.Arrow;
						}
						else
						{
							pickUpSpeedButton.Checked = false;
						}
					}
				}
				else {
					//select pick up button
					if (!ColorPicking)
					{
						if (!pickUpSpeedButton.Checked)
						{
							pickUpSpeedButton.Checked = true;
							selectToolSpeedButton.Checked = false;
							deleteSpeedButton.Checked = false;
							this.Cursor = System.Windows.Forms.Cursors.Arrow;
						}
						else
						{
							pickUpSpeedButton.Checked = false;
						}
					}
				}
			}
			else if (e.KeyCode == Keys.ControlKey) {
				ctrl_down = true;
				dialogProcessor.ctrl_mod = true;
			}
			else if (e.KeyCode == Keys.ShiftKey)
			{
				shift_down = true;
			}
			else if (e.KeyCode == Keys.E)
			{
				e_down = true;
			}
			else if (e_down && (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1))
			{
				dialogProcessor.AddRandomRectangle();

				statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";

				viewPort.Invalidate();
			}
			else if (e_down && (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2))
			{
				dialogProcessor.AddRandomEllipse();

				statusBar.Items[0].Text = "Последно действие: Рисуване на елипса";

				viewPort.Invalidate();
			}
			else if (e_down && (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3))
			{
				dialogProcessor.AddRandomTriangle();

				statusBar.Items[0].Text = "Последно действие: Рисуване на триъгълник";

				viewPort.Invalidate();
			}
			else if (e_down && (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4))
			{
				dialogProcessor.AddRandomPentagon();

				statusBar.Items[0].Text = "Последно действие: Рисуване на петоъгълник";

				viewPort.Invalidate();
			}
			else if (e_down && (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5))
			{
				dialogProcessor.AddRandomLine();

				statusBar.Items[0].Text = "Последно действие: Рисуване на линия";

				viewPort.Invalidate();
			}
			else if (e_down && (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6))
			{
				dialogProcessor.AddRandomPoint();

				statusBar.Items[0].Text = "Последно действие: Рисуване на точка";

				viewPort.Invalidate();
			}

			if (ctrl_down && (e.KeyCode == Keys.A))
			{
				//select all
				dialogProcessor.SelectAllShapes();
			}
			else if (ctrl_down && (e.KeyCode == Keys.C))
			{
				//copy
				dialogProcessor.CopySelected();
			}
			else if (ctrl_down && (e.KeyCode == Keys.X))
			{
				//cut
				dialogProcessor.CutSelected();
			}
			else if (ctrl_down && (e.KeyCode == Keys.V))
			{
				//paste
				dialogProcessor.PasteClipboard();
			}
			else if (ctrl_down && (e.KeyCode == Keys.G))
			{
				//group selected
				dialogProcessor.CreateGroup();
			}
			if (shift_down && (e.KeyCode == Keys.G))
			{
				//select all
				dialogProcessor.Ungroup();
				dialogProcessor.Selections.Clear();
				viewPort.Invalidate();
			}
		}

		private void viewPort_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.ControlKey)
			{
				ctrl_down = false;
				dialogProcessor.ctrl_mod = false;
			}
			else if (e.KeyCode == Keys.ShiftKey)
			{
				shift_down = false;
			}
			else if (e.KeyCode == Keys.E)
			{
				e_down = false;
			}
		}

		private void rotateBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				//apply rotation and scale
				if (sizetextboxX.Text != "" && !sizetextboxX.Text.Contains(" ") && sizetextboxY.Text != "" && !sizetextboxY.Text.Contains(" ") && sizetextboxY.Text != "." && sizetextboxX.Text != "." && dialogProcessor.Selections.Count > 0)
				{
					dialogProcessor.Resize(float.Parse(sizetextboxX.Text), float.Parse(sizetextboxY.Text));
					statusBar.Items[0].Text = "Последно действие: Мащабиране";

					viewPort.Invalidate();
				}
				if (rotateBox.Text != "" && !rotateBox.Text.Contains(" ") && dialogProcessor.Selections[0] != null)
				{
					statusBar.Items[0].Text = "Последно действие: Завъртане";
					dialogProcessor.Rotate(float.Parse(rotateBox.Text));
					viewPort.Invalidate();
				}
			}
		}

		private void sizetextboxX_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyCode == Keys.Enter)
			{
				//apply rotation and scale
				if (sizetextboxX.Text != "" && !sizetextboxX.Text.Contains(" ") && sizetextboxY.Text != "" && !sizetextboxY.Text.Contains(" ") && sizetextboxY.Text != "." && sizetextboxX.Text != "." && dialogProcessor.Selections.Count > 0)
				{
					dialogProcessor.Resize(float.Parse(sizetextboxX.Text), float.Parse(sizetextboxY.Text));
					statusBar.Items[0].Text = "Последно действие: Мащабиране";

					viewPort.Invalidate();
				}
				if (rotateBox.Text != "" && !rotateBox.Text.Contains(" ") && dialogProcessor.Selections[0] != null)
				{
					statusBar.Items[0].Text = "Последно действие: Завъртане";
					dialogProcessor.Rotate(float.Parse(rotateBox.Text));
					viewPort.Invalidate();
				}
			}
		}

        private void sizetextboxY_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyCode == Keys.Enter)
			{
				//apply rotation and scale
				if (sizetextboxX.Text != "" && !sizetextboxX.Text.Contains(" ") && sizetextboxY.Text != "" && !sizetextboxY.Text.Contains(" ") && sizetextboxY.Text != "." && sizetextboxX.Text != "." && dialogProcessor.Selections.Count > 0)
				{
					dialogProcessor.Resize(float.Parse(sizetextboxX.Text), float.Parse(sizetextboxY.Text));
					statusBar.Items[0].Text = "Последно действие: Мащабиране";

					viewPort.Invalidate();
				}
				if (rotateBox.Text != "" && !rotateBox.Text.Contains(" ") && dialogProcessor.Selections[0] != null)
				{
					statusBar.Items[0].Text = "Последно действие: Завъртане";
					dialogProcessor.Rotate(float.Parse(rotateBox.Text));
					viewPort.Invalidate();
				}
			}
		}

        private void viewPort_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
			if (e.KeyCode == Keys.Up)
			{
				dialogProcessor.MoveBtnUp();
			}
			else if (e.KeyCode == Keys.Down)
			{
				dialogProcessor.MoveBtnDown();
			}
		}

        private void selectAllctrlAToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.SelectAllShapes();
        }

        private void toolStripButton1_MouseUp(object sender, MouseEventArgs e)
        {
			if (e.Button == System.Windows.Forms.MouseButtons.Right) {
				CustomSizePopup csp = new CustomSizePopup(dialogProcessor,viewPort,"rectangle",dialogProcessor.rect_width,dialogProcessor.rect_height);
				csp.ShowDialog();
			}
        }

		private void drawEllipseSpeedButton_MouseUp(object sender, MouseEventArgs e)
        {
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				CustomSizePopup csp = new CustomSizePopup(dialogProcessor, viewPort, "ellipse", dialogProcessor.ell_width, dialogProcessor.ell_height);
				csp.ShowDialog();
			}
		}

        private void drawTriangleSpeedButton_MouseUp(object sender, MouseEventArgs e)
        {
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				CustomSizePopup_triangle csp = new CustomSizePopup_triangle(dialogProcessor, viewPort, "triangle", dialogProcessor.trianglep1, dialogProcessor.trianglep2, dialogProcessor.trianglep3);
				csp.ShowDialog();
			}
		}

		private void DrawPentagonButton_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				CustomSizePopup_pentagon csp = new CustomSizePopup_pentagon(dialogProcessor, viewPort, "pentagon", dialogProcessor.pentagonp1, dialogProcessor.pentagonp2, dialogProcessor.pentagonp3, dialogProcessor.pentagonp4, dialogProcessor.pentagonp5);
				csp.ShowDialog();
			}
		}

		private void drawLineSpeedButton_MouseUp(object sender, MouseEventArgs e)
        {
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				CustomSizePopup_line csp = new CustomSizePopup_line(dialogProcessor, viewPort, "line",dialogProcessor.linepoint2.X,dialogProcessor.linepoint2.Y);
				csp.ShowDialog();
			}
		}

        private void drawPointSpeedButton_MouseUp(object sender, MouseEventArgs e)
        {
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				CustomSizePopup csp = new CustomSizePopup(dialogProcessor, viewPort, "point", dialogProcessor.point_width,dialogProcessor.point_height);
				csp.ShowDialog();
			}
		}

        private void saveModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
			SaveFileDialog sf = new SaveFileDialog();
			sf.Title = "Choose where to save your model.";
			sf.FileName = "Shapes";
			sf.DefaultExt = "drw";
			sf.AddExtension = true;
			if (sf.ShowDialog() == DialogResult.OK) {
				dialogProcessor.SaveModel(sf.FileName);
			}
        }

        private void loadModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
			OpenFileDialog lf = new OpenFileDialog();
			lf.Title = "Choose a model to load.";
			lf.CheckFileExists = true;
			lf.CheckPathExists = true;
			if (lf.ShowDialog() == DialogResult.OK)
			{
				if (lf.FileName.Contains(".drw"))
				{
					dialogProcessor.LoadModel(lf.FileName);
				}
			}

		}

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Rectangle bsize = viewPort.ClientRectangle;
			Bitmap b = new Bitmap(bsize.Width, bsize.Height);
			viewPort.DrawToBitmap(b, bsize);
			SaveFileDialog sf = new SaveFileDialog();
			sf.Title = "Choose where to save your image.";
			sf.FileName = "ShapesIMG";
			sf.DefaultExt = "png";
			sf.AddExtension = true;
			if (sf.ShowDialog() == DialogResult.OK)
			{
				b.Save(sf.FileName, ImageFormat.Png);
			}
		}

    }
}
