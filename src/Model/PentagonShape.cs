using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    [Serializable]
    public class PentagonShape : Shape
    {
        public PointF point1;
        public PointF point2;
        public PointF point3;
        public PointF point4;
        public PointF point5;
        public PentagonShape(PointF one, PointF two, PointF three, PointF four, PointF five)
        {
            name = "Pentagon";
            point1 = one;
            point2 = two;
            point3 = three;
            point4 = four;
            point5 = five;
            PointF[] pentgaonPoints = { point1, point2, point3, point4, point5 };
            path.AddPolygon(pentgaonPoints);
            CenterPoint = new PointF(point1.X, (point1.Y + (point5.Y-point1.Y)/2));
        }

        public PentagonShape(PentagonShape pentagon) : base(pentagon)
        {
            name = "Pentagon";
            point1 = pentagon.point1;
            point2 = pentagon.point2;
            point3 = pentagon.point3;
            point4 = pentagon.point4;
            point5 = pentagon.point5;
            PointF[] pentgaonPoints = { point1, point2, point3, point4, point5 };
            path.AddPolygon(pentgaonPoints);
            CenterPoint = new PointF(point1.X, (point1.Y + (point5.Y - point1.Y) / 2));
            angle = pentagon.angle;
            scaleX = pentagon.scaleX;
            scaleY = pentagon.scaleY;
            Grouped = pentagon.Grouped;
            BeforeG_angle = pentagon.BeforeG_angle;
            BeforeG_scaleX = pentagon.BeforeG_scaleX;
            BeforeG_scaleY = pentagon.BeforeG_scaleY;
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
        }
    }
}
