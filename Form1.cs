using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Xml.Serialization;
using Svg;
using System.Collections.Generic;
using System.Drawing;



namespace SimplePainterApplication
{
    public partial class Form1 : Form
    {
        public List<Shape> Shapes = new List<Shape>();
        public List<Shape> RedoStack = new List<Shape>();
        private Ruler RulerX;
        private Ruler RulerY;
        private bool drawing = false;
        private Shape currentShape;
        private Color _backgroundColor = Color.White;

        private bool RulerXEnabled { get; set; }
        private bool RulerYEnabled { get; set; }
        private List<Guideline> guidelines = new List<Guideline>();

        private bool _selectModeEnabled = false;
        public PictureBox DrawingArea => PictureBox;
        public List<Shape> SelectedShapes { get; set; } = new List<Shape>();
        public Shape SelectedShape
        {
            get { return SelectedShapes.FirstOrDefault(); }
            set
            {
                SelectedShapes.Clear();
                if (value != null)
                {
                    SelectedShapes.Add(value);
                }
                Invalidate();
            }
        }

        public Form1()
        {
            InitializeComponent();
            strokeColorDialog.Color = Color.Black;
            fillColorDialog.Color = Color.Aquamarine;
            UpdatePanels();

            PictureBox.BackColor = Color.White;
            panel3.BackColor = _backgroundColor;

            this.guidelinesCheckBox.CheckedChanged += new System.EventHandler(this.guidelinesCheckBox_CheckedChanged);
            this.rulerCheckBox.CheckedChanged += new System.EventHandler(this.rulerCheckBox_CheckedChanged);

            RulerX = new Ruler(RulerOrientation.Horizontal, 0, PictureBox.Width, Color.Black);
            RulerY = new Ruler(RulerOrientation.Vertical, 0, PictureBox.Height, Color.Black);

            var guideline = new Guideline
            {
                Position = 100,
                Horizontal = true,
                Pen = new Pen(Color.Blue)
            };

            guidelines.Add(guideline);

            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            exitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.Z;
            clearToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;
        }


        private ShapeType GetSelectedShapeType()
        {
            if (ellipseRadioButton.Checked) return ShapeType.Ellipse;
            if (rectangleRadioButton.Checked) return ShapeType.Rectangle;
            if (squareRadioButton.Checked) return ShapeType.Square;
            if (lineRadioButton.Checked) return ShapeType.Line;
            if (freeformRadioButton.Checked) return ShapeType.Freeform;
            if (circleRadioButton.Checked) return ShapeType.Circle;

            // Default to rectangle if none selected
            return ShapeType.Rectangle;
        }

        private void SelectShape(PointF point)
        {
            foreach (var shape in Shapes)
            {
                shape.Selected = false;
            }
            SelectedShapes.Clear();

            for (int i = Shapes.Count - 1; i >= 0; i--)
            {
                var shape = Shapes[i];
                if (shape.ContainsPoint(point))
                {
                    shape.Selected = true;
                    SelectedShapes.Add(shape);
                    break;
                }
            }

            PictureBox.Invalidate();
        }

        public bool SelectModeEnabled
        {
            get { return _selectModeEnabled; }
            set
            {
                _selectModeEnabled = value;
                if (value)
                {
                    foreach (var shape in Shapes)
                    {
                        shape.Selected = false;
                    }
                    SelectedShapes.Clear();
                }
            }
        }

        private void UpdateGuidelines(int x, int y)
        {
            guidelines.Clear();

            if (guidelinesCheckBox.Checked)
            {
                if (RulerXEnabled)
                {
                    var guideline = new Guideline
                    {
                        Position = y,
                        Horizontal = true,
                        Pen = new Pen(Color.Blue)
                    };
                    guidelines.Add(guideline);
                }

                if (RulerYEnabled)
                {
                    var guideline = new Guideline
                    {
                        Position = x,
                        Horizontal = false,
                        Pen = new Pen(Color.Blue)
                    };
                    guidelines.Add(guideline);
                }
            }
        }

