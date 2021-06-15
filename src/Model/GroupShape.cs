using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    [Serializable]
    class GroupShape : Shape
    {
        public GroupShape()
        {
            group = new List<Shape>();
            name = "Group";
        }

        public GroupShape(GroupShape groupS)
        {
            group = groupS.ReturnCopyOfGroup();
            name = groupS.name;
        }

        private List<Shape> group;
        public List<Shape> Group
        {
            get { return group; }
            set { group = value; }
        }

        public void AddMember(Shape shp) {
            group.Add(shp);
        }
        public void RemoveMember(Shape shp)
        {
            group.Remove(shp);
        }
        public bool ContainsMember(Shape shp)
        {
            return group.Contains(shp);
        }
        //chech if all selected shapes are a part of this group
        public bool HasGroup(List<Shape> shapes)
        {
            bool possible = true;
            foreach (Shape shp in shapes)
            {
                if (!Group.Contains(shp))
                {
                    possible = false;
                }
            }
            return possible;
        }
        public List<Shape> ReturnGroup() {
            return Group;
        }

        List<Shape> ReturnCopyOfGroup()
        {
            List<Shape> CloneGroup = new List<Shape>();
            foreach (Shape copied_s in group)
            {
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
                else
                {
                    new_shape = new RectangleShape((RectangleShape)copied_s);
                }


                if (!(new_shape is GroupShape))
                {
                    //move to the proper position
                    Matrix mx = new Matrix();
                    mx.Translate(copied_s.path.GetBounds().Location.X - new_shape.path.GetBounds().Location.X, copied_s.path.GetBounds().Location.Y - new_shape.path.GetBounds().Location.Y);
                    new_shape.path.Transform(mx);

                    //scale properly
                    var bounds = new_shape.path.GetBounds();
                    PointF lastPoint = new PointF(bounds.X, bounds.Y);
                    Matrix m = new Matrix();
                    m.Scale(new_shape.BeforeG_scaleX, new_shape.BeforeG_scaleY);
                    new_shape.path.Transform(m);

                    //give proper rotation
                    bounds = new_shape.path.GetBounds();
                    new_shape.CenterPoint = new PointF(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2);
                    Matrix Rmx = new Matrix();
                    Rmx.RotateAt((float)new_shape.BeforeG_angle, new_shape.CenterPoint);
                    new_shape.path.Transform(Rmx);

                    //bring it back to prev point
                    bounds = new_shape.path.GetBounds();
                    Matrix moveBackMX = new Matrix();
                    moveBackMX.Translate(lastPoint.X - bounds.X, lastPoint.Y - bounds.Y);
                    new_shape.path.Transform(moveBackMX);
                }
                CloneGroup.Add(new_shape);
            }
            return CloneGroup;
        }

        public override void DisplaySelection(Graphics grfx)
        {
            foreach (Shape s in group) {
                s.DisplaySelection(grfx);
            }
        }

        public PointF GroupCenter()
        {
            var bounds = group[0].path.GetBounds();
            group[0].CenterPoint = new PointF(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2);
            return group[0].CenterPoint;
        }

        public void ScaleGroup(float X, float Y) {
            PointF groupPrevPoint = group[0].path.GetBounds().Location;
            for (int i=0;i<group.Count;i++) {
                var bounds = group[i].path.GetBounds();
                //reset scale and scale with new x and y values
                Matrix m = new Matrix();
                Matrix resetScale = new Matrix();
                float resetX = 1 / group[i].scaleX;
                float resetY = 1 / group[i].scaleY;
                resetScale.Scale(resetX, resetY);
                group[i].path.Transform(resetScale);
                m.Scale(X, Y);
                group[i].path.Transform(m);
                group[i].scaleX = X;
                group[i].scaleY = Y;
            }
            PointF groupNewPoint = group[0].path.GetBounds().Location;
            float offsetX = groupNewPoint.X - groupPrevPoint.X;
            float offsetY = groupNewPoint.Y - groupPrevPoint.Y;
            for (int i = 0; i < group.Count; i++)
            {
                //move the group back to the previous point
                Matrix moveMatrix = new Matrix();
                moveMatrix.Translate(-offsetX,-offsetY);
                group[i].path.Transform(moveMatrix);
            }
        }
        public override bool Contains(PointF point)
        {
            foreach (Shape primitive in group)
            {
                if (primitive.Contains(point))
                {
                    return true;
                }
            }
            return false;
        }

        public override void DrawSelf(Graphics grfx)
        {
            foreach (Shape primitive in group)
            {
                primitive.DrawSelf(grfx);
            }
        }
    }
}
