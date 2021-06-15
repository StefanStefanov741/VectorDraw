using System;
using System.Drawing;

namespace Draw
{
	[Serializable]
	public class RectangleShape : Shape
	{
		#region Constructor
		public RectangleShape(RectangleF rect) : base(rect)
		{
			name = "Rectangle";
			Rectangle = rect;
			path.AddRectangle(rect);
			var bounds = path.GetBounds();
			CenterPoint = new PointF(bounds.Width / 2.0f, bounds.Height / 2.0f);
		}

		public RectangleShape(RectangleShape rectangle) : base(rectangle)
		{
			name = rectangle.name;
			Rectangle = rectangle.Rectangle;
			path.AddRectangle(rectangle.Rectangle);
			CenterPoint = rectangle.CenterPoint;
			angle = rectangle.angle;
			scaleX = rectangle.scaleX;
			scaleY = rectangle.scaleY;
			Grouped = rectangle.Grouped;
			BeforeG_angle = rectangle.BeforeG_angle;
			BeforeG_scaleX = rectangle.BeforeG_scaleX;
			BeforeG_scaleY = rectangle.BeforeG_scaleY;
		}


		#endregion

		public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);
		}
	}
}
