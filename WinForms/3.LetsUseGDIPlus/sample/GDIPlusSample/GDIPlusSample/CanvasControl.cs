using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDIPlusSample
{
    public class CanvasControl : Control
    {
        private bool firstDraw = true;

        public CanvasControl()
        {
            ResizeRedraw = true;
        }

        private Bitmap buffer;
        private Graphics bg;
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (buffer != null)
                buffer.Dispose();

            buffer = new Bitmap(ClientSize.Width, ClientSize.Height);
            bg = Graphics.FromImage(buffer);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Sample4(e);

            Invalidate();
        }

        private int x, y;
        private void Sample4(PaintEventArgs e)
        {
            var g = e.Graphics;

            x++;
            if (x > ClientSize.Width)
            {
                x = 0;
                y += 20;
            }
            bg.TranslateTransform(x, y);
           
            bg.ScaleTransform(0.3f, 0.3f);
            Draw(bg);
            bg.ResetTransform();

            g.DrawImage(buffer, 0, 0);

            // ----
            void Draw(Graphics g)
            {
                g.Clear(Color.Black);

                g.FillEllipse(Brushes.Green, ClientRectangle);
            }
        }

        private void Sample3(PaintEventArgs e)
        {
            var g = e.Graphics;
            var rect = ClientRectangle;

            g.TranslateTransform(100, 50);
            Draw(g, Font);

            g.TranslateTransform(130, 130);
            Draw(g, Font);

            g.TranslateTransform(130, 130);
            g.ScaleTransform(1.5f, 1.5f);
            g.RotateTransform(45);
            Draw(g, Font);

            ////

            static void Draw(Graphics g, Font font)
            {
                // g.Transform
                // g.TransformPoints
                // g.TranslateClip
                // g.TranslateTransform
                // g.MultiplyTransform()
                // g.ResetTransform
                // g.RotateTransform
                // g.ScaleTransform


                using var glPen = new Pen(Color.White)
                {
                };
                using var sPen = new Pen(Color.White);

                g.DrawLine(glPen, 0, 0, 150, 0);
                g.DrawLine(sPen, 50, -5, 50, 5);
                g.DrawLine(sPen, 100, -5, 100, 5);
                g.DrawString("50", font, Brushes.White, 41, -24);
                g.DrawString("100", font, Brushes.White, 88, -24);
                g.DrawString("x", font, Brushes.White, 160, -8);

                g.DrawLine(glPen, 0, 0, 0, 100);
                g.DrawLine(sPen, -5, 50, 5, 50);
                g.DrawString("50", font, Brushes.White, -26, 42);
                g.DrawString("y", font, Brushes.White, -6, 110);

                g.DrawLine(Pens.Red, 0, 0, 160, 80);
            }
        }

        private void Sample1(PaintEventArgs e)
        {
            var g = e.Graphics;
            var rect = ClientRectangle;
            var clipRect = e.ClipRectangle;

            // 선
            g.DrawLine(Pens.Red, 50, 50, 100, 100);

            // 면
            g.DrawRectangle(Pens.Green, 10, 10, 30, 30);

            // 원
            g.DrawEllipse(Pens.Gray, 100, 100, 50, 50);

            if (firstDraw == false)
            {
                g.FillRectangle(Brushes.Gray, rect);
            }

            firstDraw = false;
        }

        private void Sample2(PaintEventArgs e)
        {
            var g = e.Graphics;
            var rect = ClientRectangle;

            g.FillEllipse(Brushes.Green, rect);
        }
    }
}
