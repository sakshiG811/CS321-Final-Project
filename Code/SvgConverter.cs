using Svg.Pathing;
using Svg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePainterApplication
{
    public static class SvgConverter
    {
        public static List<Shape> ToShapes(this SvgDocument svgDoc)
        {
            List<Shape> shapes = new List<Shape>();

            foreach (var element in svgDoc.Children)
            {
                Shape shape = null;

                switch (element)
                {
                    case SvgRectangle svgRectangle:
                        shape = new Shape
                        {
                            Type = ShapeType.Rectangle,
                            X = svgRectangle.X,
                            Y = svgRectangle.Y,
                            Width = svgRectangle.Width,
                            Height = svgRectangle.Height,
                            StrokeColor = svgRectangle.Stroke.ToColor(),
                            FillColor = svgRectangle.Fill.ToColor(),
                        };
                        break;

                    case SvgEllipse svgEllipse:
                        shape = new Shape
                        {
                            Type = svgEllipse.RadiusX == svgEllipse.RadiusY ? ShapeType.Circle : ShapeType.Ellipse,
                            X = svgEllipse.CenterX - svgEllipse.RadiusX,
                            Y = svgEllipse.CenterY - svgEllipse.RadiusY,
                            Width = svgEllipse.RadiusX * 2,
                            Height = svgEllipse.RadiusY * 2,
                            StrokeColor = svgEllipse.Stroke.ToColor(),
                            FillColor = svgEllipse.Fill.ToColor(),
                        };
                        break;

                    case SvgLine svgLine:
                        shape = new Shape
                        {
                            Type = ShapeType.Line,
                            X = svgLine.StartX,
                            Y = svgLine.StartY,
                            Width = svgLine.EndX - svgLine.StartX,
                            Height = svgLine.EndY - svgLine.StartY,
                            StrokeColor = svgLine.Stroke.ToColor(),
                        };
                        break;

                    case SvgPath svgPath:
                        shape = new Shape
                        {
                            Type = ShapeType.Freeform,
                            Points = new List<Point>(),
                            StrokeColor = svgPath.Stroke.ToColor(),
                        };

                        foreach (var segment in svgPath.PathData)
                        {
                            if (segment is SvgMoveToSegment moveTo)
                            {
                                shape.Points.Add(new Point((int)moveTo.Start.X, (int)moveTo.Start.Y));
                            }
                            else if (segment is SvgLineSegment line)
                            {
                                shape.Points.Add(new Point((int)line.End.X, (int)line.End.Y));
                            }
                        }
                        break;
                }

                if (shape != null)
                {
                    shapes.Add(shape);
                }
            }

            return shapes;
        }
    }

    public static class SvgPaintServerExtensions
    {
        public static Color ToColor(this SvgPaintServer paintServer)
        {
            if (paintServer is SvgColourServer colorServer)
            {
                return Color.FromArgb(colorServer.Colour.R, colorServer.Colour.G, colorServer.Colour.B);
            }

            return Color.Empty;

        }
    }
}
