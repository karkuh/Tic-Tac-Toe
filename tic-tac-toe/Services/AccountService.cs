using System.Linq;
using tic_tac_toe.DataBase;
using tic_tac_toe.PackageForPlayers;
using tic_tac_toe.Services.Base;

namespace tic_tac_toe.Services
{
    public class AccountService:IAccountService
    {
        public DbContext DbContext { get; }

        public AccountService()
        {
            DbContext = Json.Load();
        }
        
        public bool FindAccount(string userName)
        {
            return DbContext.Accounts.Find(x => x.UserName.Equals(userName)) != null ;
        }

        public Account AddAccountToDataBase(string firstName, string lastName, string userName, string password)
        {
            DbContext.Accounts.Add(new Account(firstName,lastName,userName,password));
            return DbContext.Accounts.Last();
        }

        public Account AddPremiumAccountToDataBase(string firstName, string lastName, string userName, string password)
        {
            DbContext.Accounts.Add(new PremiumAccount(firstName,lastName,userName,password));
            return DbContext.Accounts.Last();
        }
    }
}