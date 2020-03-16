using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public enum DrawMode
    { 
        penMode, //펜
        eraserMode, //지우개
        line, //선
        rect, //직사각형
        circle, //타원형
        curve //곡선
    }

    public partial class Form1 : Form
    {
        DrawMode drawMode;

        int curLineSize = 1;
        Bitmap picBmp;

        bool flag = false;
        bool curveFlag = false;

        Graphics g = null;
        Point ClickPos = new Point();
        Point CurPos= new Point();
        Point kinowPoint;

        Rectangle rec;
        Pen p;

        List<SaveData> lineSaveData;
        List<Rectangle> recSaveData;
        List<Rectangle> circleSaveSData;
        List<CurveData> curveSaveData;
        List<DrawingData> drawingSaveData;

        public Form1()
        {
            InitializeComponent();

            picBmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = Graphics.FromImage(picBmp);
            pictureBox1.Image = picBmp;

            lineSaveData = new List<SaveData>();
            recSaveData = new List<Rectangle>();
            circleSaveSData = new List<Rectangle>();
            curveSaveData = new List<CurveData>();
            drawingSaveData = new List<DrawingData>();
        }
        
        private void DrawAll()
        {
            g.Clear(Color.White);

            foreach (SaveData sd in lineSaveData)
            {
                g.DrawLine(new Pen(Color.Aquamarine), sd.startPoint, sd.endPoint);
            }

            foreach (CurveData pt in curveSaveData)
            {
                if (pt.point != null)
                {
                    g.DrawCurve(new Pen(Color.Aquamarine), pt.point);
                }
            }

            foreach (Rectangle rec in recSaveData)
            {
                g.DrawRectangle(new Pen(Color.Aquamarine), rec);
            }

            foreach (Rectangle rec in circleSaveSData)
            {
                g.DrawEllipse(new Pen(Color.Aquamarine), rec);
            }

            foreach (DrawingData dd in drawingSaveData)
            {
                g.DrawEllipse(dd.pen, dd.point.X, dd.point.Y, dd.pen.Width, dd.pen.Width);
            }

            pictureBox1.Image = picBmp;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Color color;

            CurPos = pictureBox1.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));

            if (drawMode == DrawMode.eraserMode)
            {
                color = Color.White;
            }
            else
            {
                color = Color.Aquamarine;
            }

            pictureBox1.Image = picBmp;

            p = new Pen(color)
            {
                Width = curLineSize
            };

            if (flag)
            {
                switch (drawMode)
                {
                    case DrawMode.penMode:
                    case DrawMode.eraserMode:
                        g.DrawEllipse(p, CurPos.X, CurPos.Y, p.Width, p.Width); //타원 그리기
                        DrawingData dd = new DrawingData();
                        dd.pen = p;
                        dd.point = CurPos;
                        drawingSaveData.Add(dd);
                        //DrawAll(); 
                        // p.Dispose();
                        break;
                    case DrawMode.line: //선 그리기
                        if (e.Button == MouseButtons.Left)
                        {
                            DrawAll();
                            g.DrawLine(new Pen(Color.Aquamarine), ClickPos, CurPos);
                        }
                        break;

                    case DrawMode.curve: //곡선 그리기
                        if (e.Button == MouseButtons.Left)
                        {
                            DrawAll();
                            g.DrawLine(new Pen(Color.Aquamarine), ClickPos, CurPos);
                        }
                        break;

                    case DrawMode.rect: //직사각형 그리기
                        if (e.Button == MouseButtons.Left)
                        {
                            rec = new Rectangle(ClickPos.X, ClickPos.Y, CurPos.X, CurPos.Y);
                            DrawAll();
                            g.DrawRectangle(new Pen(Color.Aquamarine), rec);
                        }
                        break;

                    case DrawMode.circle: //타원형 그리기
                        if (e.Button == MouseButtons.Left)
                        {
                            rec = new Rectangle(ClickPos.X, ClickPos.Y, CurPos.X, CurPos.Y);
                            DrawAll();
                            g.DrawEllipse(new Pen(Color.Aquamarine), rec);
                        }
                        break;
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;

            ClickPos = pictureBox1.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
            kinowPoint = ClickPos;
            
            if (curveFlag == true && drawMode == DrawMode.curve) //곡선
            {
                Point po = pictureBox1.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
                int count = curveSaveData.Count-1;
                Point[] p =
                {
                    curveSaveData[count].startPoint,
                    po,
                    curveSaveData[count].endPoint,
                };

                CurveData cd = new CurveData();
                cd.startPoint = curveSaveData[count].startPoint;
                cd.endPoint = curveSaveData[count].endPoint;
                cd.point = p;
                
                curveSaveData.RemoveAt(count);
                curveSaveData.Add(cd);
                DrawAll();
                g.DrawCurve(new Pen(Color.Aquamarine), p);
                curveFlag = false;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
            switch (drawMode)
            {
                case DrawMode.penMode:
                case DrawMode.eraserMode:
                    DrawingData dd = new DrawingData();
                    dd.pen = p;
                    dd.point = CurPos;
                    drawingSaveData.Add(dd);
                    break;

                case DrawMode.line:
                    SaveData sd = new SaveData();
                    sd.startPoint = ClickPos;
                    sd.endPoint = pictureBox1.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
                    lineSaveData.Add(sd);
                    break;

                case DrawMode.curve:
                    CurveData cd = new CurveData();
                    cd.startPoint = ClickPos;
                    cd.endPoint = pictureBox1.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
                    curveSaveData.Add(cd);
                    curveFlag = true;
                    break;

                case DrawMode.rect:
                    recSaveData.Add(rec);
                    break;

                case DrawMode.circle:
                    circleSaveSData.Add(rec);
                    break;
            }

            if (drawMode == DrawMode.rect)
            {
                Graphics g = Graphics.FromImage(picBmp);
                g.DrawRectangle(p,rec);
            }
        }

        private void btnBrush_Click(object sender, EventArgs e)
        {
            //브러쉬 버튼 선택
        }

        #region 브러쉬 펜 굵기 세팅
        //펜
        private void thin_Click(object sender, EventArgs e)
        {
            //브러쉬 펜 굵기 - 얇게
            SetPenOrEraser(1, DrawMode.penMode);
        }

        private void regular_Click(object sender, EventArgs e)
        {
            //브러쉬 펜 굵기 - 보통
            SetPenOrEraser(3, DrawMode.penMode);
        }

        private void bold_Click(object sender, EventArgs e)
        {
            //브러쉬 펜 굵기 - 굵게
            SetPenOrEraser(6, DrawMode.penMode);
        }

        //지우개
        private void EraThin_Click(object sender, EventArgs e)
        {
            //브러쉬 펜 굵기 - 얇게
            SetPenOrEraser(1, DrawMode.eraserMode);
        }

        private void EraRegular_Click(object sender, EventArgs e)
        {
            //브러쉬 펜 굵기 - 중간
            SetPenOrEraser(5, DrawMode.eraserMode);
        }

        private void EraBold_Click(object sender, EventArgs e)
        {
            //브러쉬 펜 굵기 - 굵게
            SetPenOrEraser(10, DrawMode.eraserMode);
        }

        #endregion

        //펜 굵기 설정
        public void SetPenOrEraser(int curLineSize, DrawMode drawMode)
        {
            this.curLineSize = curLineSize;
            this.drawMode = drawMode;
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            //선 버튼 클릭
            drawMode = DrawMode.line;
        }

        private void btnRec_Click(object sender, EventArgs e)
        {
            //직사각형 버튼 클릭
            drawMode = DrawMode.rect;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //전체 지우기
            g.Clear(Color.White);
            
            lineSaveData.Clear();
            recSaveData.Clear();
            circleSaveSData.Clear();
            curveSaveData.Clear();
            drawingSaveData.Clear();

            pictureBox1.Image = picBmp;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            //타원형 버튼 클릭
            drawMode = DrawMode.circle;
        }

        private void btnCurve_Click(object sender, EventArgs e)
        {
            //곡선 버튼 클릭
            drawMode = DrawMode.curve;
        }

        private void EditSizeMenu_Click(object sender, EventArgs e)
        {
            EditSizeForm frm = new EditSizeForm(pictureBox1);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Width = frm.width;
                pictureBox1.Height = frm.height;
                picBmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                g = Graphics.FromImage(picBmp);
                pictureBox1.Image = picBmp;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //Point[] poin = new Point[]
            //{
            //    new Point(175, 10),
            //    new Point(10,165),
            //    new Point(340, 165),
            //    new Point(200, 400),
            //};

            //g.DrawPolygon(new Pen(Color.Red), poin);

            ////클라우드 마크 만들기
            //Rectangle rectangle = new Rectangle(106, 51, 417, 180);
            //g.DrawRectangle(new Pen(Color.Aquamarine), rectangle);
            //pictureBox1.Image = picBmp;

            //하트 만들기
            //g.DrawEllipse(p, 50, 50, 80, 80);
            //g.DrawEllipse(p, 130, 50, 80, 80);

            //Point[] point = new Point[]
            //{
            //    new Point(70,40),
            //    new Point(80, 30),
            //    new Point(90,40)

            //};

            //Point[] point2 = new Point[]
            //{
            //    new Point(90,40),
            //    new Point(100, 30),
            //    new Point(110,40)

            //};

            int startp = 70;
            int middlep = 80;
            int endp = 90;

            for (int i = 0; i < 5; i++)
            {
                Pen pp = new Pen(Color.Red);

                Point[] point = new Point[]
                {
                    new Point(startp,40),
                    new Point(middlep, 33),
                    new Point(endp,40)
                };

                g.DrawCurve(pp, point);

                Point[] pointunder = new Point[]
                { 
                    new Point(startp, 90),
                    new Point(middlep, 97),
                    new Point(endp, 90)
                };
                
                g.DrawCurve(pp, pointunder);

                Point[] pointleft = new Point[]
                {
                    new Point(70, 60),
                    new Point(63, 50),
                    new Point(70, 40)
                };

                g.DrawCurve(pp, pointleft);

                startp += 20;
                middlep += 20;
                endp += 20;
            }
            ////곡선 만들기
            //g.DrawCurve(pp, point);
            //g.DrawCurve(pp, point2);

            pictureBox1.Image = picBmp;
        }

        private void btnAnyPoint_Click(object sender, EventArgs e)
        {
            //다각형
            //Point[] poin = new Point[]
            //{
            //    new Point(175, 10),
            //    new Point(10,165),
            //    new Point(340, 165),
            //    new Point(200, 400),
            //};

            //g.DrawPolygon(new Pen(Color.Red), poin);
        }

        private void btnCloudMarkup_Click(object sender, EventArgs e)
        {
            //클라우드 마크 만들기
            Pen pp = new Pen(Color.Red,3);

            Rectangle rectangle = new Rectangle(106, 51, 300, 300);
            //g.DrawRectangle(new Pen(Color.Aquamarine), rectangle); //사각형은 그려주지 않음
            //pictureBox1.Image = picBmp;

            int divWidth = rectangle.Width/4;
            int divHeight = rectangle.Height/4;

            int pointX = rectangle.X;
            int pointY = rectangle.Y;

            for (int i = 0; i < 4; i++)
            {
                //가로
                Point[] p1 = new Point[]
                { 
                    new Point(pointX, pointY),
                    new Point((pointX + divWidth / 2), pointY - 20),
                    new Point(pointX + divWidth,pointY)
                };

                Point[] p2 = new Point[]
                {
                    new Point(pointX, pointY + rectangle.Height),
                    new Point((pointX + divWidth / 2), (pointY+ rectangle.Height) + 20),
                    new Point(pointX + divWidth,pointY + rectangle.Height)
                };

                //rectangle.X += divWidth;
                pointX += divWidth;

                g.DrawCurve(pp, p1);
                g.DrawCurve(pp, p2);
            }

            pointX = rectangle.X;
            pointY = rectangle.Y;

            for (int i = 0; i < 4; i++)
            {
                //세로
                Point[] p3 = new Point[]
                {
                    new Point(pointX, pointY),
                    new Point(pointX - 20,(pointY + divHeight / 2)),
                    new Point(pointX, pointY + divHeight)
                };

                Point[] p4 = new Point[]
                {
                    new Point(pointX + rectangle.Width, pointY),
                    new Point(pointX + rectangle.Width + 20,(pointY + divHeight / 2)),
                    new Point(pointX + rectangle.Width, pointY + divHeight)
                };

                pointY += divHeight;

                g.DrawCurve(pp, p3);
                g.DrawCurve(pp, p4);
            }

            pictureBox1.Image = picBmp;
        }
    }
}
