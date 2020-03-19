using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    /// <summary>
    /// 그리기 모드 enum
    /// </summary>
    public enum DrawMode
    {
        penMode, //펜
        eraserMode, //지우개
        line, //선
        rect, //직사각형
        circle, //타원형
        curve, //곡선
        cloudMark, //구름모양
        heart //하트모양
    }

    public class DrawingData
    {
        public Point startPoint { get; set; }
        public Point endPoint { get; set; }
        public Pen pen { get; set; }
        public virtual void Drawing(Graphics g)
        {
            g.DrawLine(pen,startPoint, endPoint);
        }
    }

    /// <summary>
    /// 직사각형, 원
    /// </summary>
    public class rectangle : DrawingData
    {
        public Rectangle rec { get; set; }

    }

    /// <summary>
    /// 곡선
    /// </summary>
    public class CurveData : DrawingData
    {
        //곡선 포인트 저장하는 vo
        public Point[] point { get; set; }
        public override void Drawing(Graphics g)
        {
            g.DrawCurve(new Pen(Color.Aquamarine), point);
        }
    }

    /// <summary>
    /// 클라우드 마크
    /// </summary>
    public class CloudMark : rectangle
    {
        public string message { get; set; }

        public virtual void Drawing(Graphics g, Rectangle rec, Pen pen, string message)
        {
            this.pen = pen;
            this.rec = rec;
            this.message = message;

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

            StringFormat drawformat = new StringFormat();
            drawformat.Alignment = StringAlignment.Center;

            g.DrawString(message, font, Brushes.Black, rec, drawformat);
        }
    }

    /// <summary>
    /// 하트
    /// </summary>
    public class Heart : CloudMark
    {
        public override void Drawing(Graphics g, Rectangle rec, Pen pen, string message)
        {
            this.pen = pen;
            this.rec = rec;
            this.message = message;

            int circleWidth = rec.Width / 2;

            int widthcnt = 1;
            
            for (int i = rec.Y; i <= rec.Width; i += circleWidth)
            {
                Point temp_ = new Point(rec.X + circleWidth * widthcnt * 1, rec.Y);
                g.DrawEllipse(new Pen(Color.Aquamarine, 3), temp_.X - circleWidth, temp_.Y - circleWidth / circleWidth, circleWidth, circleWidth);
                widthcnt++;
            }

            Rectangle whiteRec = new Rectangle(rec.X-10, rec.Y + circleWidth / 2, rec.Width+50, circleWidth);
            g.FillRectangle(new SolidBrush(Color.White), whiteRec);

            g.DrawLine(new Pen(Color.Aquamarine, 3), new Point(rec.X, rec.Y + circleWidth / 2), new Point(rec.X + rec.Width / 2, rec.Y + rec.Height));
            g.DrawLine(new Pen(Color.Aquamarine, 3), new Point(rec.X + rec.Width, rec.Y + circleWidth / 2), new Point(rec.X + rec.Width / 2, rec.Y + rec.Height));

            Font font = new Font("Consolas", 12, FontStyle.Regular, GraphicsUnit.Point);

            StringFormat drawformat = new StringFormat();
            drawformat.Alignment = StringAlignment.Center;

            g.DrawString(message, font, Brushes.Black, whiteRec);
        }
    }
}
