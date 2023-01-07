﻿using System.Windows.Forms;
using tic_tac_toe.DataBase;
using tic_tac_toe.PackageForPlayers;

namespace tic_tac_toe.Forms;

public partial class MenuForm : Form
{
    private Account Player { get; }

    public MenuForm(Account player)
    {
        InitializeComponent();
        Player = player;
        Json.Save(InitializeForm.InitializeObjects.AccountService.DbContext);
    }


    private void button1_MouseClick(object sender, MouseEventArgs e)
    {
        var fr6 = new InfoForm(Player);
        fr6.Show();
        Hide();
    }


    private void button2_MouseClick(object sender, MouseEventArgs e)
    {
        var fr2 = new LogOrRegForm();
        fr2.Show();
        Hide();
    }

    private void button4_MouseClick(object sender, MouseEventArgs e)
    {
        var fr7 = new HistoryForm(Player);
        fr7.Show();
        Hide();
    }

    private void button3_MouseClick(object sender, MouseEventArgs e)
    {
        var fr8 = new PlayGameForm(Player);
        fr8.Show();
        Hide();
    }

    private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        Close();
    }
}