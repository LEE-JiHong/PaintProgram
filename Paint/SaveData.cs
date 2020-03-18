using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public enum DrawMode
    {
        penMode, //펜
        eraserMode, //지우개
        line, //선
        rect, //직사각형
        circle, //타원형
        curve, //곡선
        cloudMark, //구름모양
        cloudMarkText
    }

    public class Shape
    {
        public Point point { get; set; }
        public Pen pen { get; set; }
    }

    public class rectangle : Shape
    {
        public Rectangle rec { get; set; }
    }

    public class CloudMark : rectangle
    {
        public void Drawing(Graphics g, Rectangle rec, Pen pen, string message)
        {
            this.pen = pen;
            this.rec = rec;

            string msg = message;

            int circleWidh = rec.Width / 5;
            int circleHeight = rec.Height / 5;

            int widthcnt = 1;

            for (int i = 0; i < rec.Width; i += circleWidh)
            {
                if (widthcnt > 5)
                {
                    break;
                }
                Point temp_ = new Point(rec.X + circleWidh * widthcnt * 1, rec.Y);
                g.DrawEllipse(pen, temp_.X - circleWidh, temp_.Y - circleWidh / 2, circleWidh, circleWidh); //top

                temp_ = new Point(rec.X + circleWidh * widthcnt * 1, rec.Y + rec.Height);
                g.DrawEllipse(pen, temp_.X - circleWidh, temp_.Y - circleWidh / 2, circleWidh, circleWidh); //bottom
                widthcnt++;
            }

            widthcnt = 1;

            for (int i = 0; i < rec.Height; i += circleHeight)
            {
                if (widthcnt > 5)
                {
                    break;
                }
                Point temp_ = new Point(rec.X, rec.Y + circleHeight * widthcnt * 1);
                g.DrawEllipse(pen, temp_.X - circleHeight / 2, temp_.Y - circleHeight, circleHeight, circleHeight);//left

                temp_ = new Point(rec.X + rec.Width, rec.Y + circleHeight * widthcnt * 1);
                g.DrawEllipse(pen, temp_.X - circleHeight / 2, temp_.Y - circleHeight, circleHeight, circleHeight); //right
                widthcnt++;
            }
            g.FillRectangle(new SolidBrush(Color.White), rec);

            Font font = new Font("Consolas", 12, FontStyle.Regular, GraphicsUnit.Point);
            g.DrawString(msg, font, Brushes.Black, rec);
        }
    }

    public class SaveData
    {
        //포인트 저장하는 vo
        public Point startPoint { get; set; }
        public Point endPoint { get; set; }
    }

    public class CurveData : SaveData
    {
        //곡선 포인트 저장하는 vo
        public Point[] point { get; set; }
        public void Drawing(Graphics g)
        {
            g.DrawCurve(new Pen(Color.Aquamarine), point);
        }
    }

    public class DrawingData
    {
        public Pen pen { get; set; }
        public Point point { get; set; }
    }


}
