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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditSizeForm_Load(object sender, EventArgs e)
        {
            rdoPix.Checked = true;
            txtwidth.Text =  pic.Width.ToString();
            txtheight.Text = pic.Height.ToString();
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
    }
}
