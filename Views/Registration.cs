using School.Services;
using System;
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
    
    public partial class Registration : Form
    {
        private IRegService _regService = new RegService();
        public Registration()
        {
            InitializeComponent();
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            if (loginTextBox.Text.Length > 0)
            {
                if (password1TextBox.Text.Length > 0 || password2TextBox.Text.Length > 0)
                {
                    string output = _regService.Check(loginTextBox.Text, password1TextBox.Text, password2TextBox.Text);
                    MessageBox.Show(output,"Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (output == "Пользователь успешно зарегистрирован")
                    {
                        Close();
                    }
                }
                else MessageBox.Show("Укажите пароль в форме","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Укажите логин в форме", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (passwordCheckBox.Checked)
            {
                password1TextBox.PasswordChar = (char)0;
                password2TextBox.PasswordChar = (char)0;
            }
            else
            {
                password1TextBox.PasswordChar = '*';
                password2TextBox.PasswordChar = '*';
            }
        }
    }
}
