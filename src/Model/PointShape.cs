using System;
using System.Drawing;

namespace Draw
{
    [Serializable]
    public class PointShape : Shape
    {
        public PointShape(RectangleF rect) : base(rect)
        {
            name = "Point";
            path.AddEllipse(rect);
            Rectangle = rect;
            var bounds = path.GetBounds();
            CenterPoint = new PointF(bounds.Width / 2.0f, bounds.Height / 2.0f);
        }

        public PointShape(PointShape point) : base(point)
        {
            name = point.name;
            Rectangle = point.Rectangle;
            path.AddEllipse(Rectangle);
            angle = point.angle;
            scaleX = point.scaleX;
            scaleY = point.scaleY;
            Grouped = point.Grouped;
            BeforeG_angle = point.BeforeG_angle;
            BeforeG_scaleX = point.BeforeG_scaleX;
            BeforeG_scaleY = point.BeforeG_scaleY;
            var bounds = path.GetBounds();
            CenterPoint = new PointF(bounds.Width / 2.0f, bounds.Height / 2.0F);
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
        }
    }
}
