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
        List<Point[]> curveSaveData;

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
            curveSaveData = new List<Point[]>();
        }
        
        private void DrawAll()
        {
            g.Clear(Color.White);

            foreach (SaveData sd in lineSaveData)
            {
                g.DrawLine(new Pen(Color.Black), sd.startPoint, sd.endPoint);
            }

            foreach (Point[] pt in curveSaveData)
            {
                g.DrawCurve(new Pen(Color.Black), pt);
            }

            foreach (Rectangle rec in recSaveData)
            {
                g.DrawRectangle(new Pen(Color.Black), rec);
            }

            foreach (Rectangle rec in circleSaveSData)
            {
                g.DrawEllipse(new Pen(Color.Black), rec);
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
                color = Color.Black;
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
                        //g.DrawEllipse(p, curPoint.X, curPoint.Y, p.Width, p.Width); //타원 그리기

                        //pictureBox1.Image = picBmp;

                        //DrawAll(); 

                       // p.Dispose();
                        //break;

                    case DrawMode.line: //선 그리기
                        if (e.Button == MouseButtons.Left)
                        {
                            DrawAll();
                            g.DrawLine(new Pen(Color.Black), ClickPos, CurPos);
                        }
                        break;
                    case DrawMode.curve: //곡선 그리기
                        if (e.Button == MouseButtons.Left)
                        {
                            DrawAll();
                            g.DrawLine(new Pen(Color.Black), ClickPos, CurPos);
                        }
                        break;
                    case DrawMode.rect:
                        if (e.Button == MouseButtons.Left)
                        {
                            rec = new Rectangle(ClickPos.X, ClickPos.Y, CurPos.X, CurPos.Y);
                            DrawAll();
                            g.DrawRectangle(new Pen(Color.Black), rec);
                        }
                        break;
                    case DrawMode.circle:
                        if (e.Button == MouseButtons.Left)
                        {
                            rec = new Rectangle(ClickPos.X, ClickPos.Y, CurPos.X, CurPos.Y);
                            DrawAll();
                            g.DrawEllipse(new Pen(Color.Black), rec);
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
                Point[] p =
                {
                    curveSaveData[0].startPoint,
                    po,
                    curveSaveData[0].endPoint
                };
                //curveSaveData.lastr
                curveSaveData.Clear();
                DrawAll();
                g.DrawCurve(new Pen(Color.Black), p);
                curveFlag = false;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
            curveFlag = true;

            switch (drawMode)
            {
                case DrawMode.line:
                    SaveData sd = new SaveData();
                    sd.startPoint = ClickPos;
                    sd.endPoint = pictureBox1.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
                    lineSaveData.Add(sd);
                    break;
                case DrawMode.curve:
                    Point[] pt = 
                    {
                        ClickPos,

                    };
                    curveSaveData.Add();
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
            EditSizeForm frm = new EditSizeForm();
            frm.ShowDialog();
        }
    }
}
