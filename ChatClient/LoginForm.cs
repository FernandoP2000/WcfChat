using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtUserName.Text = Environment.UserName.Replace(Environment.UserName[0],Environment.UserName.ToUpper()[0]);
        }

        public string UserName { get; set; }
        public string ClavePrivada { get; set; }

        private void BotonOk(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUserName.Text))
            {
                this.UserName = txtUserName.Text;
                this.ClavePrivada = textBox1.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Inserta un nombre de usuario", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BotonCancelar(object sender, EventArgs e)
        {
            this.UserName = String.Empty;
            this.ClavePrivada = String.Empty;
            this.Close();
        }

        private new void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                BotonOk(sender, e);
            }
        }
    }
}
