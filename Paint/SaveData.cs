using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
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
