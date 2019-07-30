using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;

namespace GhostMailingSystem
{
    public partial class GhostCoder : Form
    {
        CoreController coreController = new CoreController();

        public GhostCoder()
        {
            InitializeComponent();
        }

        private void GhostCoder_Load(object sender, EventArgs e)
        {
            lblHeading.Text = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (coreController.ValidateLogin())
            {
                lblHeading.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                txtFrom.Text = txtFromAddress.Text.ToString();
                LoginBox.Visible = false;
                EmailBox.Visible = true;
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (coreController.ValidateMailFields())
            {
                coreController.SendMail();
                MessageBox.Show("Sent Message To : ", txtTo.ToString());
            }
            else
            {
                MessageBox.Show("Validating Field Return false","Human Error");
            }
        }

        private void txtFromAddress_TextChanged(object sender, EventArgs e)
        {
            coreController.SetMailFrom(txtFromAddress.Text.ToString());
        }

        private void txtFromPassword_TextChanged(object sender, EventArgs e)
        {
            coreController.SetPassword(txtFromPassword.Text.ToString());
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            coreController.SetMessage(txtMessage.Text.ToString());
        }

        private void txtTo_TextChanged(object sender, EventArgs e)
        {
            coreController.SetMailTo(txtTo.Text.ToString());
        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {
            coreController.SetSubject(txtSubject.Text.ToString());
        }


    }
}
