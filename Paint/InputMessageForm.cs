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
            btnOk.Click += new EventHandler(BtnOk_click);
            btnCancel.Click += new EventHandler(BtnCancel_click);
            txtMessage.KeyPress += TxtMessage_Keypress;
        }

        private void InputMessageForm_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void BtnOk_click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancel_click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtMessage_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnOk.PerformClick();
            }
        }
    }
}
