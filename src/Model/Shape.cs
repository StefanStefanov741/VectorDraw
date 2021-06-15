using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
	/// <summary>
	/// Базовия клас на примитивите, който съдържа общите характеристики на примитивите.
	/// </summary>
	[Serializable]
	public abstract class Shape
	{
		[NonSerialized]
		public GraphicsPath path = new GraphicsPath();
		[NonSerialized]
		public Pen custom_pen = new Pen(Color.Black);
		private PointF centerPoint;
		public bool Grouped = false;
		public string name = "";
		[NonSerialized]
		Pen selectionPen = new Pen(Color.Black);
		//for saving path data and successfully serialize object
		PointF[] path_points;
		byte[] path_types;

	public virtual PointF CenterPoint
		{
			get { return centerPoint; }
			set { centerPoint = value; }
		}
		#region Constructors
		public double angle = 0;
		public double BeforeG_angle = 0;
		public float scaleX = 1;
		public float scaleY = 1;
		public float BeforeG_scaleX = 1;
		public float BeforeG_scaleY = 1;
		public Shape()
		{
		}
		
		public Shape(RectangleF rect)
		{
			rectangle = rect;
		}

		public Shape(Shape shape)
		{
			this.Height = shape.Height;
			this.Width = shape.Width;
			this.Location = shape.Location;
			this.rectangle = shape.rectangle;
			
			this.FillColor =  shape.FillColor;
			this.BorderColor =  shape.BorderColor;
			this.BorderSize =  shape.BorderSize;
		}
		#endregion
		
		#region Properties
		
		/// Обхващащ правоъгълник на елемента.
		private RectangleF rectangle;
		public virtual RectangleF Rectangle {
			get { return rectangle; }
			set { rectangle = value; }
		}

		/// Широчина на елемента.
		public virtual float Width {
			get { return Rectangle.Width; }
			set { rectangle.Width = value; }
		}
		
		/// Височина на елемента.
		public virtual float Height {
			get { return Rectangle.Height; }
			set { rectangle.Height = value; }
		}
		
		/// Горен ляв ъгъл на елемента.
		public virtual PointF Location {
			get { return Rectangle.Location; }
			set { rectangle.Location = value; }
		}

		/// Цвят на елемента.
		private Color fillColor;		
		public virtual Color FillColor {
			get { return fillColor; }
			set { fillColor = value; }
		}

		private Color borderColor;
		public virtual Color BorderColor
		{
			get { return borderColor; }
			set { borderColor = value; }
		}

		//border size
		private int borderSize = 1;
		public virtual int BorderSize
		{
			get { return borderSize; }
			set { borderSize = value; }
		}

		#endregion

		public virtual void PrepSave() {
			if (!(this is GroupShape))
			{
				path_points = path.PathPoints;
				path_types = path.PathTypes;
			}
		}

		public virtual void PrepLoad()
		{
			if (!(this is GroupShape))
			{
				path = new GraphicsPath(path_points, path_types);
			}
		}

		public virtual bool Contains(PointF point)
		{
			if (path.IsVisible(point) || path.IsOutlineVisible(point, custom_pen))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public virtual void DisplaySelection(Graphics grfx)
		{
			Pen selectionPen = new Pen(Color.Black);
			selectionPen.DashStyle = DashStyle.Dash;
			selectionPen.DashPattern = new float[] { 3, 3 };
			if (custom_pen.Width <= 1.5F)
			{
				selectionPen.Width = 2.2F;
			}
			else
			{
				selectionPen.Width = custom_pen.Width - 1;
			}
			if (custom_pen.Color == Color.Black)
			{
				selectionPen.Color = Color.White;
			}
			else
			{
				selectionPen.Color = Color.Black;
			}
			grfx.DrawPath(selectionPen, path);
		}

		bool created = false;
		public virtual void DrawSelf(Graphics grfx)
		{
			if (custom_pen == null) {
				custom_pen = new Pen(BorderColor);
			}
			custom_pen.Color = BorderColor;
			custom_pen.Width = BorderSize;

			if (!created)
			{
				created = true;
				path.Transform(grfx.Transform);
				grfx.DrawPath(custom_pen, path);
				grfx.FillPath(new SolidBrush(FillColor), path);
			}
			else
			{
				grfx.DrawPath(custom_pen, path);
				grfx.FillPath(new SolidBrush(FillColor), path);
			}
		}
    }
}
