using School;
using School.Services;
using System;
using Serilog;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School
{
    public partial class Authorization : Form
    {
        private IAuthService _authService = new AuthService();
        public Authorization()
        {
            InitializeComponent();
            Status.Enter = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_authService.Authorize(loginTextBox.Text.ToString(), passwordTextBox.Text.ToString()) == true)
            {
                if (Status.Value)
                {
                    MessageBox.Show("Вы зашли от именни администратора", "Notification", MessageBoxButtons.OK ,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Вы зашли от имени учителя","Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Status.Enter = true;
                Status.User = loginTextBox.Text.ToString();
                Log.Information($"Пользователь {Status.User} вошел в сеть.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Wrong login or password!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.ShowDialog();
            loginTextBox.Text = reg.loginTextBox.Text;
            passwordTextBox.Text = reg.password1TextBox.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (passwordCheckBox.Checked)
            {
                passwordTextBox.PasswordChar = (char)0;
            }
            else
            {
                passwordTextBox.PasswordChar = '*';
            }
        }
    }
}
