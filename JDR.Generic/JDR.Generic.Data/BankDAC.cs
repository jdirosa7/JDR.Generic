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
        public List<Account> GetAllAccounts()
        {
            const string SQL_STATEMENT = "SELECT A.ID, [Number], AccountTypeID, " +
                "AT.Name as AccountType, [Balance] FROM Accounts A inner join AccountTypes AT on A.AccountTypeID = AT.ID";

            List<Account> result = new List<Account>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Account account = LoadAccount(dr);
                        result.Add(account);
                    }
                }
            }
            return result;
        }

        public MovementType GetMovementByName(string movementType)
        {
            throw new NotImplementedException();
        }

        public void SaveMovement(BankOperation operation)
        {
            const string SQL_STATEMENT = "INSERT into Movements SET [SourceAccountID]= @SourceAccountID," +
                "[MovementTypeID]= @MovementTypeID," +
                "[Value]= @Value," +
                "[TargetAccountID]= @TargetAccountID";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@SourceAccountID", DbType.Decimal, operation.SourceAccount.Id);
                db.AddInParameter(cmd, "@TargetAccountID", DbType.Int32, operation.TargetAccount.Id);
                db.AddInParameter(cmd, "@MovementTypeID", DbType.Decimal, operation.MovementType.Id);
                db.AddInParameter(cmd, "@Value", DbType.Int32, operation.Value);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Account LoadAccount(IDataReader dr)
        {
            var accountType = GetDataValue<string>(dr, "AccountType");
            Account account = null;
            if (accountType == "Caja Ahorro")
                account = new SavingAccount();
            else
                account = new CurrentAccount();

            account.Id = GetDataValue<int>(dr, "ID");
            account.AccountNumber = GetDataValue<string>(dr, "Number");
            account.Balance = GetDataValue<decimal>(dr, "Balance");
            return account;
        }
    }
}
