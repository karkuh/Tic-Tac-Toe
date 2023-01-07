﻿using System.Windows.Forms;
using tic_tac_toe.PackageForGame;
using tic_tac_toe.PackageForPlayers;

namespace tic_tac_toe.Forms;

public partial class RealPlayGameForm : Form
{
    private readonly Game _game;
    private readonly Account _thisPlayer;
    private readonly Account _oponent;
    private readonly int _rating;
    private string _currentStep;
    private int _step;

    public RealPlayGameForm(Game game, Account thisPlayer, Account oponent, int rating)
    {
        InitializeComponent();
        _game = game;
        _thisPlayer = thisPlayer;
        _oponent = oponent;
        _rating = rating;
        _currentStep = _thisPlayer.UserName;
        label1.Text = @"Хід гравця " + _thisPlayer.UserName;
        _step = 1;

        label2.Text = $@"{thisPlayer.UserName} - X";
        label3.Text = $@"O - {oponent.UserName}";
    }

    private void button_MouseClick(object sender, MouseEventArgs e)
    {
        int temp;
        string curName;
        if (_currentStep == _thisPlayer.UserName)
        {
            sender.GetType().GetProperty("Text")?.SetValue(sender, "X");
            curName = _thisPlayer.UserName;
            _currentStep = _oponent.UserName;
            temp = 1;
        }
        else
        {
            sender.GetType().GetProperty("Text")?.SetValue(sender, "O");
            curName = _oponent.UserName;
            _currentStep = _thisPlayer.UserName;
            temp = 2;
        }

        sender.GetType().GetProperty("Enabled")?.SetValue(sender, false);
        _step++;

        var result = CheckWin();
        if (result)
        {
            MessageBox.Show(@"Win " + curName);
            _game.RealPlayingGame(_thisPlayer, _oponent, _rating, temp);
            var fr5 = new MenuForm(_thisPlayer);
            fr5.Show();
            Hide();
        }
        else if (_step == 10)
        {
            MessageBox.Show(@"Game tie ");
            ResTie();
            var fr5 = new MenuForm(_thisPlayer);
            fr5.Show();
            Hide();
        }

        label1.Text = @"Хід гравця " + _currentStep;
    }


    private void ResTie()
    {
        _game.RealPlayingGame(_thisPlayer, _oponent, _rating, 0);
    }

    private bool CheckWin()
    {
        //rows
        if (button1.Text == button2.Text && button2.Text == button3.Text && button1.Text != "")
        {
            return true;
        }

        if (button4.Text == button5.Text && button5.Text == button6.Text && button4.Text != "")
        {
            return true;
        }

        if (button7.Text == button8.Text && button8.Text == button9.Text && button7.Text != "")
        {
            return true;
        }
        //////////////////


        //columns
        if (button1.Text == button4.Text && button4.Text == button7.Text && button1.Text != "")
        {
            return true;
        }

        if (button2.Text == button5.Text && button5.Text == button8.Text && button2.Text != "")
        {
            return true;
        }

        if (button3.Text == button6.Text && button6.Text == button9.Text && button3.Text != "")
        {
            return true;
        }
        ////////////////////


        //diagonal

        if (button1.Text == button5.Text && button5.Text == button9.Text && button1.Text != "")
        {
            return true;
        }

        if (button7.Text == button5.Text && button5.Text == button3.Text && button7.Text != "")
        {
            return true;
        }

        return false;
    }

    private void RealPlayGameForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        Close();
            
    }
}