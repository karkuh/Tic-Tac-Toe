using System;
using System.Windows.Forms;
using tic_tac_toe.Hashing;


namespace tic_tac_toe.Forms;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
    }

    private void button5_MouseClick(object sender, MouseEventArgs e)
    {
        var player1 = InitializeForm.InitializeObjects.AccountService.DbContext.Accounts.Find(x => x.UserName.Equals(userNameBox.Text));
        if (userNameBox.Text == "" && passwordBox.Text == "")
        {
            label5.Text = @"Заповніть усі поля";
        }
        else if (player1 == null)
        {
            label5.Text = @"Такого користувача не існує";
        }
        else
        {
            var fr5 = new MenuForm(player1);
            if (player1.Password != Md5.HashPassword(passwordBox.Text))
            {
                label5.Text = @"Неправильно введений пароль";
            }
            else
            {
                fr5.Show();
                Hide();
            }
        }
    }

    private void button1_MouseClick(object sender, MouseEventArgs e)
    {
        var fr2 = new LogOrRegForm();
        fr2.Show();
        Hide();
    }


    private void checkBox1_MouseCaptureChanged(object sender, EventArgs e)
    {
        passwordBox.PasswordChar = checkBox1.Checked ? new char() : '*';
    }

    private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        Close();
    }
}