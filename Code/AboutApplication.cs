using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePainterApplication
{
    public class AboutApplication
    {
        public static void AboutFeature(Form1 form)
        {
            var appName = "Simple Painter";
            var version = "1.0";
            var author = "Sakshi Gupta";
            var info = $@"Simple Painter is a simple drawing application written in C# using Windows Forms.

Version: {version}

Author: {author}

Welcome to Simple Painter - your new go-to drawing app that brings fun and creativity to your fingertips! 
Unleash your inner artist with our delightful set of features that make digital art a breeze:

- Get artsy with an array of shapes, like ellipses, rectangles, squares, circles, lines, and freeform doodles. 
Make your creations pop with customizable stroke widths, stroke colors, and fill colors. 
Feeling bold? Opt for ""Filled"" to add a vibrant touch to your shapes.

- Discover a handy Menu bar for seamless navigation: manage your Files (New, Open, Save, Save As, Exit), 
dabble with Edit tools (Undo, Redo, Clear All, Select, Delete), and explore View settings (In Browser, XML Format, About).

- Love precision? You'll adore our built-in ruler and guidelines that'll help you craft pixel-perfect designs like a pro.
 
- Set the mood with the perfect background color - a canvas that truly reflects your artistic vision.

- Feeling adventurous? Press the ""Fun"" button and watch as random shapes, colors, and sizes burst onto your screen, 
adding an element of surprise to your artwork.

Getting started is a piece of cake! Just pick a tool from the toolbar and let your imagination run wild on the canvas. 
Mix and match shapes, colors, and sizes to craft your very own masterpiece. 
When you're ready to show off your work, save it in different formats and share it with friends, family, or colleagues.

If you ever need a helping hand or more info about our app, the ""About"" section under the View menu has got you covered. 
So, grab your virtual paintbrush and dive into the colorful world of Simple Painter - happy drawing!";
    
               MessageBox.Show(info, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
