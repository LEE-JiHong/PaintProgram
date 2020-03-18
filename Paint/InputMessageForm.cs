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
    public partial class InputMessageForm : Form
    {
        public string Message
        {
            get { return txtMessage.Text; }
            set { txtMessage.Text = value; }
        }

        public InputMessageForm()
        {
            InitializeComponent();

            Load += InputMessageForm_Load;
            btnOk.Click += new EventHandler(btnOk_click);
            btnCancel.Click += new EventHandler(btnCancel_click);
            txtMessage.KeyPress += txtMessage_Keypress;
        }

        private void InputMessageForm_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnOk_click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMessage_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnOk.PerformClick();
            }
        }
    }
}
