using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using tic_tac_toe.Enums;
using tic_tac_toe.PackageForGame;
using tic_tac_toe.PackageForPlayers;


namespace tic_tac_toe.Forms;

public partial class PlayGameForm : Form
{
    private Account Player { get; }

    public PlayGameForm(Account player)
    {
        Player = player;
        InitializeComponent();
        oponentListBox.DataSource = InitializeForm.InitializeObjects.AccountService.DbContext.Accounts;
        oponentListBox.DisplayMember = "UserName";
        oponentText.Text = InitializeForm.InitializeObjects.AccountService.DbContext.Accounts[oponentListBox.SelectedIndex].UserName;
        ratingText.Text = ratingTrackBar.Minimum.ToString();
    }


    private void playBut_MouseClick(object sender, MouseEventArgs e)
    {
        if (oponentText.ForeColor == Color.Red) return;


        if (!realCheckBox.Checked)
        {
                
            if (classicRadio.Checked)
            {
                InitializeForm.InitializeObjects.ClassicGame.PlayingGame(Player,InitializeForm.InitializeObjects.AccountService.DbContext.Accounts[oponentListBox.SelectedIndex],ratingTrackBar.Value);

            }
            else if (personalRadio.Checked)
            {
                InitializeForm.InitializeObjects.GameForOne.PlayingGame(Player,InitializeForm.InitializeObjects.AccountService.DbContext.Accounts[oponentListBox.SelectedIndex],ratingTrackBar.Value);
            }
            else
            {
                InitializeForm.InitializeObjects.TrainingGame.PlayingGame(Player,InitializeForm.InitializeObjects.TrainingBot);
            }
                
                
                            
            switch (Player.Results.Last().Outcome)
            {
                case GameOutcome.WIN:
                    MessageBox.Show("You win\n+" + Player.Results.Last().Rating  + " rating");
                    break;
                case GameOutcome.LOSE:
                    MessageBox.Show("You lose\n-" + ratingTrackBar.Value + " rating");
                    break;
                case GameOutcome.TIE:
                    MessageBox.Show("Game tie");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            


            var fr5 = new MenuForm(Player);
            fr5.Show();
            Hide();
        }
        else
        {
            RealPlayGameForm fr9;
            if (classicRadio.Checked)
            {
                fr9 = new RealPlayGameForm(InitializeForm.InitializeObjects.ClassicGame, Player, InitializeForm.InitializeObjects.AccountService.DbContext.Accounts[oponentListBox.SelectedIndex],
                    ratingTrackBar.Value);
            }
            else if (personalRadio.Checked)
            {
                fr9 = new RealPlayGameForm(InitializeForm.InitializeObjects.GameForOne, Player, InitializeForm.InitializeObjects.AccountService.DbContext.Accounts[oponentListBox.SelectedIndex],
                    ratingTrackBar.Value);
            }
            else
            {
                fr9 = new RealPlayGameForm(InitializeForm.InitializeObjects.TrainingGame, Player, InitializeForm.InitializeObjects.TrainingBot, ratingTrackBar.Value);
            }

            fr9.Show();
            Hide();
        }



    }

    private void oponentListBox_MouseClick(object sender, MouseEventArgs e)
    {
        ClosePlayForMe();
    }

    private void ClosePlayForMe()
    {
        if (InitializeForm.InitializeObjects.AccountService.DbContext.Accounts[oponentListBox.SelectedIndex].UserName.Equals(Player.UserName))
        {
                
            oponentText.ForeColor = Color.Red;
            oponentText.Text = @"Ви не можете грати самі проти себе";
        }
        else
        {
            oponentText.ForeColor = Color.Black;
            oponentText.Text = InitializeForm.InitializeObjects.AccountService.DbContext.Accounts[oponentListBox.SelectedIndex].UserName;
        }
    }

    private void closeBut_MouseClick(object sender, MouseEventArgs e)
    {
        var fr5 = new MenuForm(Player);
        fr5.Show();
        Hide();
    }

    private void ratingTrackBar_ValueChanged(object sender, EventArgs e)
    {
        ratingText.Text = ratingTrackBar.Value.ToString();
    }

    private void trainingRadio_CheckedChanged(object sender, EventArgs e)
    {
        oponentListBox.Visible = false;
        oponentText.ForeColor = Color.Black;
        oponentText.Text = @"Training bot";
        ratingTrackBar.Visible = false;
        ratingText.Text = @"0";
    }


    private void personalRadio_CheckedChanged(object sender, EventArgs e)
    {
        oponentListBox.Visible = true;
        ratingTrackBar.Visible = true;
        ClosePlayForMe();
        ratingText.Text = ratingTrackBar.Value.ToString();
    }

    private void classicRadio_CheckedChanged(object sender, EventArgs e)
    {
        oponentListBox.Visible = true;
        ratingTrackBar.Visible = true;
        ClosePlayForMe();
        ratingText.Text = ratingTrackBar.Value.ToString();
    }

    private void PlayGameForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        Close();
            
    }
}