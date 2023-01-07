using tic_tac_toe.PackageForPlayers;

namespace tic_tac_toe.Services.Base
{
    public interface IAccountService
    { 
        bool FindAccount(string userName);
        Account AddAccountToDataBase(string firstName, string lastName, string userName, string password);
        Account AddPremiumAccountToDataBase(string firstName, string lastName, string userName, string password);
        
    }
}