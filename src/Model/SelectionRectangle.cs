using System.Drawing;

namespace Draw
{
    class SelectionRectangle : Shape
	{
		#region Constructor
		public SelectionRectangle(RectangleF rect) : base(rect)
		{
		}

		public SelectionRectangle(SelectionRectangle rectangle) : base(rectangle)
		{
		}
        public override bool Contains(PointF point)
        {
			return false;
        }

        #endregion

		public override void DrawSelf(Graphics grfx)
		{
			custom_pen.Color = Color.Black;
			custom_pen.Width = 1;
			custom_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
			custom_pen.DashPattern = new float[] { 5, 5 };

			grfx.DrawRectangle(custom_pen, new Rectangle((int)Rectangle.X, (int)Rectangle.Y, (int)Rectangle.Width, (int)Rectangle.Height));
		}
	}
}
