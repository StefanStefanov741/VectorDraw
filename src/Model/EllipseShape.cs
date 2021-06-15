using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    [Serializable]
    public class EllipseShape : Shape
    {
        public EllipseShape(RectangleF rect) : base(rect)
        {
            name = "Ellipse";
            Rectangle = rect;
            path.AddEllipse(rect);
            var bounds = path.GetBounds();
            CenterPoint = new PointF(bounds.Width / 2.0f, bounds.Height / 2.0f);
        }

        public EllipseShape(EllipseShape ellipse) : base(ellipse)
        {
            name = ellipse.name;
            Rectangle = ellipse.Rectangle;
            path.AddEllipse(Rectangle);
            angle = ellipse.angle;
            scaleX = ellipse.scaleX;
            scaleY = ellipse.scaleY;
            var bounds = path.GetBounds();
            CenterPoint = new PointF(bounds.Width / 2.0f, bounds.Height / 2.0f);
            Grouped = ellipse.Grouped;
            BeforeG_angle = ellipse.BeforeG_angle;
            BeforeG_scaleX = ellipse.BeforeG_scaleX;
            BeforeG_scaleY = ellipse.BeforeG_scaleY;
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
        }
    }
}
