using JDR.Generic.Domain;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Data
{
    public class BankDAC : DataAccessComponent, IBankRepository
    {
        public List<IAccount> GetAllAccounts()
        {
            const string SQL_STATEMENT = "SELECT [ID], [Number], AccountTypeID, " +
                "AT.Name as AccountType, [Balance] FROM Accounts inner join AccountTypes AT on AccountTypeID = AT.ID";

            List<IAccount> result = new List<IAccount>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        IAccount account = LoadAccount(dr);
                        result.Add(account);
                    }
                }
            }
            return result;
        }

        private IAccount LoadAccount(IDataReader dr)
        {
            var accountType = GetDataValue<string>(dr, "AccountType");
            IAccount account = null;
            if (accountType == "Caja Ahorro")
                account = new SavingAccount();
            else
                account = new CurrentAccount();

            account.AccountNumber = GetDataValue<int>(dr, "Number");
            account.Balance = GetDataValue<float>(dr, "Balance");
            return account;
        }
    }
}
