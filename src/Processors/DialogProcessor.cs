using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Draw
{
	/// <summary>
	/// Класът, който ще бъде използван при управляване на диалога.
	/// </summary>
	public class DialogProcessor : DisplayProcessor
	{
		#region Constructor
		
		public DialogProcessor()
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// Избран елемент.
		/// </summary>
		public bool ctrl_mod = false;
		private List<Shape> selections = new List<Shape>();
		public List<Shape> CopiedShapes = new List<Shape>();
		public List<Shape> CutShapes = new List<Shape>();
		public FlowLayoutPanel sceneItemsList;
		public DoubleBufferedPanel viewPort;
		public List<Button> buttonList = new List<Button>();
		public TextBox rotateBox;
		public TextBox scaleXbox;
		public TextBox scaleYbox;
		public int FillAlpha = 255;
		public int BorderAlpha = 255;

		public int rect_width = 100;
		public int rect_height = 100;
		public int ell_width = 100;
		public int ell_height = 100;
		public Point linepoint2 = new Point(360,20);
		public int point_width = 4;
		public int point_height = 4;
		public PointF trianglep1 = new PointF(340, 20);
		public PointF trianglep2 = new PointF(260, 130);
		public PointF trianglep3 = new PointF(420, 130);

		public PointF pentagonp1 = new PointF(340, 15);
		public PointF pentagonp2 = new PointF(390, 50);
		public PointF pentagonp3 = new PointF(370, 105);
		public PointF pentagonp4 = new PointF(310, 105);
		public PointF pentagonp5 = new PointF(290, 50);


		public List<Shape> Selections {
			get { return selections; }
			set { selections = value; }
		}
		private Shape selectRect;
		public Shape SelectRect
		{
			get { return selectRect; }
			set { selectRect = value; }
		}

		/// <summary>
		/// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
		/// </summary>
		private bool isDragging;
		public bool IsDragging {
			get { return isDragging; }
			set { isDragging = value; }
		}

		private bool multiSelect;
		public bool MultiSelect
		{
			get { return multiSelect; }
			set { multiSelect = value; }
		}

		/// <summary>
		/// Последна позиция на мишката при "влачене".
		/// Използва се за определяне на вектора на транслация.
		/// </summary>
		private PointF lastLocation;
		public PointF LastLocation {
			get { return lastLocation; }
			set { lastLocation = value; }
		}

		#endregion

		//Multiple shapes selection
		public void CreateSelection(PointF startPoint) {
			SelectionRectangle selrect = new SelectionRectangle(new RectangleF(startPoint.X,startPoint.Y,1,1));
			SelectRect = selrect;
		}

		//Creates a changing rectangle used for selecting multiple shapes at once
		public void DrawSelection(object sender, PaintEventArgs e) {
			if (SelectRect!=null) {
				SelectRect.DrawSelf(e.Graphics);
			}
		}
		//remembering selecting rectangle's correct width and height even if it is reversed
		private float WinNegative = 0;
		private float HinNegative = 0;
		private float WinPositive = 0;
		private float HinPositive = 0;
		public void ChangeSelection(float Width, float Height) {
			bool reversedW = false, reversedH = false;
			if (Width <= 0)
			{
				WinPositive = 0;
				WinNegative += -Width;
				reversedW = true;
			}
			else {
				WinPositive += Width;
				float temp = WinPositive;
				WinPositive -= WinNegative;
				if (WinPositive > 0)
				{
					WinNegative = 0;
				}
				else {
					reversedW = true;
					WinNegative -= temp;
					WinPositive = 0;
				}
			}
			if (Height <= 0)
			{
				HinPositive = 0;
				HinNegative += -Height;
				reversedH = true;
			}
			else {
				HinPositive += Height;
				float temp = HinPositive;
				HinPositive -= HinNegative;
				if (HinPositive > 0)
				{
					HinNegative = 0;
				}
				else
				{
					reversedH = true;
					HinNegative -= temp;
					HinPositive = 0;
				}
			}
			if (!reversedW && !reversedH)
			{
				SelectRect.Width = Width;
				SelectRect.Height = Height;
			} else if (reversedW && !reversedH) {
				SelectRect.Location = new PointF(SelectRect.Rectangle.X+Width,SelectRect.Rectangle.Y);
				SelectRect.Width = -Width + WinNegative;
				SelectRect.Height = Height;
			}
			else if (!reversedW && reversedH)
			{
				SelectRect.Location = new PointF(SelectRect.Rectangle.X, SelectRect.Rectangle.Y+Height);
				SelectRect.Width = Width;
				SelectRect.Height = -Height + HinNegative;
			}
			else if (reversedW && reversedH)
			{
				SelectRect.Location = new PointF(SelectRect.Rectangle.X + Width, SelectRect.Rectangle.Y + Height);
				SelectRect.Width = -Width + WinNegative;
				SelectRect.Height = -Height + HinNegative;
			}
		}

		//Outlines selected shapes
		public void DrawSelection(Graphics grfx) {
			if (Selections.Count > 0) {
				foreach (Shape shp in Selections) {
					shp.DisplaySelection(grfx);
				}
			}
		}

		//check which shapes should get selected and select them
		public void CheckMultiSelection() {
			Selections.Clear();
			DeselectAllBtns();
			//get all shapes in order to test if they are in the drawn selection
			List<Shape> allShapes = new List<Shape>();
			foreach (Shape shapeandgroups in ShapeList) {
				if (shapeandgroups is GroupShape)
				{
					GroupShape grp = (GroupShape)shapeandgroups;
					foreach (Shape item in grp.Group) {
						allShapes.Add(item);
					}
				}
				else {
					allShapes.Add(shapeandgroups);
				}
			}
			//blacklisting already selected groups so they dont get selected multiple times from every group member
			List<GroupShape> BlackList = new List<GroupShape>();
			foreach (Shape sh in allShapes) {
				var shapeBounds = sh.path.GetBounds();
				bool contained = true;
				//avoid crash when resizing main window while using MultiSelectTool
				if (SelectRect == null) {
					return;
				}
				//check if the shape is withing the bounds of the selecting rectangle
				if (shapeBounds.Left>SelectRect.Location.X+SelectRect.Width) {
					contained = false;
				}
				if (shapeBounds.Right < SelectRect.Location.X)
				{
					contained = false;
				}
				if (shapeBounds.Top > SelectRect.Location.Y+SelectRect.Height)
				{
					contained = false;
				}
				if (shapeBounds.Bottom < SelectRect.Location.Y)
				{
					contained = false;
				}
				if (contained) {
					//check if the contained shape is a part of a group and add the whole group if it is
					if (sh.Grouped)
					{
						foreach (Shape testGroup in ShapeList)
						{
							if (testGroup is GroupShape)
							{
								GroupShape rightGroup = (GroupShape)testGroup;
								if (!(BlackList.Contains(rightGroup)) && rightGroup.ContainsMember(sh))
								{
									//add group to blacklist so there are no duplicated shapes being added
									BlackList.Add(rightGroup);
									SelectBtn(null, rightGroup);
									//add all shapes part of that group
									foreach (Shape innerShape in rightGroup.Group)
									{
										Selections.Add(innerShape);
									}
								}
							}
						}
					}
					else
					{
						//if it is a normal shape just add it to the list of selected
						Selections.Add(sh);
						SelectBtn(null, sh);
					}
				}
			}
			//get a list of all the groups in shapelist
			List<GroupShape> allGroups = new List<GroupShape>();
			foreach (Shape foundGroup in ShapeList)
			{
				if (foundGroup is GroupShape)
				{
					GroupShape g = (GroupShape)foundGroup;
					allGroups.Add(g);
				}
			}
			int objectCounter = Selections.Count;
			List<GroupShape> checkedGroups = new List<GroupShape>();
			foreach (GroupShape g in allGroups)
			{
				foreach (Shape s in Selections)
				{
					if (g.ContainsMember(s))
					{
						if (!checkedGroups.Contains(g))
						{
							checkedGroups.Add(g);
							objectCounter -= g.Group.Count;
							objectCounter++;
							//count each group for a single shape and not for as many as its member count
						}
					}
				}
			}
			if (objectCounter > 1)
			{
				//if more than one group are selected change multiselect to true so as not to deselect a group when clicking on only one of 2 selected groups
				MultiSelect = true;
			}
			else
			{
				MultiSelect = false;
			}
			//reset selecting rectangle params
			SelectRect = null;
			WinNegative = 0;
			WinPositive = 0;
			HinNegative = 0;
			HinPositive = 0;
		}
		//Grouping
		public void CreateGroup() {
			if (Selections.Count > 1) {
				GroupShape grp = new GroupShape();
				//save a list of already included groups so as to prevent duplicates
				List<GroupShape> includedGroups = new List<GroupShape>();
				foreach (Shape s in Selections) {
					//ungroup any primitives that are already in a group and want to be grouped again
					if (s.Grouped) {
						foreach (Shape potentialGroup in ShapeList) {
							if (potentialGroup is GroupShape) {
								GroupShape confirmedGroup = (GroupShape)potentialGroup;
								if (confirmedGroup.ContainsMember(s)) {
									if (!includedGroups.Contains(confirmedGroup)) {
										includedGroups.Add(confirmedGroup);
									}
									confirmedGroup.RemoveMember(s);
								}
							}
						}
					}
					//add the primitives to the new group
					grp.AddMember(s);
					s.Grouped = true;
					s.BeforeG_angle = s.angle;
					s.angle = 0;
					s.BeforeG_scaleX = s.scaleX;
					s.BeforeG_scaleY = s.scaleY;
					s.scaleX = 1;
					s.scaleY = 1;
					//remove the singular primitives from the shape list
					ShapeList.Remove(s);
					RemoveButtonFromList(s);
				}
				if (includedGroups.Count > 0) {
                    for (int i = 0; i < includedGroups.Count; i++)
                    {
						RemoveButtonFromList(includedGroups[i]);
						ShapeList.Remove(includedGroups[i]);
					}
				}

				//Give appropriate name
				int similarNames = 0;
				string n = grp.name;
				if (ShapeList.Count > 0)
				{
					for (int i = 0; i < ShapeList.Count; i++)
					{
						if (ShapeList[i].name == n)
						{
							similarNames++;
							if (similarNames == 1)
							{
								n = n + " " + similarNames;
							}
							else
							{
								n = grp.name + " " + similarNames;
							}
							i = 0;
						}
					}
					grp.name = n;
				}

				//add group shape to shape list
				ShapeList.Add(grp);
				AddButtonToList(grp,true);
			}
		}
		public void Ungroup() {
			if (Selections.Count > 1)
			{
				List<Shape> RecoveredShapes = new List<Shape>();
				List<GroupShape> allgroops = new List<GroupShape>();
				foreach (Shape s in ShapeList)
				{
					if (s is GroupShape) {
						GroupShape gr = (GroupShape)s;
						//check if all selected shapes are a part of this group and if not dont ungroup
						if (gr.HasGroup(Selections)) {
							RecoveredShapes = gr.ReturnGroup();
							foreach (Shape recoveredShape in RecoveredShapes) {
								recoveredShape.Grouped = false;
								recoveredShape.scaleX = recoveredShape.BeforeG_scaleX + recoveredShape.scaleX - 1;
								recoveredShape.scaleY = recoveredShape.BeforeG_scaleY + recoveredShape.scaleY - 1;
								recoveredShape.angle = recoveredShape.BeforeG_angle + recoveredShape.angle;

								//Give appropriate name
								int similarNames = 0;
								string n = recoveredShape.name;
								if (ShapeList.Count > 0)
								{
									for (int i = 0; i < ShapeList.Count; i++)
									{
										if (ShapeList[i].name == n)
										{
											similarNames++;
											if (similarNames == 1)
											{
												n = n + " " + similarNames;
											}
											else
											{
												n = recoveredShape.name + " " + similarNames;
											}
											i = 0;
										}
									}
									recoveredShape.name = n;
								}

								//add group shape to shape list
								ShapeList.Add(recoveredShape);
								AddButtonToList(recoveredShape);
							}
							ShapeList.Remove(s);
							RemoveButtonFromList(s);
							DeselectAllBtns();
							return;
						}
					}
				}
			}
		}
		//Clear selection
		public void DeselectAll() {
			Selections.Clear();
			multiSelect = false;
			DeselectAllBtns();
		}

		//Delete shape
		public void DeleteShape(Shape s) {
			if (s is GroupShape)
			{
				DeleteGroupShape((GroupShape)s);
			}
			else {
				ShapeList.Remove(s);
				Selections.Remove(s);
				RemoveButtonFromList(s);
				viewPort.Invalidate();
			}
		}
		void DeleteGroupShape(GroupShape g) {
			ShapeList.Remove(g);
			Selections.Remove(g);
			foreach (Shape s in g.Group) {
				Selections.Remove(s);
			}
			RemoveButtonFromList(g);
			viewPort.Invalidate();
		}
		/// <summary>
		/// Добавя примитив - правоъгълник на произволно място върху клиентската област.
		/// </summary>

		public void AddRandomRectangle()
		{
			RectangleShape rect = new RectangleShape(new Rectangle(260,20,rect_width,rect_height));
			rect.FillColor = selectedFillColor;
			rect.BorderColor = selectedBorderColor;
			rect.BorderSize = selectedBorderSize;


			//Give appropriate name
			int similarNames = 0;
			string n = rect.name;
			if (ShapeList.Count>0) {
				for (int i = 0; i < ShapeList.Count; i++)
				{
					if (ShapeList[i].name == n)
					{
						similarNames++;
						if (similarNames == 1)
						{
							n = n + " " + similarNames;
						}
						else {
							n = rect.name + " " + similarNames;
						}
						i = 0;
					}
				}
				rect.name = n;
			}

			ShapeList.Add(rect);
			AddButtonToList(rect);
		}

		public void AddRandomEllipse()
		{
			EllipseShape ell = new EllipseShape(new Rectangle(260, 20, ell_width, ell_height));
			ell.FillColor = selectedFillColor;
			ell.BorderColor = selectedBorderColor;
			ell.BorderSize = selectedBorderSize;

			//Give appropriate name
			int similarNames = 0;
			string n = ell.name;
			if (ShapeList.Count > 0)
			{
				for (int i = 0; i < ShapeList.Count; i++)
				{
					if (ShapeList[i].name == n)
					{
						similarNames++;
						if (similarNames == 1)
						{
							n = n + " " + similarNames;
						}
						else
						{
							n = ell.name + " " + similarNames;
						}
						i = 0;
					}
				}
				ell.name = n;
			}

			ShapeList.Add(ell);
			AddButtonToList(ell);
		}

		public void AddRandomPoint()
		{
			EllipseShape poi = new EllipseShape(new Rectangle(260, 20, point_width, point_height));
			poi.FillColor = selectedFillColor;
			poi.BorderColor = selectedBorderColor;
			poi.BorderSize = selectedBorderSize;

			//Give appropriate name
			int similarNames = 0;
			string n = poi.name;
			if (ShapeList.Count > 0)
			{
				for (int i = 0; i < ShapeList.Count; i++)
				{
					if (ShapeList[i].name == n)
					{
						similarNames++;
						if (similarNames == 1)
						{
							n = n + " " + similarNames;
						}
						else
						{
							n = poi.name + " " + similarNames;
						}
						i = 0;
					}
				}
				poi.name = n;
			}

			ShapeList.Add(poi);
			AddButtonToList(poi);
		}

		public void AddRandomLine()
		{
			LineShape lin = new LineShape(260,20, linepoint2.X, linepoint2.Y);
			lin.BorderColor = selectedBorderColor;
			lin.BorderSize = selectedBorderSize;

			//Give appropriate name
			int similarNames = 0;
			string n = lin.name;
			if (ShapeList.Count > 0)
			{
				for (int i = 0; i < ShapeList.Count; i++)
				{
					if (ShapeList[i].name == n)
					{
						similarNames++;
						if (similarNames == 1)
						{
							n = n + " " + similarNames;
						}
						else
						{
							n = lin.name + " " + similarNames;
						}
						i = 0;
					}
				}
				lin.name = n;
			}

			ShapeList.Add(lin);
			AddButtonToList(lin);
		}

		public void AddRandomTriangle()
		{
			TriangleShape tri = new TriangleShape(trianglep1, trianglep2, trianglep3) ;
			tri.FillColor = selectedFillColor;
			tri.BorderColor = selectedBorderColor;
			tri.BorderSize = selectedBorderSize;

			//Give appropriate name
			int similarNames = 0;
			string n = tri.name;
			if (ShapeList.Count > 0)
			{
				for (int i = 0; i < ShapeList.Count; i++)
				{
					if (ShapeList[i].name == n)
					{
						similarNames++;
						if (similarNames == 1)
						{
							n = n + " " + similarNames;
						}
						else
						{
							n = tri.name + " " + similarNames;
						}
						i = 0;
					}
				}
				tri.name = n;
			}

			ShapeList.Add(tri);
			AddButtonToList(tri);
		}

		public void AddRandomPentagon()
		{
			PentagonShape pent = new PentagonShape(pentagonp1, pentagonp2, pentagonp3, pentagonp4, pentagonp5);
			pent.FillColor = selectedFillColor;
			pent.BorderColor = selectedBorderColor;
			pent.BorderSize = selectedBorderSize;

			//Give appropriate name
			int similarNames = 0;
			string n = pent.name;
			if (ShapeList.Count > 0)
			{
				for (int i = 0; i < ShapeList.Count; i++)
				{
					if (ShapeList[i].name == n)
					{
						similarNames++;
						if (similarNames == 1)
						{
							n = n + " " + similarNames;
						}
						else
						{
							n = pent.name + " " + similarNames;
						}
						i = 0;
					}
				}
				pent.name = n;
			}

			ShapeList.Add(pent);
			AddButtonToList(pent);
		}

		public void ShapeSelect(Shape chosen) //for selecting specific shapes from button menu
		{
			Selections.Clear();
			foreach (Shape s in ShapeList) {
				if (s == chosen) {
					if (s is GroupShape)
					{
						GroupShape gr = (GroupShape)s;
						foreach (Shape s2 in gr.Group) {
							Selections.Add(s2);
						}
						viewPort.Invalidate();
					}
					else {
						Selections.Add(s);
						viewPort.Invalidate();
					}
				}
			}
		}

		void AddButtonToList(Shape s, bool select = false) {
			Button b = new Button();
			b.Text = s.name;
			b.Width = sceneItemsList.Width-6;
			b.TabStop = false;
			b.FlatStyle = FlatStyle.Flat;
			b.BackColor = Color.LightGray;
			b.FlatAppearance.BorderColor = Color.Black;
			ContextMenuStrip cm = new ContextMenuStrip();
			//add options
			cm.Items.Add("Deselect");
			cm.Items.Add("Rename");
			cm.Items.Add("Change layer order");
			cm.Items.Add("Change Fill Color");
			cm.Items.Add("Change Border Color");
			cm.Items.Add("Delete");
			cm.Opening += (sender, e) => {
				//select new button or keep selected
				if (!Selections.Contains(s) && !(s is GroupShape))
				{
					DeselectAll();
					DeselectAllBtns();
					Selections.Add(s);
				} else if (!Selections.Contains(s) && s is GroupShape) {
					bool contained = false;
					GroupShape grp = (GroupShape)s;
					foreach (Shape prim in Selections) {
						if (grp.ContainsMember(prim)) {
							contained = true;
						}
					}
					if (!contained) {
						DeselectAll();
						DeselectAllBtns();
						foreach (Shape itm in grp.Group)
						{
							Selections.Add(itm);
						}
					}
				}
				if (s is GroupShape)
				{
					cm.Items.Add("Ungroup");
				}
				b.BackColor = Color.LightBlue;
				if (b.BackColor == Color.LightBlue) {
					int buttonsSelected = 0;
					foreach (Button btn in buttonList) {
						if (btn.BackColor == Color.LightBlue) {
							buttonsSelected++;
						}
					}
					if (buttonsSelected > 1)
					{
						cm.Items.Add("Group");
					}
				}
				//call the function to give methods to the buttons
				giveFunc();
				viewPort.Invalidate();
			};
			//clear options on closing
			cm.Closing += (sender, e) => {
				cm.Items.Clear();
				cm.Items.Add("Deselect");
				cm.Items.Add("Rename");
				cm.Items.Add("Change layer order");
				cm.Items.Add("Change Fill Color");
				cm.Items.Add("Change Border Color");
				cm.Items.Add("Delete");
			};
			//give methods to the options
			void giveFunc() {
				for (int i = 0; i < cm.Items.Count; i++)
				{
					if (cm.Items[i].Text == "Deselect")
					{
						cm.Items[i].Click += (sender, e) => {
							Selections.Remove(s);
							b.BackColor = Color.LightGray;
							if (s is GroupShape) {
								GroupShape wholeG = (GroupShape)s;
								foreach (Shape innerS in wholeG.Group) {
									Selections.Remove(innerS);
								}
							}
							viewPort.Invalidate();
						};
					}
					else if (cm.Items[i].Text == "Rename")
					{
						cm.Items[i].Click += (sender, e) => {
							TextBox t = new TextBox();
							t.Text = b.Text;
							t.Location = b.Location;
							t.Width = b.Width;
							t.Height = b.Height;
							RenameTxB(t);
							viewPort.Controls.Add(t);
							t.Focus();
						};
					}
					else if (cm.Items[i].Text == "Change layer order")
					{
						cm.Items[i].Click += (sender, e) => {
							TextBox t = new TextBox();
							t.Text = ShapeList.IndexOf(s).ToString();
							t.Location = b.Location;
							t.Width = b.Width/3;
							t.Height = b.Height;
							ChangeLayerOrderTxB(t);
							viewPort.Controls.Add(t);
							t.Focus();
						};
					}
					else if (cm.Items[i].Text == "Change Fill Color")
					{
						cm.Items[i].Click += (sender, e) => {
							ColorDialog clDialog = new ColorDialog();

							//show the color dialog and wait for ok click
							if (clDialog.ShowDialog() == DialogResult.OK)
							{
								//apply chosen color
								Color newC = Color.FromArgb(FillAlpha, clDialog.Color);
								foreach (Shape forColoring in Selections)
								{
									forColoring.FillColor = newC;
								}
								viewPort.Invalidate();
							}
						};
					}
					else if (cm.Items[i].Text == "Change Border Color")
					{
						cm.Items[i].Click += (sender, e) => {
							ColorDialog clDialog = new ColorDialog();

							//show the color dialog and wait for ok click
							if (clDialog.ShowDialog() == DialogResult.OK)
							{
								//apply chosen color
								Color newC = Color.FromArgb(BorderAlpha, clDialog.Color);
								foreach (Shape forColoring in Selections) {
									forColoring.BorderColor = newC;
								}
								viewPort.Invalidate();
							}
						};
					}
					else if (cm.Items[i].Text == "Delete")
					{
						cm.Items[i].Click += (sender, e) => {
							DeleteAllSelected();
						};
					}
					else if (cm.Items[i].Text == "Ungroup")
					{
						cm.Items[i].Click += (sender, e) => {
							Ungroup();
							DeselectAll();
							viewPort.Invalidate();
						};
					}
					else if (cm.Items[i].Text == "Group")
					{
						cm.Items[i].Click += (sender, e) => {
							CreateGroup();
						};
					}
				}
			}
			//give function to rename text boxes
			void RenameTxB(TextBox t) {
				//if enter is pressed try to save new name
				t.KeyDown += (object sender, KeyEventArgs e) => {
					if (t.Text != "" && e.KeyCode == Keys.Enter) {
						//Give appropriate name
						int similarNames = 0;
						string n = t.Text;
						string m = t.Text;
						if (ShapeList.Count > 0)
						{
							for (int i = 0; i < ShapeList.Count; i++)
							{
								if (ShapeList[i].name == n)
								{
									similarNames++;
									if (similarNames == 1)
									{
										n = n + " " + similarNames;
									}
									else
									{
										n = m + " " + similarNames;
									}
									i = 0;
								}
							}
							s.name = n;
							b.Text = n;
						}
						viewPort.Controls.Remove(t);
					}
					if (e.KeyCode == Keys.Escape) {
						viewPort.Controls.Remove(t);
					}
				};
				//if clicked away
				t.LostFocus += (semder, e) =>
				{
					viewPort.Controls.Remove(t);
				};
			}
			//method for changing the item's order in the layer
			void ChangeLayerOrderTxB(TextBox t) {
				//if enter is pressed try to save new order
				t.KeyDown += (object sender, KeyEventArgs e) => {
					if (t.Text != "" && e.KeyCode == Keys.Enter)
					{
						//check if an int was entered
						int newPos;
						if (int.TryParse(t.Text,out newPos)) {
                            if (newPos >= 0)
                            {
								if (newPos >= ShapeList.Count) {
									newPos = ShapeList.Count-1;
								}
								//change order in shapelist
								ShapeList.Remove(s);
								ShapeList.Insert(newPos, s);
								RefreshButtonList();
                            }
						}
						viewPort.Controls.Remove(t);
					}
					if (e.KeyCode == Keys.Escape)
					{
						viewPort.Controls.Remove(t);
					}
				};
				//if clicked away
				t.LostFocus += (semder, e) =>
				{
					viewPort.Controls.Remove(t);
				};
			}
			//continue with button stuff
			b.ContextMenuStrip = cm;
			b.Click += (sender, e) => {
				viewPort.Focus();
				if (b.BackColor!=Color.LightBlue)
				{
					if (!ctrl_mod)
					{
						DeselectAllBtns();
						SelectBtn(b);
						ShapeSelect(s);
						//update rotate and scale boxes
						rotateBox.Text = s.angle.ToString();
						scaleXbox.Text = s.scaleX.ToString();
						scaleYbox.Text = s.scaleY.ToString();
					}
					else {
						if (!Selections.Contains(s)) {
							SelectBtn(b);
							Selections.Add(s);
						}
					}
				}
				else {
					if (!ctrl_mod) {
						DeselectAll();
						SelectBtn(b);
						Selections.Add(s);
					}
				}
				viewPort.Invalidate();
			};
			sceneItemsList.Controls.Add(b);
			buttonList.Add(b);
			//if a group was created and this is a group button
			if (select) {
				DeselectAllBtns();
				SelectBtn(b);
			}
		}

		//used to refresh the order of buttons after changing shape layer order
		void RefreshButtonList() {
            for (int i = 0; i < ShapeList.Count; i++)
            {
				RemoveButtonFromList(ShapeList[i]);
            }
			for (int i = 0; i < ShapeList.Count; i++)
			{
				AddButtonToList(ShapeList[i]);
			}
			viewPort.Invalidate();
		}

		void RemoveAllBtns() {
			for (int i = 0; i < ShapeList.Count; i++)
			{
				RemoveButtonFromList(ShapeList[i]);
			}
		}

		public void MoveBtnUp() {
			Button top_b = null;
            for (int i = 0; i < buttonList.Count; i++)
            {
				if (buttonList[i].BackColor == Color.LightBlue) {
					top_b = buttonList[i];
					break;
				}
            }
			if (top_b == null) {
				if (buttonList.Count == 1)
				{
					top_b = buttonList[0];
				}
				else if (buttonList.Count>0)
				{
					top_b = buttonList[1];
				}
			}
			if (top_b != null) {
				DeselectAll();
				int top_index = buttonList.IndexOf(top_b)-1;
				if (top_index < 0)
				{
					top_index = buttonList.Count - 1;
				}
				SelectBtn(buttonList[top_index]);
				foreach (Shape s in ShapeList)
				{
					if (s.name == buttonList[top_index].Text)
					{
						Selections.Add(s);
						break;
					}
				}
				viewPort.Invalidate();
			}
		}

		public void MoveBtnDown() {
			Button bottom_b = null;
			for (int i = buttonList.Count-1; i>=0; i--)
			{
				if (buttonList[i].BackColor == Color.LightBlue)
				{
					bottom_b = buttonList[i];
					break;
				}
			}
			if (bottom_b == null)
			{
				if (buttonList.Count == 1)
				{
					bottom_b = buttonList[0];
				}
				else if (buttonList.Count > 0)
				{
					bottom_b = buttonList[buttonList.Count-1];
				}
			}
			if (bottom_b != null)
			{
				DeselectAll();
				int bottom_index = buttonList.IndexOf(bottom_b) + 1;
				if (bottom_index > buttonList.Count-1)
				{
					bottom_index = 0;
				}
				SelectBtn(buttonList[bottom_index]);
				foreach (Shape s in ShapeList)
				{
					if (s.name == buttonList[bottom_index].Text)
					{
						Selections.Add(s);
						break;
					}
				}
				viewPort.Invalidate();
			}
		}

		public void SelectBtn(Button b = null,Shape s = null) {
			if (b != null)
			{
				foreach (Button btn in buttonList)
				{
					if (btn == b)
					{
						btn.BackColor = Color.LightBlue;
					}
				}
			}
			else {
				if (s != null) {
					foreach (Button btn in buttonList)
					{
						if (btn.Text == s.name)
						{
							btn.BackColor = Color.LightBlue;
						}
					}
				}
			}
		}
		public void DeselectBtn(Button b)
		{
			foreach (Button btn in buttonList)
			{
				if (btn == b)
				{
					btn.BackColor = Color.LightGray;
				}
			}
		}
		public void DeselectAllBtns()
		{
			foreach (Button btn in buttonList)
			{
				btn.BackColor = Color.LightGray;
			}
		}

		void RemoveButtonFromList(Shape s)
		{
			foreach (Button b in buttonList) {
				if (b.Text==s.name) {
					sceneItemsList.Controls.Remove(b);
					buttonList.Remove(b);
					return;
				}
			}
		}

		public void SelectAllShapes() {
			DeselectAll();
			foreach (Shape shp in ShapeList) {
				if (shp is GroupShape)
				{
					GroupShape grp = (GroupShape)shp;
					foreach (Shape s in grp.Group) {
						Selections.Add(s);
						foreach (Button b in buttonList)
						{
							if (b.Text == shp.name)
							{
								SelectBtn(b);
								break;
							}
						}
					}
				}
				else {
					Selections.Add(shp);
					foreach (Button b in buttonList)
					{
						if (b.Text == shp.name)
						{
							SelectBtn(b);
							break;
						}
					}
				}
			}
			if (selections.Count > 1) {
				MultiSelect = true;
			}
			viewPort.Invalidate();
		}

		public void CopySelected() {
			CopiedShapes.Clear();
			CutShapes.Clear();
			List<GroupShape> BlackListed = new List<GroupShape>();
			foreach (Shape s in Selections) {
				if (s.Grouped == false)
				{
					CopiedShapes.Add(s);
				}
				else {
					foreach (Shape potentialG in ShapeList) {
						if (potentialG is GroupShape) {
							GroupShape grp = (GroupShape)potentialG;
							if (grp.ContainsMember(s) && !BlackListed.Contains(grp)) {
								BlackListed.Add(grp);
								CopiedShapes.Add(grp);
							}
						}
					}
				}
			}
		}

		public void CutSelected() {
			CopiedShapes.Clear();
			CutShapes.Clear();
			List<GroupShape> BlackListed = new List<GroupShape>();
			foreach (Shape s in Selections)
			{
				if (s.Grouped == false)
				{
					CutShapes.Add(s);
					ShapeList.Remove(s);
					RemoveButtonFromList(s);
				}
				else
				{
					foreach (Shape potentialG in ShapeList)
					{
						if (potentialG is GroupShape)
						{
							GroupShape grp = (GroupShape)potentialG;
							if (grp.ContainsMember(s) && !BlackListed.Contains(grp))
							{
								BlackListed.Add(grp);
								CutShapes.Add(grp);
								RemoveButtonFromList(grp);
							}
						}
					}
				}
			}
            for (int i = 0; i < BlackListed.Count; i++)
            {
				ShapeList.Remove(BlackListed[i]);
			}
			Selections.Clear();
			viewPort.Invalidate();
		}
		public void PasteClipboard() {
			DeselectAll();
			DeselectAllBtns();
			if (CopiedShapes.Count > 0) {
				foreach (Shape copied_s in CopiedShapes) {
					Shape new_shape;
					if (copied_s is RectangleShape)
					{
						new_shape = new RectangleShape((RectangleShape)copied_s);
					}
					else if (copied_s is EllipseShape)
					{
						new_shape = new EllipseShape((EllipseShape)copied_s);
					}
					else if (copied_s is LineShape)
					{
						new_shape = new LineShape((LineShape)copied_s);
					}
					else if (copied_s is PointShape)
					{
						new_shape = new PointShape((PointShape)copied_s);
					}
					else if (copied_s is TriangleShape)
					{
						new_shape = new TriangleShape((TriangleShape)copied_s);
					}
					else if (copied_s is PentagonShape)
					{
						new_shape = new PentagonShape((PentagonShape)copied_s);
					}
					else if (copied_s is GroupShape)
					{
						new_shape = new GroupShape((GroupShape)copied_s);
					}
					else {
						new_shape = new RectangleShape((RectangleShape)copied_s);
					}
					//Give appropriate name
					int similarNames = 0;
					string n = new_shape.name;
					if (ShapeList.Count > 0)
					{
						for (int i = 0; i < ShapeList.Count; i++)
						{
							if (ShapeList[i].name == n)
							{
								similarNames++;
								if (similarNames == 1)
								{
									n = n + " " + similarNames;
								}
								else
								{
									n = new_shape.name + " " + similarNames;
								}
								i = 0;
							}
						}
						new_shape.name = n;
					}
					ShapeList.Add(new_shape);
					AddButtonToList(new_shape);

					if (new_shape is GroupShape)
					{
						GroupShape new_group = (GroupShape)new_shape;
						foreach (Shape innerS in new_group.Group) {
							Selections.Add(innerS);
						}
						SelectBtn(null, new_group);
					}
					else {
						Selections.Add(new_shape);
						SelectBtn(null, new_shape);

						//move to the proper position
						Matrix mx = new Matrix();
						mx.Translate(copied_s.path.GetBounds().Location.X - new_shape.path.GetBounds().Location.X, copied_s.path.GetBounds().Location.Y - new_shape.path.GetBounds().Location.Y);
						new_shape.path.Transform(mx);

						//scale properly
						var bounds = new_shape.path.GetBounds();
						PointF lastPoint = new PointF(bounds.X, bounds.Y);
						Matrix m = new Matrix();
						m.Scale(new_shape.scaleX, new_shape.scaleY);
						new_shape.path.Transform(m);

						//give proper rotation
						bounds = new_shape.path.GetBounds();
						new_shape.CenterPoint = new PointF(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2);
						Matrix Rmx = new Matrix();
						Rmx.RotateAt((float)new_shape.angle, new_shape.CenterPoint);
						new_shape.path.Transform(Rmx);

						//bring it back to prev point
						bounds = new_shape.path.GetBounds();
						Matrix moveBackMX = new Matrix();
						moveBackMX.Translate(lastPoint.X - bounds.X, lastPoint.Y - bounds.Y);
						new_shape.path.Transform(moveBackMX);
					}
				}
			}
			if (CutShapes.Count > 0) {
				DeselectAll();
				DeselectAllBtns();
				foreach (Shape cutout in CutShapes) {
					ShapeList.Add(cutout);
					AddButtonToList(cutout);
					SelectBtn(null, cutout);
					if (cutout is GroupShape)
					{
						GroupShape g = (GroupShape)cutout;
						foreach (Shape item in g.Group) {
							Selections.Add(item);
						}
					}
					else {
						Selections.Add(cutout);
					}
				}

				CutShapes.Clear();
			}
			if (Selections.Count > 1) {
				multiSelect = true;
			}
			viewPort.Invalidate();
		}

		public void DeleteAllSelected() {
			List<Shape> ToDel = new List<Shape>();
			for (int j = 0; j < Selections.Count; j++)
			{
				ToDel.Add(Selections[j]);
			}
			List<Shape> GroupsToDel = new List<Shape>();
			for (int k = 0; k < ToDel.Count; k++)
			{
				if (ToDel[k].Grouped)
				{
					foreach (Shape potG in ShapeList)
					{
						if (potG is GroupShape)
						{
							GroupShape ConG = (GroupShape)potG;
							if (ConG.ContainsMember(ToDel[k]))
							{
								if (!GroupsToDel.Contains(ConG))
								{
									GroupsToDel.Add(ConG);
								}
							}
						}
					}
				}
				else
				{
					DeleteShape(ToDel[k]);
				}
			}
			for (int f = 0; f < GroupsToDel.Count; f++)
			{
				DeleteShape(GroupsToDel[f]);
			}
		}

		//set up custom colors
		private Color selectedFillColor = Color.White;
		public Color SelectedFillColor
		{
			get { return selectedFillColor; }
			set { selectedFillColor = value; }
		}

		private Color selectedBorderColor = Color.Black;
		public Color SelectedBorderColor
		{
			get { return selectedBorderColor; }
			set { selectedBorderColor = value; }
		}

		public void SetBorderColor(Color c) {
			SelectedBorderColor = c;
		}

		public void SetFillColor(Color c)
		{
			SelectedFillColor = c;
		}

		public void SetFillTransparency(int t) {
			selectedFillColor = Color.FromArgb(t, selectedFillColor);
			FillAlpha = t;
		}
		public void SetBorderTransparency(int t)
		{
			selectedBorderColor = Color.FromArgb(t, selectedBorderColor);
			BorderAlpha = t;
		}

		//border size
		private int selectedBorderSize = 1;
		public int SelectedBorderSize
		{
			get { return selectedBorderSize; }
			set { selectedBorderSize = value; }
		}
		/// <summary>
		/// Проверява дали дадена точка е в елемента.
		/// Обхожда в ред обратен на визуализацията с цел намиране на
		/// "най-горния" елемент т.е. този който виждаме под мишката.
		/// </summary>
		/// <param name="point">Указана точка</param>
		/// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
		public Shape ContainsPoint(PointF point)
		{
			for(int i = ShapeList.Count - 1; i >= 0; i--){
				if (ShapeList[i].Contains(point)){
					//found selected shape and returning it
					return ShapeList[i];
				}	
			}
			return null;
		}
		
		/// <summary>
		/// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
		/// </summary>
		/// <param name="p">Вектор на транслация.</param>
		public void TranslateTo(PointF p)
		{
			if (selections.Count>0) {
                for (int i = 0; i < selections.Count; i++)
                {
					var bounds = selections[i].path.GetBounds();
					selections[i].CenterPoint = new PointF(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2);
					Matrix mx = new Matrix();
					Matrix resetMX = new Matrix();
					resetMX.RotateAt((float)-selections[i].angle, selections[i].CenterPoint);
					selections[i].path.Transform(resetMX);
					mx.Translate(p.X - lastLocation.X, p.Y - lastLocation.Y);
					mx.RotateAt((float)selections[i].angle, selections[i].CenterPoint);
					selections[i].path.Transform(mx);
				}
				lastLocation = p;
			}
		}

		public void Rotate(float dg)
		{
			if (selections.Count > 0)
			{
				for (int i = 0; i < selections.Count; i++)
				{
					if (selections[i].Grouped) {
						PointF group_Cpoint = new PointF();
						//find the group this primitive belongs in
						foreach (Shape s in ShapeList) {
							if (s is GroupShape) {
								GroupShape g = (GroupShape)s;
								if (g.ContainsMember(selections[i])) {
									//when the group is found find the center point of the whole group and rotate around that point instead of around the primitive's center point
									group_Cpoint = g.GroupCenter();
								}
							}
						}
						Matrix mx = new Matrix();
						mx.RotateAt((float)-selections[i].angle, group_Cpoint);
						selections[i].path.Transform(mx);
						mx.Reset();
						mx.RotateAt(dg, group_Cpoint);
						selections[i].path.Transform(mx);
						selections[i].angle = dg;
					}
					else {
						var bounds = selections[i].path.GetBounds();
						selections[i].CenterPoint = new PointF(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2);
						Matrix mx = new Matrix();
						mx.RotateAt((float)-selections[i].angle, selections[i].CenterPoint);
						selections[i].path.Transform(mx);
						mx.Reset();
						mx.RotateAt(dg, selections[i].CenterPoint);
						selections[i].path.Transform(mx);
						selections[i].angle = dg;
					}
				}
			}
		}

		public void Resize(float X, float Y) {
			if (selections.Count > 0)
			{
				for (int i = 0; i < selections.Count; i++)
				{
					if (selections[i].scaleX!=X || selections[i].scaleY != Y) {
						if (selections[i].Grouped == false)
						{
							var bounds = selections[i].path.GetBounds();
							PointF lastPoint = new PointF(bounds.X, bounds.Y);
							//remove rotation
							Matrix resetRotation = new Matrix();
							resetRotation.RotateAt((float)-selections[i].angle, selections[i].CenterPoint);
							selections[i].path.Transform(resetRotation);
							//reset scale and scale with new x and y values
							Matrix m = new Matrix();
							Matrix resetScale = new Matrix();
							float resetX = 1 / selections[i].scaleX;
							float resetY = 1 / selections[i].scaleY;
							resetScale.Scale(resetX, resetY);
							selections[i].path.Transform(resetScale);
							m.Scale(X, Y);
							selections[i].path.Transform(m);
							selections[i].scaleX = X;
							selections[i].scaleY = Y;
							//bring it back to prev point
							bounds = selections[i].path.GetBounds();
							Matrix moveBackMX = new Matrix();
							moveBackMX.Translate(lastPoint.X - bounds.X, lastPoint.Y - bounds.Y);
							selections[i].path.Transform(moveBackMX);
							bounds = selections[i].path.GetBounds();
							//set rotation back
							Matrix setRotation = new Matrix();
							setRotation.RotateAt((float)selections[i].angle, selections[i].CenterPoint);
							selections[i].path.Transform(setRotation);
						}
						else {
							//find the group this primitive belongs in
							List<GroupShape> ScaledGroups = new List<GroupShape>();
							foreach (Shape s in ShapeList)
							{
								if (s is GroupShape)
								{
									GroupShape g = (GroupShape)s;
									if (g.ContainsMember(selections[i])&&!ScaledGroups.Contains(g))
									{
										g.ScaleGroup(X, Y);
										ScaledGroups.Add(g);
									}
								}
							}
						}
					}
				}
			}
		}

		public void SaveModel(string name) {
			FileStream fs = new FileStream(name, FileMode.Create);

			BinaryFormatter formatter = new BinaryFormatter();
			foreach (Shape s in ShapeList) {
				if (!(s is GroupShape))
				{
					s.PrepSave();
				}
				else {
					GroupShape g = (GroupShape)s;
					foreach (Shape item in g.Group) {
						item.PrepSave();
					}
				}
			}
			try
			{
				formatter.Serialize(fs, ShapeList);
			}
			catch (SerializationException e)
			{
				Console.WriteLine("Failed to serialize: " + e.Message);
			}
			finally
			{
				fs.Close();
			}
		}

		public void LoadModel(string file)
		{
			RemoveAllBtns();
			FileStream fs = new FileStream(file, FileMode.Open);
			try
			{
				BinaryFormatter formatter = new BinaryFormatter();
				ShapeList = (List<Shape>)formatter.Deserialize(fs);
			}
			catch (SerializationException e)
			{
				Console.WriteLine("Failed to deserialize: " + e.Message);
			}
			finally
			{
				fs.Close();
			}

			foreach (Shape s in ShapeList)
			{
				if (!(s is GroupShape))
				{
					s.PrepLoad();
				}
				else
				{
					GroupShape g = (GroupShape)s;
					foreach (Shape item in g.Group)
					{
						item.PrepLoad();
					}
				}
			}
			RefreshButtonList();
			viewPort.Invalidate();
		}

	}//dialog processor class end
}//namespace end
