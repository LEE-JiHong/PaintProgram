namespace Paint
{
    partial class EditSizeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoPer = new System.Windows.Forms.RadioButton();
            this.rdoPix = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtwidth = new DevExpress.XtraEditors.TextEdit();
            this.txtheight = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtwidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtheight.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoPix);
            this.groupBox1.Controls.Add(this.rdoPer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "크기 조정";
            // 
            // rdoPer
            // 
            this.rdoPer.AutoSize = true;
            this.rdoPer.Location = new System.Drawing.Point(19, 33);
            this.rdoPer.Name = "rdoPer";
            this.rdoPer.Size = new System.Drawing.Size(59, 16);
            this.rdoPer.TabIndex = 0;
            this.rdoPer.TabStop = true;
            this.rdoPer.Text = "백분율";
            this.rdoPer.UseVisualStyleBackColor = true;
            // 
            // rdoPix
            // 
            this.rdoPix.AutoSize = true;
            this.rdoPix.Location = new System.Drawing.Point(130, 33);
            this.rdoPix.Name = "rdoPix";
            this.rdoPix.Size = new System.Drawing.Size(47, 16);
            this.rdoPix.TabIndex = 1;
            this.rdoPix.TabStop = true;
            this.rdoPix.Text = "픽셀";
            this.rdoPix.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "가로:";
            // 
            // txtwidth
            // 
            this.txtwidth.Location = new System.Drawing.Point(79, 100);
            this.txtwidth.Name = "txtwidth";
            this.txtwidth.Size = new System.Drawing.Size(123, 20);
            this.txtwidth.TabIndex = 2;
            // 
            // txtheight
            // 
            this.txtheight.Location = new System.Drawing.Point(79, 135);
            this.txtheight.Name = "txtheight";
            this.txtheight.Size = new System.Drawing.Size(123, 20);
            this.txtheight.TabIndex = 4;
            this.txtheight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtheight_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "세로:";
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.Location = new System.Drawing.Point(35, 173);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "확인";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnOK_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Location = new System.Drawing.Point(118, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "취소";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EditSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 208);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtheight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtwidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "EditSizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "크기 조정";
            this.Load += new System.EventHandler(this.EditSizeForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtwidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtheight.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoPix;
        private System.Windows.Forms.RadioButton rdoPer;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtwidth;
        private DevExpress.XtraEditors.TextEdit txtheight;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}