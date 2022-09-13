using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.Graphics;
using System.Drawing;
using Sys = Cosmos.System;
using Cosmos.System;


namespace NNIOS.Graphics
{
    public class GUI    
    {

        private Canvas canvas;
        private Pen pen;
        private List<Tuple<Sys.Graphics.Point, Color>> savedPixels;
        private TabBar tabBar;

        

        private MouseState prevMouseState;

        private UInt32 pX, pY;

        public GUI ()
        {
            System.Console.WriteLine("0");
            this.canvas = FullScreenCanvas.GetCurrentFullScreenCanvas();
            this.canvas.Clear(Color.Black);
            System.Console.WriteLine("1");
            this.pen = new Pen(Color.White);
            this.prevMouseState = MouseState.None;

            this.pX = 3;
            this.pY = 3;
            this.savedPixels = new List<Tuple<Sys.Graphics.Point, Color>>();

            this.tabBar = new TabBar(this.canvas);
            System.Console.WriteLine("2");
            MouseManager.ScreenHeight = (UInt32)this.canvas.Mode.Rows;
            MouseManager.ScreenWidth = (UInt32)this.canvas.Mode.Columns;
            System.Console.WriteLine("3");
        }

        public void handleGUIInputs()
        {

            if (this.pX != MouseManager.X && this.pY != MouseManager.Y)
            {

                if (MouseManager.X < 2 || MouseManager.Y < 2 || MouseManager.X > (MouseManager.ScreenWidth - 2) || MouseManager.Y > (MouseManager.ScreenHeight - 2))
                {
                    System.Console.WriteLine("4");
                    return;
                }

                this.pX = MouseManager.X;
                this.pY = MouseManager.Y;
                System.Console.WriteLine("5");
                Sys.Graphics.Point[] points=new Sys.Graphics.Point[]
                {
                    new Sys.Graphics.Point((Int32)MouseManager.X, (Int32)MouseManager.Y),
                    new Sys.Graphics.Point((Int32)MouseManager.X+1, (Int32)MouseManager.Y),
                    new Sys.Graphics.Point((Int32)MouseManager.X-1, (Int32)MouseManager.Y),
                    new Sys.Graphics.Point((Int32)MouseManager.X, (Int32)MouseManager.Y+1),
                    new Sys.Graphics.Point((Int32)MouseManager.X, (Int32)MouseManager.Y-1),
                };
                System.Console.WriteLine("6");
                foreach (Tuple<Sys.Graphics.Point,Color> pixelData in this.savedPixels)
                {

                    this.canvas.DrawPoint(new Pen(pixelData.Item2), pixelData.Item1);

                }
                System.Console.WriteLine("7");
                this.savedPixels.Clear();

                foreach (Sys.Graphics.Point p in points)
                {

                    this.savedPixels.Add(new Tuple<Sys.Graphics.Point, Color>(p, this.canvas.GetPointColor(p.X, p.Y)));
                    this.canvas.DrawPoint(this.pen, p);
                    System.Console.WriteLine("8");
                }

            }
            System.Console.WriteLine("9");
            if (MouseManager.MouseState == MouseState.Left && this.prevMouseState!=MouseState.Left)
            {
                System.Console.Beep();
            }

            this.prevMouseState = MouseManager.MouseState;
            System.Console.WriteLine("10");
        }

    }
}

