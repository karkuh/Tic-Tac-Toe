using System.Drawing;
using System.Windows.Forms;
using tic_tac_toe.Enums;
using tic_tac_toe.PackageForPlayers;

namespace tic_tac_toe.Forms;

public partial class HistoryForm : Form
{
    private Account Player { get; }

    public HistoryForm(Account player)
    {
        InitializeComponent();
        Player = player;
        label9.Text += @" " + player.UserName;

        int number = 1;
        foreach (var temp in player.Results)
        {
            dataGridView1.Rows.Add(number, temp.TypeGame.ToString(), temp.Id, temp.Oponent.UserName, temp.Rating,
                temp.Outcome,
                $"{temp.BeforeRating,2} {(temp.Outcome == GameOutcome.LOSE ? $"-{temp.BeforeRating - temp.AfterRating,2}" : $"+{temp.AfterRating - temp.BeforeRating,2}")}",
                temp.AfterRating);
            number++;
        }

        foreach (DataGridViewRow row in dataGridView1.Rows)
            if (row.Cells[5].Value.ToString() == GameOutcome.WIN.ToString())
            {
                row.Cells[5].Style.BackColor = Color.Green;
            }
            else if (row.Cells[5].Value.ToString() == GameOutcome.LOSE.ToString())
            {
                row.Cells[5].Style.BackColor = Color.Red;
            }
            else
            {
                row.Cells[5].Style.BackColor = Color.Orange;
            }


    }


    private void button1_MouseClick(object sender, MouseEventArgs e)
    {
        var fr5 = new MenuForm(Player);
        fr5.Show();
        Hide();
    }

    private void HistoryForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        Close();
    }

}