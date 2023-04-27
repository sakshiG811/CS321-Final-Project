namespace SimplePainterApplication
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PictureBox = new PictureBox();
            strokeWidthTrackBar = new TrackBar();
            strokeColorDialog = new ColorDialog();
            strokeColorButton = new Button();
            filledCheckBox = new CheckBox();
            fillColorButton = new Button();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            lineRadioButton = new RadioButton();
            squareRadioButton = new RadioButton();
            circleRadioButton = new RadioButton();
            freeformRadioButton = new RadioButton();
            rectangleRadioButton = new RadioButton();
            ellipseRadioButton = new RadioButton();
            fillColorDialog = new ColorDialog();
            menuStrip1 = new MenuStrip();
            testToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            clearToolStripMenuItem = new ToolStripMenuItem();
            selectToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            inBrowserToolStripMenuItem = new ToolStripMenuItem();
            xMLToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            panel2 = new Panel();
            rulerCheckBox = new CheckBox();
            guidelinesCheckBox = new CheckBox();
            funButton = new Button();
            backgroundButton = new Button();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)strokeWidthTrackBar).BeginInit();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // PictureBox
            // 
            PictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PictureBox.Location = new Point(0, 218);
            PictureBox.Margin = new Padding(4, 3, 4, 3);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new Size(1241, 414);
            PictureBox.TabIndex = 0;
            PictureBox.TabStop = false;
            PictureBox.Paint += PictureBox_Paint;
            PictureBox.MouseDown += PictureBox_MouseDown;
            PictureBox.MouseMove += PictureBox_MouseMove;
            PictureBox.MouseUp += PictureBox_MouseUp;
            // 
            // strokeWidthTrackBar
            // 
            strokeWidthTrackBar.Location = new Point(13, 102);
            strokeWidthTrackBar.Margin = new Padding(4, 3, 4, 3);
            strokeWidthTrackBar.Minimum = 1;
            strokeWidthTrackBar.Name = "strokeWidthTrackBar";
            strokeWidthTrackBar.Size = new Size(242, 69);
            strokeWidthTrackBar.TabIndex = 1;
            strokeWidthTrackBar.Value = 1;
            // 
            // strokeColorButton
            // 
            strokeColorButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            strokeColorButton.Location = new Point(582, 46);
            strokeColorButton.Margin = new Padding(4, 3, 4, 3);
            strokeColorButton.Name = "strokeColorButton";
            strokeColorButton.Size = new Size(163, 43);
            strokeColorButton.TabIndex = 2;
            strokeColorButton.Text = "Stroke Colour";
            strokeColorButton.UseVisualStyleBackColor = true;
            strokeColorButton.Click += button1_Click;
            // 
            // filledCheckBox
            // 
            filledCheckBox.AutoSize = true;
            filledCheckBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            filledCheckBox.Location = new Point(902, 55);
            filledCheckBox.Margin = new Padding(4, 3, 4, 3);
            filledCheckBox.Name = "filledCheckBox";
            filledCheckBox.Size = new Size(85, 32);
            filledCheckBox.TabIndex = 3;
            filledCheckBox.Text = "Filled";
            filledCheckBox.UseVisualStyleBackColor = true;
            // 
            // fillColorButton
            // 
            fillColorButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            fillColorButton.Location = new Point(582, 102);
            fillColorButton.Margin = new Padding(4, 3, 4, 3);
            fillColorButton.Name = "fillColorButton";
            fillColorButton.Size = new Size(163, 43);
            fillColorButton.TabIndex = 4;
            fillColorButton.Text = "Fill Colour";
            fillColorButton.UseVisualStyleBackColor = true;
            fillColorButton.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(54, 55);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(127, 28);
            label1.TabIndex = 5;
            label1.Text = "Stroke Width";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 190);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(109, 25);
            label2.TabIndex = 6;
            label2.Text = "My Picture:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lineRadioButton);
            groupBox1.Controls.Add(squareRadioButton);
            groupBox1.Controls.Add(circleRadioButton);
            groupBox1.Controls.Add(freeformRadioButton);
            groupBox1.Controls.Add(rectangleRadioButton);
            groupBox1.Controls.Add(ellipseRadioButton);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(272, 38);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(302, 160);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Shapes: ";
            // 
            // lineRadioButton
            // 
            lineRadioButton.AutoSize = true;
            lineRadioButton.Location = new Point(159, 105);
            lineRadioButton.Name = "lineRadioButton";
            lineRadioButton.Size = new Size(72, 32);
            lineRadioButton.TabIndex = 5;
            lineRadioButton.TabStop = true;
            lineRadioButton.Text = "Line";
            lineRadioButton.UseVisualStyleBackColor = true;
            // 
            // squareRadioButton
            // 
            squareRadioButton.AutoSize = true;
            squareRadioButton.Location = new Point(159, 70);
            squareRadioButton.Name = "squareRadioButton";
            squareRadioButton.Size = new Size(98, 32);
            squareRadioButton.TabIndex = 4;
            squareRadioButton.TabStop = true;
            squareRadioButton.Text = "Square";
            squareRadioButton.UseVisualStyleBackColor = true;
            // 
            // circleRadioButton
            // 
            circleRadioButton.AutoSize = true;
            circleRadioButton.Location = new Point(159, 33);
            circleRadioButton.Name = "circleRadioButton";
            circleRadioButton.Size = new Size(85, 32);
            circleRadioButton.TabIndex = 3;
            circleRadioButton.TabStop = true;
            circleRadioButton.Text = "Circle";
            circleRadioButton.UseVisualStyleBackColor = true;
            // 
            // freeformRadioButton
            // 
            freeformRadioButton.AutoSize = true;
            freeformRadioButton.Location = new Point(7, 105);
            freeformRadioButton.Name = "freeformRadioButton";
            freeformRadioButton.Size = new Size(116, 32);
            freeformRadioButton.TabIndex = 2;
            freeformRadioButton.TabStop = true;
            freeformRadioButton.Text = "Freeform";
            freeformRadioButton.UseVisualStyleBackColor = true;
            // 
            // rectangleRadioButton
            // 
            rectangleRadioButton.AutoSize = true;
            rectangleRadioButton.Location = new Point(7, 70);
            rectangleRadioButton.Margin = new Padding(4, 3, 4, 3);
            rectangleRadioButton.Name = "rectangleRadioButton";
            rectangleRadioButton.Size = new Size(122, 32);
            rectangleRadioButton.TabIndex = 1;
            rectangleRadioButton.Text = "Rectangle";
            rectangleRadioButton.UseVisualStyleBackColor = true;
            // 
            // ellipseRadioButton
            // 
            ellipseRadioButton.AutoSize = true;
            ellipseRadioButton.Checked = true;
            ellipseRadioButton.Location = new Point(7, 33);
            ellipseRadioButton.Margin = new Padding(4, 3, 4, 3);
            ellipseRadioButton.Name = "ellipseRadioButton";
            ellipseRadioButton.Size = new Size(92, 32);
            ellipseRadioButton.TabIndex = 0;
            ellipseRadioButton.TabStop = true;
            ellipseRadioButton.Text = "Ellipse";
            ellipseRadioButton.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { testToolStripMenuItem, editToolStripMenuItem, viewToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(1241, 35);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, exitToolStripMenuItem });
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(54, 29);
            testToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(176, 34);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(176, 34);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(176, 34);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(176, 34);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(176, 34);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, clearToolStripMenuItem, selectToolStripMenuItem, deleteToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(58, 29);
            editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(178, 34);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.Size = new Size(178, 34);
            redoToolStripMenuItem.Text = "Redo";
            redoToolStripMenuItem.Click += redoToolStripMenuItem_Click;
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(178, 34);
            clearToolStripMenuItem.Text = "Clear All";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // selectToolStripMenuItem
            // 
            selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            selectToolStripMenuItem.Size = new Size(178, 34);
            selectToolStripMenuItem.Text = "Select";
            selectToolStripMenuItem.Click += selectToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(178, 34);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inBrowserToolStripMenuItem, xMLToolStripMenuItem, aboutToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(65, 29);
            viewToolStripMenuItem.Text = "View";
            // 
            // inBrowserToolStripMenuItem
            // 
            inBrowserToolStripMenuItem.Name = "inBrowserToolStripMenuItem";
            inBrowserToolStripMenuItem.Size = new Size(211, 34);
            inBrowserToolStripMenuItem.Text = "In Browser";
            inBrowserToolStripMenuItem.Click += inBrowserToolStripMenuItem_Click;
            // 
            // xMLToolStripMenuItem
            // 
            xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            xMLToolStripMenuItem.Size = new Size(211, 34);
            xMLToolStripMenuItem.Text = "XML Format";
            xMLToolStripMenuItem.Click += xMLToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(211, 34);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(767, 46);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(47, 43);
            panel1.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.Location = new Point(767, 102);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(47, 43);
            panel2.TabIndex = 14;
            // 
            // rulerCheckBox
            // 
            rulerCheckBox.AutoSize = true;
            rulerCheckBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            rulerCheckBox.Location = new Point(902, 102);
            rulerCheckBox.Name = "rulerCheckBox";
            rulerCheckBox.Size = new Size(83, 32);
            rulerCheckBox.TabIndex = 15;
            rulerCheckBox.Text = "Ruler";
            rulerCheckBox.UseVisualStyleBackColor = true;
            rulerCheckBox.CheckedChanged += rulerCheckBox_CheckedChanged;
            // 
            // guidelinesCheckBox
            // 
            guidelinesCheckBox.AutoSize = true;
            guidelinesCheckBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            guidelinesCheckBox.Location = new Point(902, 148);
            guidelinesCheckBox.Name = "guidelinesCheckBox";
            guidelinesCheckBox.Size = new Size(129, 32);
            guidelinesCheckBox.TabIndex = 16;
            guidelinesCheckBox.Text = "Guidelines";
            guidelinesCheckBox.UseVisualStyleBackColor = true;
            guidelinesCheckBox.CheckedChanged += guidelinesCheckBox_CheckedChanged;
            // 
            // funButton
            // 
            funButton.Font = new Font("Snap ITC", 14F, FontStyle.Bold, GraphicsUnit.Point);
            funButton.Location = new Point(1063, 55);
            funButton.Name = "funButton";
            funButton.Size = new Size(166, 122);
            funButton.TabIndex = 17;
            funButton.Text = "Fun Button";
            funButton.UseVisualStyleBackColor = true;
            funButton.Click += funButton_Click;
            // 
            // backgroundButton
            // 
            backgroundButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            backgroundButton.Location = new Point(582, 160);
            backgroundButton.Name = "backgroundButton";
            backgroundButton.Size = new Size(163, 43);
            backgroundButton.TabIndex = 18;
            backgroundButton.Text = "Background";
            backgroundButton.UseVisualStyleBackColor = true;
            backgroundButton.Click += backgroundButton_Click;
            // 
            // panel3
            // 
            panel3.Location = new Point(767, 160);
            panel3.Name = "panel3";
            panel3.Size = new Size(47, 43);
            panel3.TabIndex = 19;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1241, 633);
            Controls.Add(panel3);
            Controls.Add(backgroundButton);
            Controls.Add(funButton);
            Controls.Add(guidelinesCheckBox);
            Controls.Add(rulerCheckBox);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(fillColorButton);
            Controls.Add(filledCheckBox);
            Controls.Add(strokeColorButton);
            Controls.Add(strokeWidthTrackBar);
            Controls.Add(PictureBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)strokeWidthTrackBar).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PictureBox;
        private TrackBar strokeWidthTrackBar;
        private ColorDialog strokeColorDialog;
        private Button strokeColorButton;
        private CheckBox filledCheckBox;
        private Button fillColorButton;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private RadioButton rectangleRadioButton;
        private RadioButton ellipseRadioButton;
        private ColorDialog fillColorDialog;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem testToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private Panel panel1;
        private Panel panel2;
        private RadioButton lineRadioButton;
        private RadioButton squareRadioButton;
        private RadioButton circleRadioButton;
        private RadioButton freeformRadioButton;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem selectToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem inBrowserToolStripMenuItem;
        private ToolStripMenuItem xMLToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private CheckBox rulerCheckBox;
        private CheckBox guidelinesCheckBox;
        private Button funButton;
        private Button backgroundButton;
        private Panel panel3;
    }
}