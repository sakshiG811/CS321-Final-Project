using Svg;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Xml.Serialization;
using ExCSS;

namespace SimplePainterApplication
{
    public class MenuEventHandler
	{
        public static void NewToolStripMenuItem_Click(Form1 form, object sender, EventArgs e)
		{
            if (form.Shapes.Count > 0)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes before creating a new file?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SaveToolStripMenuItem_Click(form, sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            form.Shapes.Clear();
            form.RedoStack.Clear();
            form.DrawingArea.Invalidate();
        }

        public static void OpenToolStripMenuItem_Click(Form1 form, object sender, EventArgs e)
        {

            if (form.Shapes.Count > 0)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes before opening a new file?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SaveToolStripMenuItem_Click(form, sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Open SVG File",
                Filter = "SVG Files|*.svg",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SvgDocument svgDoc;
                    try
                    {
                        svgDoc = SvgDocument.Open(openFileDialog.FileName);
                        Debug.WriteLine("Opening file: " + openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Unable to load the SVG file.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    List<Shape> shapes = SvgConverter.ToShapes(svgDoc);

                    Bitmap bitmap = new Bitmap(form.DrawingArea.Width, form.DrawingArea.Height);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.Clear(System.Drawing.Color.White);
                        foreach (Shape shape in shapes)
                        {
                            shape.Draw(g);
                        }
                    }

                    form.DrawingArea.Image = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static void SaveToolStripMenuItem_Click(Form1 form, object sender, EventArgs e)
        {
            Debug.WriteLine("Save menu option clicked.");

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SVG files|*.svg";
            saveFileDialog.Title = "Save file...";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Debug.WriteLine("Saving file: " + saveFileDialog.FileName);

                XmlSerializer serializer = new XmlSerializer(typeof(List<Shape>));
                StreamWriter writer = new StreamWriter(saveFileDialog.FileName);
                serializer.Serialize(writer, form.Shapes);
                writer.Close();
            }
        }

        public static void SaveAsToolStripMenuItem_Click(Form1 form, object sender, EventArgs e)
        {
            Debug.WriteLine("Save As menu option clicked.");
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SVG files|*.svg|PNG files|*.png|JPEG files|*.jpg";
            saveFileDialog.Title = "Save file as...";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(saveFileDialog.FileName).ToLower();
                switch (extension)
                {
                    case ".svg":
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Shape>));
                        StreamWriter writer = new StreamWriter(saveFileDialog.FileName);
                        serializer.Serialize(writer, form.Shapes);
                        writer.Close();
                        break;

                    case ".png":
                        Bitmap bmp = new Bitmap(form.DrawingArea.Width, form.DrawingArea.Height);
                        form.DrawingArea.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                        bmp.Save(saveFileDialog.FileName, ImageFormat.Png);
                        break;

                    case ".jpg":
                        Bitmap bmp2 = new Bitmap(form.DrawingArea.Width, form.DrawingArea.Height);
                        form.DrawingArea.DrawToBitmap(bmp2, new Rectangle(0, 0, bmp2.Width, bmp2.Height));
                        bmp2.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                        break;

                    default:
                        MessageBox.Show("Unsupported file extension: " + extension, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }

        public static void ExitToolStripMenuItem_Click(Form1 form, object sender, EventArgs e)
        {
            if (form.Shapes.Count > 0)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes before exiting?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SaveToolStripMenuItem_Click(form, sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            Application.Exit();
        }

        public static void Undo_Click(Form1 form, object sender, EventArgs e)
        {
            if (form.Shapes.Count > 0)
            {
                form.RedoStack.Add(form.Shapes[form.Shapes.Count - 1]);
                form.Shapes.RemoveAt(form.Shapes.Count - 1);
                form.DrawingArea.Invalidate();
            }
        }

        public static void Redo_Click(Form1 form, object sender, EventArgs e)
        {
            if (form.RedoStack.Count > 0)
            {
                form.Shapes.Add(form.RedoStack[form.RedoStack.Count - 1]);
                form.RedoStack.RemoveAt(form.RedoStack.Count - 1);
                form.DrawingArea.Invalidate();
            }
        }

        public static void ClearAll_Click(Form1 form, object sender, EventArgs e)
        {
            form.Shapes.Clear();
            form.RedoStack.Clear();
            form.DrawingArea.Invalidate();
        }

        public static void Select_Click(Form1 form, object sender, EventArgs e)
        {
            if (form.Shapes.Count == 0)
            {
                form.SelectModeEnabled = false;
                return;
            }

            form.SelectModeEnabled = true;
            foreach (var shape in form.Shapes)
            {
                shape.Selected = false;
            }
            form.SelectedShapes.Clear();
        }

        public static void Delete_Click(Form1 form, object sender, EventArgs e)
        {
            if (form.SelectedShapes.Count > 0)
            {
                form.Shapes.RemoveAll(shape => shape.Selected);
                form.SelectedShapes.Clear();
                form.DrawingArea.Invalidate();
                form.SelectModeEnabled = false;
            }
        }

        public static void InBrowser_Click(Form1 form, object sender, EventArgs e)
        {
            string imageFilePath = "image.html";
            using (StreamWriter sw = new StreamWriter(imageFilePath))
            {
                Bitmap bmp = new Bitmap(form.DrawingArea.Width, form.DrawingArea.Height);
                form.DrawingArea.DrawToBitmap(bmp, form.DrawingArea.ClientRectangle);

                string base64Image = ImageToBase64(bmp);
                sw.Write($"<html><body><img src=\"{base64Image}\"></body></html>");
            }

            // Use the "shell:open" command to open the file in the default web browser
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C start \"\" \"{imageFilePath}\"",
                CreateNoWindow = true,
                UseShellExecute = false
            };

            Process.Start(psi);
        }

        public static string ImageToBase64(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 string
                string base64String = Convert.ToBase64String(imageBytes);
                return $"data:image/png;base64,{base64String}";
            }
        }

        public static void XmlFormat_Click(Form1 form, object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Shape>));
            using (FileStream stream = new FileStream("shapes.xml", FileMode.Create))
            {
                serializer.Serialize(stream, form.Shapes);
            }

            string xml = File.ReadAllText("shapes.xml");
            MessageBox.Show(xml, "Shapes XML");
        }

        public static void Form1_KeyDown(Form1 form, object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.N:
                    if (e.Control)
                    {
                        SaveToolStripMenuItem_Click(form, sender, e);
                    }
                    break;

                case Keys.O:
                    if (e.Control)
                    {
                        SaveToolStripMenuItem_Click(form, sender, e);
                    }
                    break;

                case Keys.S:
                    if (e.Control && !e.Shift)
                    {
                        SaveToolStripMenuItem_Click(form, sender, e);
                    }
                    else if (e.Control && e.Shift)
                    {
                        SaveAsToolStripMenuItem_Click(form, sender, e);
                    }
                    break;
                case Keys.E:
                    if (e.Control)
                    {
                        ExitToolStripMenuItem_Click(form, sender, e);
                    }
                    break;
                case Keys.Z:
                    if (e.Control && !e.Shift)
                    {
                        Undo_Click(form, sender, e);
                    }
                    else if (e.Control && e.Shift)
                    {
                        Redo_Click(form, sender, e);
                    }
                    break;
                case Keys.D:
                    if (e.Control)
                    {
                        ClearAll_Click(form, sender, e);
                    }
                    break;
            }
        }
    }
}
	