        private void UpdatePanels()
        {
            panel1.BackColor = strokeColorDialog.Color;
            panel2.BackColor = fillColorDialog.Color;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            strokeColorDialog.ShowDialog();
            UpdatePanels();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fillColorDialog.ShowDialog();
            UpdatePanels();
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (RulerXEnabled)
            {
                RulerX.Draw(e.Graphics);
            }
            if (RulerYEnabled)
            {
                RulerY.Draw(e.Graphics);
            }

            foreach (var guideline in guidelines)
            {
                guideline.Draw(e.Graphics);
            }

            foreach (var shape in Shapes)
            {
                shape.Draw(e.Graphics);
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectModeEnabled && e.Button == MouseButtons.Left)
            {
                SelectShape(e.Location);
            }
            else if (!SelectModeEnabled)
            {
                if (e.Button == MouseButtons.Left)
                {
                    drawing = true;
                    currentShape = new Shape()
                    {
                        X = e.X,
                        Y = e.Y,
                        Width = 0,
                        Height = 0,
                        StrokeColor = strokeColorDialog.Color,
                        FillColor = fillColorDialog.Color,
                        Filled = filledCheckBox.Checked,
                        StrokeThickness = strokeWidthTrackBar.Value,
                        Type = GetSelectedShapeType(),

                    };

                    if (currentShape.Type == ShapeType.Freeform)
                    {
                        currentShape.Points = new List<Point> { new Point(e.X, e.Y) };
                    }

                    Shapes.Add(currentShape);
                }
                else if (e.Button == MouseButtons.Right) // Cancel drawing the shape
                {
                    drawing = false;
                    currentShape = null;
                    PictureBox.Invalidate();
                }
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing && currentShape != null)
            {
                if (currentShape.Type == ShapeType.Freeform)
                {
                    currentShape.Points.Add(new Point(e.X, e.Y));
                }
                else
                {
                    currentShape.Width = e.X - currentShape.X;
                    currentShape.Height = e.Y - currentShape.Y;
                }
                PictureBox.Invalidate();
            }

            UpdateGuidelines(e.X, e.Y);
            PictureBox.Invalidate();
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing && e.Button == MouseButtons.Left)
            {
                drawing = false;
                currentShape = null;
                PictureBox.Invalidate();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuEventHandler.NewToolStripMenuItem_Click(this, sender, e);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuEventHandler.OpenToolStripMenuItem_Click(this, sender, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuEventHandler.SaveToolStripMenuItem_Click(this, sender, e);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuEventHandler.SaveAsToolStripMenuItem_Click(this, sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuEventHandler.ExitToolStripMenuItem_Click(this, sender, e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            MenuEventHandler.Form1_KeyDown(this, sender, e);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuEventHandler.Undo_Click(this, sender, e);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuEventHandler.Redo_Click(this, sender, e);
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuEventHandler.Select_Click(this, sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuEventHandler.Delete_Click(this, sender, e);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuEventHandler.ClearAll_Click(this, sender, e);
        }

        private void inBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuEventHandler.InBrowser_Click(this, sender, e);
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuEventHandler.XmlFormat_Click(this, sender, e);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutApplication.AboutFeature(this);
        }
        private void rulerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!rulerCheckBox.Checked && guidelinesCheckBox.Checked)
            {
                MessageBox.Show("It is impossible to hide the ruler while the guidelines are visible.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rulerCheckBox.Checked = true; // Re-check the ruler checkbox
            }
            else
            {
                RulerXEnabled = rulerCheckBox.Checked;
                RulerYEnabled = rulerCheckBox.Checked;
                PictureBox.Invalidate();
            }
        }

        private void guidelinesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RulerXEnabled = true;
            RulerYEnabled = true;
            PictureBox.Invalidate();
        }

        private void funButton_Click(object sender, EventArgs e)
        {

            Random rand = new Random();
            int numShapes = rand.Next(5, 20);

            ShapeType[] shapeTypes = { ShapeType.Ellipse, ShapeType.Rectangle, ShapeType.Square, ShapeType.Line, ShapeType.Circle };

            for (int i = 0; i < numShapes; i++)
            {
                ShapeType shapeType = shapeTypes[rand.Next(shapeTypes.Length)];
                int size = rand.Next(20, 300);
                int x = rand.Next(PictureBox.Width - size);
                int y = rand.Next(PictureBox.Height - size);
                Color strokeColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                int strokeThickness = rand.Next(1, 11);
                Color fillColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));

                Shape shape = new Shape()
                {
                    Type = shapeType,
                    X = x,
                    Y = y,
                    Width = size,
                    Height = size,
                    StrokeColor = strokeColor,
                    StrokeThickness = strokeThickness,
                    FillColor = fillColor,
                    Filled = rand.Next(2) == 0
                };

                Shapes.Add(shape);
            }

            PictureBox.Invalidate();
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PictureBox.BackColor = dialog.Color;
                _backgroundColor = dialog.Color;
                panel3.BackColor = _backgroundColor;
            }
        }


    }
}