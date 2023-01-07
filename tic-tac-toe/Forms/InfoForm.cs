using System.Linq;
using System.Windows.Forms;
using tic_tac_toe.Enums;
using tic_tac_toe.PackageForGame;
using tic_tac_toe.PackageForPlayers;

namespace tic_tac_toe.Forms;

public partial class InfoForm : Form
{
    private Account Player { get; }

    public InfoForm(Account player)
    {
        Player = player;
        InitializeComponent();
        ChangeInfo(firstNameText, player.FirstName);
        ChangeInfo(lastNameText, player.LastName);
        ChangeInfo(typeAccountText, player.TypeAccount.ToString());
        ChangeInfo(usernameText, player.UserName);
        ChangeInfo(ratingText, player.CurrentRating.ToString());
        ChangeInfo(gamesLemgthText, player.Results.Count.ToString());
        ChangeInfo(gamesLemgthWinText, player.Results.Count(x => x.Outcome == GameOutcome.WIN).ToString());
        ChangeInfo(gamesLemgthLoseText, player.Results.Count(x => x.Outcome == GameOutcome.LOSE).ToString());
        ChangeInfo(gamesLemgthTieText, player.Results.Count(x => x.Outcome == GameOutcome.TIE).ToString());
    }


    private static void ChangeInfo(Control label, string text)
    {
        var arr = label.Text.Split(':');
        label.Text = arr[0] + @": " + text;
    }
        
    private void button1_MouseClick(object sender, MouseEventArgs e)
    {
        var fr5 = new MenuForm(Player);
        fr5.Show();
        Hide();
    }




    private void InfoForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        Close();
    }
}