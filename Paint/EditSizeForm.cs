using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class EditSizeForm : Form
    {
        PictureBox pic;

        int perWidth;
        int perHeight;

        public int width
        {
            get { return Convert.ToInt32(txtwidth.Text); }
        }

        public int height
        {
            get { return Convert.ToInt32(txtheight.Text); }
        }
        public EditSizeForm(PictureBox pic)
        {
            InitializeComponent();
            this.pic = pic;
            rdoPix.Click += new EventHandler(RdoPix_click);
            rdoPer.Click += new EventHandler(RdoPer_click);
            /////////txtwidth.EditValueChanged += //이 부분
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetRdoPer()
        {
            txtwidth.Text = "100";
            txtheight.Text = "100";
            perWidth = Convert.ToInt32(txtwidth.Text);
            perHeight = Convert.ToInt32(txtheight.Text);
        }

        private void EditSizeForm_Load(object sender, EventArgs e)
        {
            rdoPer.Checked = true;
            SetRdoPer();
            btnOK.TabIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txtheight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOK_Click(sender, e);
            }
        }

        private void btnOK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.btnOK_Click(sender, e);
            }
        }
        private void RdoPix_click(object sender, EventArgs e)
        {
            if (rdoPix.Checked)
            {
                //txtwidth.Text = pic.Width * (txtwidth.Text/100)
                //txtwidth.Text =  pic.Width.ToString();
                //txtheight.Text = pic.Height.ToString();
            }
        }
        private void RdoPer_click(object sender, EventArgs e)
        {
            if (rdoPer.Checked)
            {
                SetRdoPer();
            }
        }
    }
}
