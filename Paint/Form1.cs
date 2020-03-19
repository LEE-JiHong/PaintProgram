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
    public partial class Form1 : Form
    {
        DrawMode drawMode;

        int curLineSize = 1;
        Bitmap picBmp;

        bool flag = false;
        bool curveFlag1 = false;
        bool curveFlag2 = false;

        Graphics g = null;
        Point ClickPos = new Point();
        Point CurPos = new Point();

        Rectangle rec;
        CloudMark cloudMark;
        Pen p;

        //이전 데이터들을 담을 변수
        List<DrawingData> lineSaveData; //선
        List<Rectangle> recSaveData; //사각형
        List<Rectangle> circleSaveSData; //원
        List<CurveData> curveSaveData; //곡선
        List<DrawingData> drawingSaveData;
        List<CloudMark> cloudMarkSaveData;//클라우드마크

        string text = null;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

            picBmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            btnMemo.Click += new EventHandler(btnMemo_click);
            btnHeartMemo.Click += new EventHandler(btnHeartMemo_click);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            g = Graphics.FromImage(picBmp);
            pictureBox1.Image = picBmp;

            lineSaveData = new List<DrawingData>();
            recSaveData = new List<Rectangle>();
            circleSaveSData = new List<Rectangle>();
            curveSaveData = new List<CurveData>();
            drawingSaveData = new List<DrawingData>();
            cloudMarkSaveData = new List<CloudMark>();

            cloudMark = new CloudMark();
        }

        private void DrawAll()
        {
            g.Clear(Color.White);

            foreach (DrawingData sd in lineSaveData)
            {
                g.DrawLine(new Pen(Color.Aquamarine), sd.startPoint, sd.endPoint);
            }

            foreach (CurveData pt in curveSaveData)
            {
                if (pt.point != null)
                {

                    pt.Drawing(g);
                    
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
                g.DrawEllipse(dd.pen, dd.startPoint.X, dd.startPoint.Y, dd.pen.Width, dd.pen.Width);
            }

            foreach (CloudMark cm in cloudMarkSaveData)
            {
                cloudMark.Drawing(g, cm.rec, new Pen(Color.Aquamarine), cm.message);
            }

            pictureBox1.Image = picBmp;

            switch (drawMode)
            {
                case DrawMode.line: //선 그리기
                    g.DrawLine(new Pen(Color.Aquamarine), ClickPos, CurPos);
                    break;
                case DrawMode.curve: //곡선 그리기
                    g.DrawLine(new Pen(Color.Aquamarine), ClickPos, CurPos);
                    break;
                case DrawMode.rect: //직사각형 그리기
                    rec = new Rectangle(ClickPos.X, ClickPos.Y, CurPos.X - ClickPos.X, CurPos.Y - ClickPos.Y);
                    g.DrawRectangle(new Pen(Color.Aquamarine), rec);
                    break;
                case DrawMode.circle: //타원형 그리기
                    rec = new Rectangle(ClickPos.X, ClickPos.Y, CurPos.X - ClickPos.X, CurPos.Y - ClickPos.Y);
                    g.DrawEllipse(new Pen(Color.Aquamarine), rec);
                    break;
                case DrawMode.cloudMark: //클라우드마크
                    rec = new Rectangle(ClickPos.X, ClickPos.Y, CurPos.X - ClickPos.X, CurPos.Y - ClickPos.Y);

                    if (text == "") //텍스트가 없을 경우
                    {
                        cloudMark.Drawing(g, rec, new Pen(Color.Aquamarine), "");
                    }
                    else //텍스트가 있을 경우
                    {
                        cloudMark.Drawing(g, rec, new Pen(Color.Aquamarine), text);
                    }
                    break;
                case DrawMode.heart: //하트
                    Heart heart = new Heart();
                    rec = new Rectangle(ClickPos.X, ClickPos.Y, CurPos.X - ClickPos.X, CurPos.Y - ClickPos.Y);

                    if (text == "") //텍스트가 없을 경우
                    {
                        heart.Drawing(g, rec, new Pen(Color.Aquamarine), "");
                    }
                    else //텍스트가 있을 경우
                    {
                        heart.Drawing(g, rec, new Pen(Color.Aquamarine), text);
                    }
                    break;
            }
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
                        dd.startPoint = CurPos;
                        drawingSaveData.Add(dd);
                        break;
                    case DrawMode.line: //선 그리기
                        if (e.Button == MouseButtons.Left)
                        {
                            DrawAll();
                        }
                        break;

                    case DrawMode.curve: //곡선 그리기
                        if (e.Button == MouseButtons.Left)
                        {
                            DrawAll();
                            curveFlag2 = true;
                        }
                        break;

                    case DrawMode.rect: //직사각형 그리기
                        if (e.Button == MouseButtons.Left)
                        {
                            DrawAll();
                        }
                        break;

                    case DrawMode.circle: //타원형 그리기
                        if (e.Button == MouseButtons.Left)
                        {
                            DrawAll();
                        }
                        break;
                    case DrawMode.cloudMark:
                        if (e.Button == MouseButtons.Left) //클라우드 마크 그리기
                        {
                            DrawAll();
                        }
                        break;
                    case DrawMode.heart:
                        if (e.Button == MouseButtons.Left) //하트 그리기
                        {
                            DrawAll();
                        }
                        break;
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;

            ClickPos = pictureBox1.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));

            if (curveFlag1 == true && curveFlag2 == true && drawMode == DrawMode.curve) //곡선
            {
                if (curveSaveData.Count >= 1)
                {
                    Point po = pictureBox1.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
                    int count = curveSaveData.Count - 1;
                    Point[] p =
                    {
                        curveSaveData[count].startPoint,
                        po,
                        curveSaveData[count].endPoint,
                    };

                    CurveData cd = new CurveData();
                    //cd.startPoint = curveSaveData[count].startPoint;
                    // cd.endPoint = curveSaveData[count].endPoint;
                    cd.point = p;

                    curveSaveData.RemoveAt(count);
                    curveSaveData.Add(cd);
                    DrawAll();
                    curveFlag1 = false;
                    curveFlag2 = false;
                }
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
                    dd.startPoint = CurPos;
                    drawingSaveData.Add(dd);
                    break;

                case DrawMode.line:
                    DrawingData sd = new DrawingData();
                    sd.startPoint = ClickPos;
                    sd.endPoint = pictureBox1.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
                    lineSaveData.Add(sd);
                    break;

                case DrawMode.curve:
                    CurveData cd = new CurveData();
                    cd.startPoint = ClickPos;
                    cd.endPoint = pictureBox1.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
                    curveSaveData.Add(cd);
                    curveFlag1 = true;
                    break;
                case DrawMode.rect:
                    recSaveData.Add(rec);
                    break;

                case DrawMode.circle:
                    circleSaveSData.Add(rec);
                    break;

                case DrawMode.cloudMark:
                    CloudMark cm = new CloudMark();
                    cm.message = text;
                    cm.rec = rec;
                    cloudMarkSaveData.Add(cm);
                    break;
            }

            if (drawMode == DrawMode.rect)
            {
                Graphics g = Graphics.FromImage(picBmp);
                g.DrawRectangle(p, rec);
            }
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


        public void SetPenOrEraser(int curLineSize, DrawMode drawMode)
        {
            //펜 굵기 설정
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
            cloudMarkSaveData.Clear();

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

        private void btnCloudMarkup_Click(object sender, EventArgs e)
        {
            drawMode = DrawMode.cloudMark;
            text = ""; //text 초기화
        }

        private void btnHeart_Click(object sender, EventArgs e)
        {
            //하트모양
            drawMode = DrawMode.heart;
        }

        private void btnMemo_click(object sender, EventArgs e)
        {
            text = ""; //text 초기화
            drawMode = DrawMode.cloudMark;

            InputMessageForm frm = new InputMessageForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                text = frm.Message;
            }
        }
        private void btnHeartMemo_click(object sender, EventArgs e)
        {
            text = ""; //text 초기화
            drawMode = DrawMode.heart;

            InputMessageForm frm = new InputMessageForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                text = frm.Message;
            }
        }
    }
}
