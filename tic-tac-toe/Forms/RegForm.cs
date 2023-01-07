using System;
using System.Windows.Forms;
using tic_tac_toe.Hashing;
using tic_tac_toe.PackageForPlayers;

namespace tic_tac_toe.Forms;

public partial class RegForm : Form
{
    public RegForm()
    {
        InitializeComponent();
    }


    private void button5_MouseClick(object sender, MouseEventArgs e)
    {
        if (firstNameTextBox.Text != "" && lastNameTextBox.Text != "" && userNameTextBox.Text != "" &&
            passwordTextBox.Text != "")
        {
            if (!InitializeForm.InitializeObjects.AccountService.FindAccount(userNameTextBox.Text))
            {
                if (passwordTextBox.Text.Length >= 8)
                {
                    Account player;
                    if (ClassicAcc.Checked)
                    {
                        player = InitializeForm.InitializeObjects.AccountService.AddAccountToDataBase(firstNameTextBox.Text,
                            lastNameTextBox.Text,
                            userNameTextBox.Text, Md5.HashPassword(passwordTextBox.Text));
                    }
                    else
                    {
                        player = InitializeForm.InitializeObjects.AccountService.AddPremiumAccountToDataBase(firstNameTextBox.Text,
                            lastNameTextBox.Text, userNameTextBox.Text, Md5.HashPassword(passwordTextBox.Text));
                    }

                    var fr5 = new MenuForm(player);
                    fr5.Show();
                    Hide();
                }
                else
                {
                    label5.Text = @"Короткий пароль";
                }
            }
            else
            {
                label5.Text = @"Псевдонім зайнятий";
            }
        }
        else
        {
            label5.Text = @"Заповніть усі поля";
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
        passwordTextBox.PasswordChar = checkBox1.Checked ? new char() : '*';
    }


    private void RegForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        Close();
    }
}