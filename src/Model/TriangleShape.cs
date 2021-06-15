using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    [Serializable]
    public class TriangleShape : Shape
    {
        public PointF point1;
        public PointF point2;
        public PointF point3;
        public TriangleShape(PointF one, PointF two, PointF three)
        {
            name = "Triangle";
            point1 = one;
            point2 = two;
            point3 = three;
            PointF[] trianglePoints = { point1, point2, point3 };
            path.AddPolygon(trianglePoints);
            CenterPoint = new PointF((point1.X + point2.X + point3.X) / 3, (point1.Y + point2.Y + point3.Y) / 3);
        }

        public TriangleShape(TriangleShape triangle) : base(triangle)
        {
            name = "Triangle";
            point1 = triangle.point1;
            point2 = triangle.point2;
            point3 = triangle.point3;
            PointF[] trianglePoints = { point1, point2, point3 };
            path.AddPolygon(trianglePoints);
            CenterPoint = new PointF((point1.X + point2.X + point3.X) / 3, (point1.Y + point2.Y + point3.Y) / 3);
            angle = triangle.angle;
            scaleX = triangle.scaleX;
            scaleY = triangle.scaleY;
            Grouped = triangle.Grouped;
            BeforeG_angle = triangle.BeforeG_angle;
            BeforeG_scaleX = triangle.BeforeG_scaleX;
            BeforeG_scaleY = triangle.BeforeG_scaleY;
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
        }
    }
}
