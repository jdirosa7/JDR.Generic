using JDR.Generic.Domain;
using JDR.Generic.Entities;
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
    public class AccountDAC : DataAccessComponent, IAccountRepository
    {
        public void Deposit(BankOperation operation)
        {
            const string SQL_STATEMENT = "UPDATE Accounts SET [Balance]= @Balance WHERE [ID]= @ID ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Balance", DbType.Decimal, operation.TargetAccount.Balance + operation.Value);                
                db.AddInParameter(cmd, "@ID", DbType.Int32, operation.TargetAccount);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Extract(BankOperation operation)
        {
            const string SQL_STATEMENT = "UPDATE Accounts SET [Balance]= @Balance WHERE [ID]= @ID ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Balance", DbType.Decimal, operation.SourceAccount.Balance - operation.Value);
                db.AddInParameter(cmd, "@ID", DbType.Int32, operation.SourceAccount);
                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
