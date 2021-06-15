using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    [Serializable]
    public class LineShape : Shape
    {
        public PointF start = new PointF();
        public PointF end = new PointF();
        public LineShape(float x1,float y1,float x2,float y2)
        {
            name = "Line";

            start.X = x1;
            end.X = x2;
            start.Y = y1;
            end.Y = y2;

            path.AddLine(start,end);
            var bounds = path.GetBounds();
            CenterPoint = new PointF((bounds.X+bounds.X+bounds.Width)/2,(bounds.Y+bounds.Y+bounds.Height)/2);
        }

        public LineShape(LineShape line) : base(line)
        {
            name = line.name;

            start.X = line.start.X;
            end.X = line.end.X;
            start.Y = line.start.Y;
            end.Y = line.end.Y;
            angle = line.angle;
            scaleX = line.scaleX;
            scaleY = line.scaleY;
            Grouped = line.Grouped;
            BeforeG_angle = line.BeforeG_angle;
            BeforeG_scaleX = line.BeforeG_scaleX;
            BeforeG_scaleY = line.BeforeG_scaleY;
            path.AddLine(start, end);
            var bounds = path.GetBounds();
            CenterPoint = new PointF((bounds.X + bounds.X + bounds.Width) / 2, (bounds.Y + bounds.Y + bounds.Height) / 2);
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
        }
    }
}
