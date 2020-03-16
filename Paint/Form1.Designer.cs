namespace Paint
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditSizeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.브러쉬ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thin = new System.Windows.Forms.ToolStripMenuItem();
            this.regular = new System.Windows.Forms.ToolStripMenuItem();
            this.bold = new System.Windows.Forms.ToolStripMenuItem();
            this.지우개ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EraThin = new System.Windows.Forms.ToolStripMenuItem();
            this.EraRegular = new System.Windows.Forms.ToolStripMenuItem();
            this.EraBold = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLine = new DevExpress.XtraEditors.SimpleButton();
            this.btnCurve = new DevExpress.XtraEditors.SimpleButton();
            this.btnCircle = new DevExpress.XtraEditors.SimpleButton();
            this.btnRec = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAnyPoint = new DevExpress.XtraEditors.SimpleButton();
            this.btnCloudMarkup = new DevExpress.XtraEditors.SimpleButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.EditSizeMenu,
            this.브러쉬ToolStripMenuItem,
            this.지우개ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(959, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // EditSizeMenu
            // 
            this.EditSizeMenu.Name = "EditSizeMenu";
            this.EditSizeMenu.Size = new System.Drawing.Size(71, 20);
            this.EditSizeMenu.Text = "크기 조정";
            this.EditSizeMenu.Click += new System.EventHandler(this.EditSizeMenu_Click);
            // 
            // 브러쉬ToolStripMenuItem
            // 
            this.브러쉬ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thin,
            this.regular,
            this.bold});
            this.브러쉬ToolStripMenuItem.Name = "브러쉬ToolStripMenuItem";
            this.브러쉬ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.브러쉬ToolStripMenuItem.Text = "브러쉬";
            // 
            // thin
            // 
            this.thin.Name = "thin";
            this.thin.Size = new System.Drawing.Size(98, 22);
            this.thin.Text = "얇게";
            this.thin.Click += new System.EventHandler(this.thin_Click);
            // 
            // regular
            // 
            this.regular.Name = "regular";
            this.regular.Size = new System.Drawing.Size(98, 22);
            this.regular.Text = "중간";
            this.regular.Click += new System.EventHandler(this.regular_Click);
            // 
            // bold
            // 
            this.bold.Name = "bold";
            this.bold.Size = new System.Drawing.Size(98, 22);
            this.bold.Text = "굵게";
            this.bold.Click += new System.EventHandler(this.bold_Click);
            // 
            // 지우개ToolStripMenuItem
            // 
            this.지우개ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EraThin,
            this.EraRegular,
            this.EraBold});
            this.지우개ToolStripMenuItem.Name = "지우개ToolStripMenuItem";
            this.지우개ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.지우개ToolStripMenuItem.Text = "지우개";
            // 
            // EraThin
            // 
            this.EraThin.Name = "EraThin";
            this.EraThin.Size = new System.Drawing.Size(98, 22);
            this.EraThin.Text = "얇게";
            this.EraThin.Click += new System.EventHandler(this.EraThin_Click);
            // 
            // EraRegular
            // 
            this.EraRegular.Name = "EraRegular";
            this.EraRegular.Size = new System.Drawing.Size(98, 22);
            this.EraRegular.Text = "중간";
            this.EraRegular.Click += new System.EventHandler(this.EraRegular_Click);
            // 
            // EraBold
            // 
            this.EraBold.Name = "EraBold";
            this.EraBold.Size = new System.Drawing.Size(98, 22);
            this.EraBold.Text = "굵게";
            this.EraBold.Click += new System.EventHandler(this.EraBold_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.flowLayoutPanel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(959, 28);
            this.panelControl1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnLine);
            this.flowLayoutPanel1.Controls.Add(this.btnCurve);
            this.flowLayoutPanel1.Controls.Add(this.btnCircle);
            this.flowLayoutPanel1.Controls.Add(this.btnRec);
            this.flowLayoutPanel1.Controls.Add(this.btnClear);
            this.flowLayoutPanel1.Controls.Add(this.simpleButton1);
            this.flowLayoutPanel1.Controls.Add(this.btnAnyPoint);
            this.flowLayoutPanel1.Controls.Add(this.btnCloudMarkup);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(959, 28);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(3, 3);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(58, 22);
            this.btnLine.TabIndex = 2;
            this.btnLine.Text = "선";
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnCurve
            // 
            this.btnCurve.Location = new System.Drawing.Point(67, 3);
            this.btnCurve.Name = "btnCurve";
            this.btnCurve.Size = new System.Drawing.Size(58, 22);
            this.btnCurve.TabIndex = 3;
            this.btnCurve.Text = "곡선";
            this.btnCurve.Click += new System.EventHandler(this.btnCurve_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Location = new System.Drawing.Point(131, 3);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(58, 22);
            this.btnCircle.TabIndex = 4;
            this.btnCircle.Text = "타원";
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnRec
            // 
            this.btnRec.Location = new System.Drawing.Point(195, 3);
            this.btnRec.Name = "btnRec";
            this.btnRec.Size = new System.Drawing.Size(58, 22);
            this.btnRec.TabIndex = 5;
            this.btnRec.Text = "직사각형";
            this.btnRec.Click += new System.EventHandler(this.btnRec_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(259, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(74, 22);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "전체 지우기";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(339, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(74, 22);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "테스트";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(959, 563);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // btnAnyPoint
            // 
            this.btnAnyPoint.Location = new System.Drawing.Point(419, 3);
            this.btnAnyPoint.Name = "btnAnyPoint";
            this.btnAnyPoint.Size = new System.Drawing.Size(74, 22);
            this.btnAnyPoint.TabIndex = 9;
            this.btnAnyPoint.Text = "다각형";
            this.btnAnyPoint.Click += new System.EventHandler(this.btnAnyPoint_Click);
            // 
            // btnCloudMarkup
            // 
            this.btnCloudMarkup.Location = new System.Drawing.Point(499, 3);
            this.btnCloudMarkup.Name = "btnCloudMarkup";
            this.btnCloudMarkup.Size = new System.Drawing.Size(108, 22);
            this.btnCloudMarkup.TabIndex = 10;
            this.btnCloudMarkup.Text = "cloud markup";
            this.btnCloudMarkup.Click += new System.EventHandler(this.btnCloudMarkup_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(959, 615);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "그림판";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnLine;
        private DevExpress.XtraEditors.SimpleButton btnCurve;
        private DevExpress.XtraEditors.SimpleButton btnCircle;
        private DevExpress.XtraEditors.SimpleButton btnRec;
        private System.Windows.Forms.ToolStripMenuItem EditSizeMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 브러쉬ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thin;
        private System.Windows.Forms.ToolStripMenuItem regular;
        private System.Windows.Forms.ToolStripMenuItem bold;
        private System.Windows.Forms.ToolStripMenuItem 지우개ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EraThin;
        private System.Windows.Forms.ToolStripMenuItem EraRegular;
        private System.Windows.Forms.ToolStripMenuItem EraBold;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnAnyPoint;
        private DevExpress.XtraEditors.SimpleButton btnCloudMarkup;
    }
}

